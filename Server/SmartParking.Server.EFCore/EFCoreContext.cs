using Microsoft.EntityFrameworkCore;
using System;

namespace SmartParking.Server.EFCore
{
    public class EFCoreContext : DbContext
    {
        private readonly string connection = "";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
