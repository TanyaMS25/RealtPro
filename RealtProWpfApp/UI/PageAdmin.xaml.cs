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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    App.DateBase.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    dgAdmin.ItemsSource = App.DateBase.Users.ToList();
                    if(dgAdmin.Items.Count == 0)
                    {
                        tbInfoDG.Text = "Данный список пуст";
                    }
                    else
                    {
                        tbInfoDG.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                try
                {
                    dgAdmin.ItemsSource = App.DateBase.Users.Where(p =>
                         p.Login.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
                    if (dgAdmin.Items.Count == 0)
                    {
                        tbInfoDG.Text = "Данный список пуст";
                    }
                    else
                    {
                        tbInfoDG.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    dgAdmin.ItemsSource = App.DateBase.Users.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditUser((sender as Button).DataContext as Entities.User));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditUser(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = dgAdmin.SelectedItems.Cast<Entities.User>().ToList();
            if (usersForRemoving.Count != 0)
            {

                if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        App.DateBase.Users.RemoveRange(usersForRemoving);
                        App.DateBase.SaveChanges();
                        MessageBox.Show("Данные удалены");

                        dgAdmin.ItemsSource = App.DateBase.Users.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
