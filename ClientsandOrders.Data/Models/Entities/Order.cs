using ClientsandOrders.Data.Models.Common;

namespace ClientsandOrders.Data.Models.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public uint ClientId { get; set; }
        public string Description { get; set; }
        public float OrderPrice { get; set; }
        public DateTime? CloseDate { get; set; }
        public Client Client { get; set; }
    }

}
