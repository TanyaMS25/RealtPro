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
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        public PageClient()
        {
            InitializeComponent();

            var allTypes = App.DateBase.Types.ToList();
            allTypes.Insert(0, new Entities.Type
            {
                Name = "Все типы"
            });

            var allStatus = App.DateBase.ObjectStatus.ToList();
            allStatus.Insert(0, new Entities.ObjectStatu
            {
                Name = "Все статусы"
            });
            comboStatus.ItemsSource = allStatus;

            comboStatus.SelectedIndex = 0;
            comboType.ItemsSource = allTypes;
            comboType.SelectedIndex = 0;
        }
        private void UpdateClient()
        {
            var currentClient = App.DateBase.Clients.Where(p => p.RealtorId == Models.Manager.realtor.Id).ToList();
            if (comboType.SelectedIndex > 0)
                currentClient = currentClient.Where(p => p.Type.Name.Contains((comboType.SelectedItem as Entities.Type).Name)).ToList();

            if (comboStatus.SelectedIndex > 0)
                currentClient = currentClient.Where(p => p.ObjectStatu.Name.Contains((comboStatus.SelectedItem as Entities.ObjectStatu).Name)).ToList();

            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                try
                {
                    currentClient = currentClient.Where(p =>                   
                         p.FirstName.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.LastName.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Patronymic.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Notes.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
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
                    currentClient = currentClient;        
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (currentClient.Count == 0)
            {
                tbInfoDG.Text = "Данный список пуст";
            }
            else if (lViewClient.Items.Count != 0)
            {
                tbInfoDG.Text = "";
                tbInfoDG.Visibility = Visibility.Collapsed;
            }
            lViewClient.ItemsSource = currentClient;
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClient();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditClient(null));
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = lViewClient.SelectedItems.Cast<Entities.Client>().ToList();
            if (clientForRemoving.Count != 0)
            {

                if (MessageBox.Show($"Вы точно хотите удалить следующие {clientForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        App.DateBase.Clients.RemoveRange(clientForRemoving);
                        App.DateBase.SaveChanges();
                        MessageBox.Show("Данные удалены");

                        UpdateClient();
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    UpdateClient();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditClient((sender as Button).DataContext as Entities.Client));
        }

        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateClient();
        }

        private void comboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateClient();
        }
    }
}
