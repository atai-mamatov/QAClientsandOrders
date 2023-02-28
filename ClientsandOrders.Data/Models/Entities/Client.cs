using ClientsandOrders.Data.Models.Common;

namespace ClientsandOrders.Data.Models.Entities
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNum { get; set; }
        public uint OrderAmount { get; set; }
        public DateTime DateAdd { get; set; }
        public List<Order> OrdersList = new List<Order>();
    }

}
