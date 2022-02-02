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
        public BaseService(IEFContext eFContext)
        {
            context = eFContext.CreateDBContext();
        }
        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this.context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this.context.Set<T>().Attach(t);
            this.context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.context.Set<T>().Attach(t);
            }
            this.context.Set<T>().RemoveRange(tList);
            this.Commit();
        }

        public T Find<T>(int id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }

        public T Insert<T>(T t) where T : class
        {
            this.context.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.context.Set<T>().AddRange(tList);
            this.Commit();//写在这里  就不需要单独commit  不写就需要 
            return tList;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return this.context.Set<T>().Where<T>(funcWhere);
        }

        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");

            this.context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为UnChanged
            this.context.Entry<T>(t).State = EntityState.Modified;
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.context.Set<T>().Attach(t);
                this.context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }
        public virtual void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }
    }
}
