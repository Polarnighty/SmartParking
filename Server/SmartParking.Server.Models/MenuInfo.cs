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
    public class MenuInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        public string MenuHeader { get; set; }
        public string TargetView { get; set; }
        public int ParentId { get; set; }
        [Column(TypeName="nvarchar(4)")]
        public string MenuIcon { get; set; }
        public int Index { get; set; }
        public int MenuType { get; set; }
        [DefaultValue(1)]
        public int State { get; set; }
        public List<RoleInfo> RoleInfos { get; set; }


    }
}
