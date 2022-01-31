using Microsoft.EntityFrameworkCore;
using SmartParking.Server.Configuration;
using System;

namespace SmartParking.Server.EFCore
{
    public class EFContext : IEFContext
    {
        //private readonly string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartParking;Integrated Security=True;";

        IConfiguration configuration;

        public EFContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public EFCoreContext CreateDBContext()
        {
            return new EFCoreContext(configuration.Read("DBConnectionStrings"));
        }

    }
}
