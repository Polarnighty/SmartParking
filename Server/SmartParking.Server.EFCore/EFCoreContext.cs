using Microsoft.EntityFrameworkCore;
using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.EFCore
{
    public class EFCoreContext:DbContext
    {
        private readonly string strConn= "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SmartParking;Integrated Security=True;";
        protected DbSet<SysUserInfo> sysUserInfos;
        public EFCoreContext()
        {
            //Database.EnsureCreated();
        }
        public EFCoreContext(string connectStr)
        {
            strConn = connectStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn);
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysUserInfo>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
