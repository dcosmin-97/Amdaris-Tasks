using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Collections_Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EmployeeDBContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new EmployeeDBContext();
            //table = _context.Set<T>();
        }
        public GenericRepository(EmployeeDBContext _context)
        {
            this._context = _context;
            //table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
            //return table.ToList();
        }
        public T GetById(object id)
        {
            throw new NotImplementedException();
            //return table.Find(id);
        }
        public void Insert(T obj)
        {
            //table.Add(obj);
        }
        public void Update(T obj)
        {
            //table.Attach(obj);
            //_context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            //T existing = table.Find(id);
            //table.Remove(existing);
        }
        public void Save()
        {
            //_context.SaveChanges();
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
