using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.Models
{
    public class RoleMenu
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }

    }
}
