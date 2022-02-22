using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.Client.BaseModule.Models
{
    public class UserModel
    {
        public int Index { get; set; }
        public int UserId { get; set; }
        public string UserIcon { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string RealName { get; set; }

        public ObservableCollection<RoleModel> Roles { get; set; } = new ObservableCollection<RoleModel>();


        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RoleCommand { get; set; }
        public ICommand PwdCommand { get; set; }

    }
}
