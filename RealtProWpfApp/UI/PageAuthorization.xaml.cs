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

namespace RealtProWpfApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }
        private void addEntryHistory(int userId, bool resultAuth)
        {
            try
            {
                Entities.AuthHistory authHistory = new Entities.AuthHistory();
                authHistory.UserId = userId;
                authHistory.Date = DateTime.Now;
                authHistory.Status = resultAuth;
                App.DateBase.AuthHistories.Add(authHistory);
                App.DateBase.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private void btnAuhoriz_Click(object sender, RoutedEventArgs e)
        {
            int userId = 0;
            if (tbLogin.Text.Length == 0)
            {
                MessageBox.Show("Вы не ввели логин", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (pbPassword.Password.Length == 0)
            {
                MessageBox.Show("Вы не ввели пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
                var user = App.DateBase.Users.Where(p => p.Login == tbLogin.Text && p.Password == pbPassword.Password).FirstOrDefault();
                var wrongUserPassword= App.DateBase.Users.Where(p => p.Login == tbLogin.Text && p.Password != pbPassword.Password).FirstOrDefault();
                
                if (wrongUserPassword != null)
                {
                    userId = wrongUserPassword.Id;
                    if (userId != 0)
                        addEntryHistory(userId, false);
                }
                if (user != null)
                {
                    if (user.ActivateId == 2)
                    {
                        MessageBox.Show("Ваша учетная запись была заблокирована, обратитесь к администратору системы");
                        userId = user.Id;
                        if (userId != 0)
                            addEntryHistory(userId, false);
                    }
                    else if (user.ActivateId == 1)
                    {
                        user.LastEnter = DateTime.Now;
                        Models.Manager.user = user;
                        var rol = user.Role.Name;
                        if (rol == "admin")
                        {
                            MessageBox.Show("Вы вошли как админ");

                            Models.Manager.admin = App.DateBase.Admins.Where(p => p.UserId == user.Id).FirstOrDefault();
                            Models.Manager.MainFrame.Navigate(new PageAdmin());

                            userId = user.Id;
                            addEntryHistory(userId, true);
                        }
                        if (rol == "realtor")
                        {
                            MessageBox.Show("Вы вошли как риелтор");

                            Models.Manager.realtor = App.DateBase.Realtors.Where(p => p.UserId == user.Id).FirstOrDefault();
                            Models.Manager.MainFrame.Navigate(new PageRealtor());

                            userId = user.Id;
                            addEntryHistory(userId, true);
                        }
                        if (rol == "headOfSalesDepartment")
                        {
                            MessageBox.Show("Вы вошли как руководитель отдела продаж");

                            Models.Manager.headOfSales = App.DateBase.HeadOfSalesDepartments.Where(p => p.UserId == user.Id).FirstOrDefault();
                            Models.Manager.MainFrame.Navigate(new PageHeadOfSalesDepartment());

                            userId = user.Id;
                            addEntryHistory(userId, true);
                        }
                }
                                        }
                if (user == null && (tbLogin.Text.Length != 0 && pbPassword.Password.Length != 0))
                {
                    MessageBox.Show("Введены неверные данные для входа");
                }          
        }

        private void cbVisiblePassword_Click(object sender, RoutedEventArgs e)
        {
            if (cbVisiblePassword.IsChecked == true)
            {
                pbPassword.Visibility = Visibility.Hidden;
                tbPassword.Visibility = Visibility.Visible;
                tbPassword.Text = pbPassword.Password;
            }
            else
            {
                pbPassword.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Hidden;
                pbPassword.Password = tbPassword.Text;
            }
        }
    }
}
