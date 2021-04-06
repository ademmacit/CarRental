using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public int LastUseMonth { get; set; }
        public int LastUseYear { get; set; }
        public int cvv { get; set; }
    }
}
