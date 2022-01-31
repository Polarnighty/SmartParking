
using Microsoft.EntityFrameworkCore;

namespace SmartParking.Server.EFCore
{
    public interface IEFContext
    {
        EFCoreContext CreateDBContext();
    }
}
