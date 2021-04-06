using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerFindeks : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Findeks { get; set; }
    }
}
