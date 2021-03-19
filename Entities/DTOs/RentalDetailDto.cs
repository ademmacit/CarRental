using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
