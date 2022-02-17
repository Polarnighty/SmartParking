using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.EFCore
{
    public class EFCoreContext : DbContext
    {
        private readonly string strConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SmartParking;Integrated Security=True;";
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

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //设置联合主键
            //modelBuilder.Entity<RoleMenu>().HasKey(pk => new { pk.MenuId, pk.RoleId });
            //modelBuilder.Entity<UserRole>().HasKey(pk => new { pk.UserID, pk.RoleId });

            //转换菜单表中的字体图标值
            var iconValueConverter = new ValueConverter<string, string>(
                v => string.IsNullOrEmpty(v) ? null : ((int)(v.ToCharArray()[0])).ToString("x"),
                v => v == null ? "" : ((char)(int.Parse(v, System.Globalization.NumberStyles.HexNumber))).ToString()
                );
            modelBuilder.Entity<MenuInfo>().Property(m => m.MenuIcon).HasConversion(iconValueConverter);

            modelBuilder.Entity<SysUserInfo>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MenuInfo> MenuInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }

    }
}
