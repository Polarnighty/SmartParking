using Microsoft.EntityFrameworkCore;
using SmartParking.Server.Configuration;
using System;

namespace SmartParking.Server.EFCore
{
    public class EFContext : IEFContext
    {
        IConfiguration configuration;

        public EFContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public EFCoreContext CreateDBContext()
        {
            return new EFCoreContext(configuration.Read("DBConnectionString"));
        }

    }
}
