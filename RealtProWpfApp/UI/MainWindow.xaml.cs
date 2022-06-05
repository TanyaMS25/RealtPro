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

namespace RealtProWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Models.Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new UI.PageAuthorization());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
                ResizeMode = ResizeMode.CanResize;
                if (Models.Manager.realtor != null)
                {
                    tBlockUserInfo.Text = "Пользователь: " + Models.Manager.realtor.FirstName + " " + Models.Manager.realtor.LastName + " (" + Models.Manager.user.Role.Name + ")";
                }
                if (Models.Manager.admin != null)
                {
                    tBlockUserInfo.Text = "Пользователь: " + Models.Manager.admin.FirstName + " " + Models.Manager.admin.LastName + " (" + Models.Manager.user.Role.Name + ")";
                }
                if (Models.Manager.headOfSales != null)
                {
                    tBlockUserInfo.Text = "Пользователь: " + Models.Manager.headOfSales.FirstName + " " + Models.Manager.headOfSales.LastName + " (" + Models.Manager.user.Role.Name + ")";
                }
            }
            else
            {
                tBlockUserInfo.Text = "";
                btnBack.Visibility = Visibility.Hidden;
                ResizeMode = ResizeMode.NoResize;
                Height = 600;
                Width = 1100;

            }
            try
            {
                if (Models.Manager.user != null)
                {
                    if (Models.Manager.user.Role.Name == "admin")
                    {
                        btnAuthHistory.Visibility = Visibility.Visible;

                        btnApartment.Visibility = Visibility.Hidden;
                        btnPrintApartment.Visibility = Visibility.Hidden;
                        btnHouse.Visibility = Visibility.Hidden;
                        btnPrintHouse.Visibility = Visibility.Hidden;
                        btnClient.Visibility = Visibility.Hidden;
                        btnPrintClient.Visibility = Visibility.Hidden;
                        btnMainRealtor.Visibility = Visibility.Hidden;

                        btnPrintApartHeadDep.Visibility = Visibility.Hidden;
                        btnPrintHouseHeadDep.Visibility = Visibility.Hidden;

                        btnUserData.Visibility = Visibility.Hidden;
                    }
                    if (Models.Manager.user.Role.Name == "realtor")
                    {

                        btnApartment.Visibility = Visibility.Visible;
                        btnPrintApartment.Visibility = Visibility.Visible;
                        btnHouse.Visibility = Visibility.Visible;
                        btnPrintHouse.Visibility = Visibility.Visible;
                        btnClient.Visibility = Visibility.Visible;
                        btnPrintClient.Visibility = Visibility.Visible;
                        btnMainRealtor.Visibility = Visibility.Visible;

                        btnAuthHistory.Visibility = Visibility.Hidden;

                        btnPrintApartHeadDep.Visibility = Visibility.Hidden;
                        btnPrintHouseHeadDep.Visibility = Visibility.Hidden;

                        btnUserData.Visibility = Visibility.Visible;
                    }
                    if (Models.Manager.user.Role.Name == "headOfSalesDepartment")
                    {

                        btnAuthHistory.Visibility = Visibility.Hidden;

                        btnApartment.Visibility = Visibility.Hidden;
                        btnPrintApartment.Visibility = Visibility.Hidden;
                        btnHouse.Visibility = Visibility.Hidden;
                        btnPrintHouse.Visibility = Visibility.Hidden;
                        btnClient.Visibility = Visibility.Hidden;
                        btnPrintClient.Visibility = Visibility.Hidden;
                        btnMainRealtor.Visibility = Visibility.Hidden;

                        btnPrintApartHeadDep.Visibility = Visibility.Visible;
                        btnPrintHouseHeadDep.Visibility = Visibility.Visible;

                        btnUserData.Visibility = Visibility.Visible;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnAuthHistory_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAuthHistory());
        }
               
                
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
          
        private void btnHouse_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageHouse());
        }
        private void btnPrintHouse_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PagePrintHouse());
        }
        private void btnApartment_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageApartment());
        }
        private void btnPrintApartment_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PagePrintApartment());
        }
        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageClient());
        }
        private void btnPrintClient_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PagePrintClient());
        }

        private void btnMainRealtor_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageRealtor());
        }

        private void btnPrintApartHeadDep_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PagePrintApartmentHeadDepartment());
        }

        private void btnPrintHouseHeadDep_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PagePrintHouseHeadDepartment());
        }

        private void btnUserData_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageUserData(Models.Manager.user));
        }
    }
}
