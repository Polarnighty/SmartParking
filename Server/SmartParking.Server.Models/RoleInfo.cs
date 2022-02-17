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
    public class RoleInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        [DefaultValue(1)]
        public int State { get; set; }
        public List<MenuInfo> MenuInfos { get; set; }
        public List<SysUserInfo> UserInfos { get; set; }

    }
}
