using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.EFCore
{
    public class EFCoreContext:DbContext
    {
        private readonly string strConn;

        public EFCoreContext(string connectStr)
        {
            strConn = connectStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
