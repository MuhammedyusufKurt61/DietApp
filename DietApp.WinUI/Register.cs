using DietApp.BLL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.UserViewModels;
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
    public partial class Register : Form
    {
        private readonly IUserBLL _userBLL;
        public Register(IUserBLL userBLL)
        {
            InitializeComponent();
            _userBLL = userBLL;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            UserCreateVM vm = new UserCreateVM()
            {
                UserName = userName,
                Email = email,
                Password = password,
            };
            ResultService<User> newUser = _userBLL.CreateUser(vm);
            if (newUser.HasError)
            {
                string errorMessage = newUser.ErrorItems.ToList().First().ErrorMessage;
                string errorType = newUser.ErrorItems.ToList()[0].ErrorType;                
                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
