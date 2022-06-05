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
    /// Логика взаимодействия для PageApartment.xaml
    /// </summary>
    public partial class PageApartment : Page
    {
        public PageApartment()
        {
            InitializeComponent();

            var allTypes = App.DateBase.Types.ToList();
            allTypes.Insert(0, new Entities.Type
            {
                Name = "Все типы"
            });
            comboType.ItemsSource=allTypes;

            var allDistrict=App.DateBase.Apartments.ToList();
            allDistrict.Insert(0, new Entities.Apartment
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

            comboRealtor.SelectedIndex = 0;
            comboDistrict.SelectedIndex = 0;
            comboType.SelectedIndex = 0;
        }
        private void UpdateApartment()
        {
            var currentApart = App.DateBase.Apartments.ToList();

            if (comboType.SelectedIndex > 0)
                currentApart = currentApart.Where(p => p.Type.Name.Contains((comboType.SelectedItem as Entities.Type).Name)).ToList();

            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                try
                {
                    currentApart = currentApart.Where(p =>
                        p.District.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                        p.Street.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                        p.Floor.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                        p.YearOfConstruction.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                        p.House.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                        p.NumberOfFloors.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                        p.NumberOfRooms.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
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
                    currentApart = currentApart;
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (comboDistrict.SelectedIndex > 0)
                currentApart = currentApart.Where(p => p.District.Contains((comboDistrict.SelectedItem as Entities.Apartment).District)).ToList();

            if (comboRealtor.SelectedIndex > 0)
                currentApart = currentApart.Where(p => p.Realtor.FullName.Contains((comboRealtor.SelectedItem as Entities.Realtor).FullName)).ToList();

            lViewApart.ItemsSource = currentApart;
            if (lViewApart.Items.Count == 0)
            {
                tbInfoDG.Text = "Данный список пуст";
            }
            else
            {
                tbInfoDG.Text = "";
                tbInfoDG.Visibility = Visibility.Collapsed;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    UpdateApartment();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnDeleteApart_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            var apartForRemoving = lViewApart.SelectedItems.Cast<Entities.Apartment>().ToList();
            if (apartForRemoving.Count != 0)
            {
                    int index = apartForRemoving.Count - 1;
                    for(int i = 0; i <= index; i++)
                    {
                        if(apartForRemoving[i].RealtorId != Models.Manager.realtor.Id)
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
                        if (MessageBox.Show($"Вы точно хотите удалить следующие {apartForRemoving.Count()} элементов?", "Внимание",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                App.DateBase.Apartments.RemoveRange(apartForRemoving);
                                App.DateBase.SaveChanges();
                                MessageBox.Show("Данные удалены");

                                UpdateApartment();
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

        private void btnAddApart_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditApartment(null));
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateApartment();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Models.Manager.MainFrame.Navigate(new UI.PageAddEditApartment((sender as Button).DataContext as Entities.Apartment));
        }

        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApartment();
        }

        private void comboDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApartment();
        }

        private void comboRealtor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApartment();
        }
    }
}
