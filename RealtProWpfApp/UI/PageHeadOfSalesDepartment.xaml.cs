using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealtProWpfApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageHeadOfSalesDepartment.xaml
    /// </summary>
    public partial class PageHeadOfSalesDepartment : Page
    {
        public PageHeadOfSalesDepartment()
        {
            InitializeComponent();

            var allLevels = App.DateBase.Levels.ToList();
            allLevels.Insert(0, new Entities.Level
            {
                Name = "Все уровни"
            });
            comboLevel.ItemsSource = allLevels;
            comboLevel.SelectedIndex = 0; 
            comboClosedObjects.SelectedIndex=0;
        }
        private void UpdateRealtors()
        {
            var currentRealtors = App.DateBase.Realtors.Where(p => p.OfficeId == Models.Manager.headOfSales.Id).ToList();

            if (comboLevel.SelectedIndex > 0)
                currentRealtors = currentRealtors.Where(p => p.Level.Name.Contains((comboLevel.SelectedItem as Entities.Level).Name)).ToList();

            if (comboClosedObjects.SelectedIndex == 0)
                currentRealtors = currentRealtors;

            if (comboClosedObjects.SelectedIndex == 1)
                currentRealtors = currentRealtors.OrderBy(p=>p.NumberOfClosedObjects).ToList();

            if (comboClosedObjects.SelectedIndex == 2)
                currentRealtors = currentRealtors.OrderByDescending(p => p.NumberOfClosedObjects).ToList();

            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                try
                {
                    currentRealtors = currentRealtors.Where(p =>
                         p.FirstName.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.LastName.ToString().ToLower().Contains(tbSearch.Text.ToLower()) ||
                         p.Patronymic.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();             
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
                    currentRealtors = currentRealtors;
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            

            if (currentRealtors.Count == 0)
            {
                tbInfoDG.Text = "Данный список пуст";
            }
            else
            {
                tbInfoDG.Text = "";
                tbInfoDG.Visibility = Visibility.Collapsed;
            }
            lViewRealtor.ItemsSource = currentRealtors;
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    UpdateRealtors();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateRealtors();
        }

        private void comboLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRealtors();
        }

        private void comboClosedObjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRealtors();
        }
    }
}
