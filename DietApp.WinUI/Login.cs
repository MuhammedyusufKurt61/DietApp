using DietApp.BLL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.UserViewModels;
using DietApp.WinUI.AdminScreen;
using DietApp.WinUI.EFContextInjection;
using Microsoft.Win32;
using Online2.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp.WinUI
{
    public partial class Login : Form
    {
        private readonly IUserBLL _userBLL;
        public Login(IUserBLL userBLL)
        {
            _userBLL= userBLL;
            InitializeComponent();
        }      
               

        private void LoginOnClick(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            UserLoginVM login = new UserLoginVM
            {
                UserName = userName,
                Password = password
            };
            ResultService<User> user = _userBLL.Login(login);
            GetUserTypes(user);
        }

        private void GetUserTypes(ResultService<User> user)
        {
            if (user.HasError)
            {
                string errorMessage = user.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = user.ErrorItems.ToList()[0].ErrorType;

                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form frm = default;

                if (user.Data.UserTypes == UserTypes.Admin)
                {
                    frm = EFContextForm.ConfigureServices<AdminForm>();
                }
                frm.Show();                
            }

        }

        
    }
}
