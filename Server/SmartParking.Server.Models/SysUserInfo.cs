using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    public class SysUserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string PassWord { get; set; }
        public string UserIcon { get; set; }
        public List<RoleInfo> RoleInfos { get; set; }
        [NotMapped]
        public List<MenuInfo> Menus { get; set; }

    }
}
