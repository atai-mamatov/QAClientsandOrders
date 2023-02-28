using ClientsandOrders.Data.Models.Common;

namespace ClientsandOrders.Data.Models.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public uint ClientId { get; set; }
        public string Description { get; set; }
        public float OrderPrice { get; set; }
        public DateTime CloseDate { get; set; }
        public Client Client { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Description} | {OrderDate.Date:dd MMM yyyy} | {Client.FirstName} {Client.SecondName} | {OrderPrice} | {CloseDate.Date:dd MMM yyyy}";
        }
    }

}
