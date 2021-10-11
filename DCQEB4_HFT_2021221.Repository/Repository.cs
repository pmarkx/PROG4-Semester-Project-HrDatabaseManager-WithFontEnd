using System;
using System.Collections.Generic;
using System.Linq;
using DCQEB4_HFT_2021221.Data;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected HrDbContex contex;
        public Repository(HrDbContex contex)
        {
            this.contex = contex;
        }
        public void Create(T entity)
        {
            contex.Set<T>().Add(entity);
            contex.SaveChanges();
        }

        public void Delete(T entity)
        {
            contex.Set<T>().Remove(entity);
            contex.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return contex.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Update(T entety)
        {
            contex.Update(entety);
            contex.SaveChanges();
        }
    }
}
