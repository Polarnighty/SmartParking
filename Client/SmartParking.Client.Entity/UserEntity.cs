using System;
using System.Collections.Generic;

namespace SmartParking.Client.Entity
{
    public class UserEntity
    {
        //public int UserId { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string UserIcon { get; set; }

        public List<MenuEntity> Menus { get; set; }
    }
}
