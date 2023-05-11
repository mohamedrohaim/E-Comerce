using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Add(T item)
        {
            _appDbContext.Set<T>().Add(item);
            return _appDbContext.SaveChanges();
        }

        public int Delete(T item)
        {
            _appDbContext.Set<T>().Remove(item);
            return _appDbContext.SaveChanges();
        }

        public T Get(int id)
           =>  _appDbContext.Set<T>().Find(id);
        

        public IEnumerable<T> GetAll()
        => _appDbContext.Set<T>().ToList();
        

        public int Update(T item)
        {
           _appDbContext.Set<T>().Update(item);
            return _appDbContext.SaveChanges();
        }
    }
}
