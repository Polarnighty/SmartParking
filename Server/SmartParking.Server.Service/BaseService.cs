using Microsoft.EntityFrameworkCore;
using SmartParking.Server.EFCore;
using SmartParking.Server.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartParking.Server.Service
{
    public class BaseService : IBaseService
    {
        protected DbContext context;
        public BaseService(EFContext eFContext)
        {
            context = eFContext.CreateDBContext();
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete<T>(int Id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
