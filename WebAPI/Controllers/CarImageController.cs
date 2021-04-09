using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {

        ICarImageService _CarImageService;
        private IWebHostEnvironment _environment;

        public CarImageController(ICarImageService CarImageService , IWebHostEnvironment environment)
        {
            _CarImageService = CarImageService;
            _environment = environment;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _CarImageService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] int id)
        {
            var result = _CarImageService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId( int carId)
        {
            var result = _CarImageService.GetImagesByCarId(carId);
            if (result.Data[0].Id == 0)
                result.Data[0].ImagePath = 
                    "\\carImages\\" + "default.jpg";

            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int carId, [FromForm] IFormFile image)
        {
            string extension = Path.GetExtension(image.FileName);
            if (extension != ".jpeg" && extension != ".png")
                return BadRequest("wrong file format");
            string newImageName = Guid.NewGuid().ToString() + extension;

            string folderPath = Path.Combine(_environment.WebRootPath, "carImages");
            string imagePathForDB = Path.Combine("carImages", newImageName);
            string imagePathForCreatingFile = Path.Combine(_environment.WebRootPath, imagePathForDB);


            CarImage carImage = new CarImage()
            {
                CarId = carId,
                ImagePath = imagePathForDB
            };

            var result = _CarImageService.Add(carImage);

            if (result.Success)
            {

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                

                using (FileStream fileStream = System.IO.File.Create(imagePathForCreatingFile))
                {
                    image.CopyTo(fileStream);
                }
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _CarImageService.Delete(carImage);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(
            [FromForm] int carImageId,
            [FromForm] int carId,
            [FromForm] IFormFile image)
        {
            string extension = Path.GetExtension(image.FileName);
            if (extension != ".jpeg" && extension != ".png")
                return BadRequest("wrong file format");

            string path = _CarImageService.GetById(carImageId).Data.ImagePath;
            System.IO.File.Delete(path);
            path =  Path.ChangeExtension(path, extension);
            using (FileStream fileStream = System.IO.File.Create(path))
            {
                image.CopyTo(fileStream);
                fileStream.Flush();
            }

            var result = _CarImageService.Update(
                new CarImage()
                { Id = carImageId, CarId = carId, Date = DateTime.Now, ImagePath = path });

            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}