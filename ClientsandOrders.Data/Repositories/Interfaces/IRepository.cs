using ClientsandOrders.Data.Models.Common;

namespace ClientsandOrders.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public T Add(T item); // C
        public List<T> GetAll(); // R
        public T GetById(int id); // R
        public void Edit(T item); // U
        public void Delete(T item); // D
    }
}
