using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp37.Core;
using WpfApp37.Model;
using WpfApp37.View;

namespace WpfApp37
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CoreDbConnect.DB = new test02Entities();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Table_1 userModel = CoreDbConnect.DB.Table_1.FirstOrDefault(u => u.UserLogin == TbLogin.Text && u.Password == PbPassword.Password);

                if (userModel != null)
                {
                    switch (userModel.Role)
                    {
                        case "admin":
                            new AdminWindow().ShowDialog();
                            break;

                        case "dev":
                            new DevWindow().ShowDialog();
                            break;

                        case "user":
                            new UserWindow().ShowDialog();
                            break;
                    }
                }
                else
                {
                    new ErrorWindow().ShowDialog();
                }
            }
            catch (Exception)
            {
                new ErrorWindow().ShowDialog();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAdminInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "Admin";
            PbPassword.Password = "adm!N";
        }

        private void BtnDevInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "Dev";
            PbPassword.Password = "D3v!][";
        }

        private void BtnUserInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "User";
            PbPassword.Password = "1qw~12";
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = string.Empty;
            PbPassword.Password = string.Empty;
        }

    }
}
