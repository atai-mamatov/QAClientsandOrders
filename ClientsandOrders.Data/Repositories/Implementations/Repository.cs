﻿using ClientsandOrders.Data.Database.SqlServer;
using ClientsandOrders.Data.Models.Common;
using ClientsandOrders.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientsandOrders.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public T Add(T item)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(T);

            T result = dbSet.Add(item).Entity;
            _context.SaveChanges();

            return result;
        }

        public void Delete(T item)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return;

            dbSet.Remove(item);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(List<T>);

            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(T);

            T item = dbSet
                .FirstOrDefault(obj => obj.Id == id);

            return item;
        }

        public void Edit(T item)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return;

            dbSet.Update(item);

            _context.SaveChanges();
        }
    }
}
