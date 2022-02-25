using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SmartParking.Client.BaseModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.Client.BaseModule.ViewModels
{
    public class ModifyUserDialogViewModel :BindableBase, IDialogAware
    {
        public string Title => "用户信息编辑";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public ModifyUserDialogViewModel()
        {

        }
        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // 接受编辑状态:新增/删除
            // 获取要编辑的用户信息
            MainModel = parameters.GetValue<UserModel>("model");
        }

        private UserModel _mainModel=new UserModel();
        public UserModel MainModel { get=> _mainModel; set { SetProperty<UserModel>(ref _mainModel, value); } }

        // 确认
        public ICommand ConfirmCommand
        {
            get => new DelegateCommand(() =>
            {
                //user
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            });
        }
        // 取消
        public ICommand CancenlCommand
        {
            get => new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            });
        }
    }
}
