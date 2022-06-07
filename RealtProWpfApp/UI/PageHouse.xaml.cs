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
    /// Логика взаимодействия для PageHouse.xaml
    /// </summary>
    public partial class PageHouse : Page
    {
        public PageHouse()
        {
            InitializeComponent();

            var allTypes = App.DateBase.Types.ToList();
            allTypes.Insert(0, new Entities.Type
            {
                Name = "Все типы"
            });
            comboType.ItemsSource = allTypes;

            var allDistrict = App.DateBase.Houses.ToList();
            allDistrict.Insert(0, new Entities.House
            {
                District = "Все районы"
            });
            comboDistrict.ItemsSource = allDistrict;

            var allRealtors = App.DateBase.Realtors.ToList();
            allRealtors.Insert(0, new Entities.Realtor
            {
                LastName = "Все риелторы"
            });
            comboRealtor.ItemsSource = allRealtors;

            var allStatus = App.DateBase.ObjectStatus.ToList();
            allStatus.Insert(0, new Entities.ObjectStatu
            {
                Name = "Все статусы"
            });
            comboStatus.ItemsSource = allStatus;

            comboRealtor.SelectedIndex = 0;
            comboDistrict.SelectedIndex = 0;
            comboType.SelectedIndex = 0;
            comboStatus.SelectedIndex = 0;
        }

        private void UpdateHouse()
        {
            var currentHouse = App.DateBase.Houses.ToList();

            if (comboType.SelectedIndex > 0)
                currentHouse = currentHouse.Where(p => p.Type.Name.Contains((comboType.SelectedItem as Entities.Type).Name)).ToList();

            if (comboRealtor.SelectedIndex > 0)
                currentHouse = currentHouse.Where(p => p.Realtor.FullName.Contains((comboRealtor.SelectedItem as Entities.Realtor).FullName)).ToList();

            if (comboStatus.SelectedIndex > 0)
                currentHouse = currentHouse.Where(p => p.ObjectStatu.Name.Contains((comboStatus.SelectedItem as Entities.ObjectStatu).Name)).ToList();

            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                try
                {
                    currentHouse = currentHouse.Where(p =>
                         p.District.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Street.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.NumberOfFloors.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.YearOfConstruction.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.House1.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Price.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
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
                    currentHouse = currentHouse;
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (comboDistrict.SelectedIndex > 0)
                currentHouse = currentHouse.Where(p => p.District.Contains((comboDistrict.SelectedItem as Entities.House).District)).ToList();



            try
            {
                if (checkComiss.IsChecked.Value)

                    currentHouse = currentHouse.Where(p =>
                             p.AgentCommission!=null).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            if (currentHouse.Count()==0)
            {
                tbInfoDG.Text = "Данный список пуст";
            }
            else
            {
                tbInfoDG.Text = "";
                tbInfoDG.Visibility = Visibility.Collapsed;
            }
            lViewHouse.ItemsSource = currentHouse;
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateHouse();
        }

        private void btnAddHouse_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditHouse(null));
        }

        private void btnDeleteHouse_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            var houseForRemoving = lViewHouse.SelectedItems.Cast<Entities.House>().ToList();
            if (houseForRemoving.Count != 0)
            {
                int index = houseForRemoving.Count - 1;
                for (int i = 0; i <= index; i++)
                {
                    if (houseForRemoving[i].RealtorId != Models.Manager.realtor.Id)
                    {
                        errors.AppendLine("Вы не можете удалять чужие объекты");
                        break;
                    }
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                else
                {
                    if (MessageBox.Show($"Вы точно хотите удалить следующие {houseForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            App.DateBase.Houses.RemoveRange(houseForRemoving);
                            App.DateBase.SaveChanges();
                            MessageBox.Show("Данные удалены");

                            UpdateHouse();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }      
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditHouse((sender as Button).DataContext as Entities.House));
        }

        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateHouse();
        }

        private void comboDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateHouse();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    UpdateHouse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void comboRealtor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateHouse();
        }

        private void checkComiss_Checked(object sender, RoutedEventArgs e)
        {
            UpdateHouse();
        }

        private void comboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateHouse();
        }
    }
}
