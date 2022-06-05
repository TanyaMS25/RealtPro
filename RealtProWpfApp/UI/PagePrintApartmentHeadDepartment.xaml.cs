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
    /// Логика взаимодействия для PagePrintApartmentHeadDepartment.xaml
    /// </summary>
    public partial class PagePrintApartmentHeadDepartment : Page
    {
        public PagePrintApartmentHeadDepartment()
        {
            InitializeComponent();

            var allRealtors = App.DateBase.Realtors.ToList();
            allRealtors.Insert(0, new Entities.Realtor
            {
                LastName = "Все риелторы"
            });
            comboRealtor.ItemsSource = allRealtors;
            comboRealtor.SelectedIndex = 0;

            try
            {
                UpdateApart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        private void UpdateApart()
        {
            var currentAparts = App.DateBase.Apartments.Where(p => p.Realtor.OfficeId == Models.Manager.headOfSales.Id).ToList();

            if(comboRealtor.SelectedIndex>0)
                currentAparts = currentAparts.Where(p=>p.Realtor.LastName.Contains((comboRealtor.SelectedItem as Entities.Realtor).LastName)).ToList();

            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                try
                {
                    currentAparts = currentAparts.Where(p =>
                         p.District.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.House.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Realtor.LastName.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Realtor.FirstName.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Street.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
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
                    currentAparts = currentAparts;
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            dgApart.ItemsSource = currentAparts;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateApart();
        }

        private void comboRealtor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApart();
        }
    }
}
