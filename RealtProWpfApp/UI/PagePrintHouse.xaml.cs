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
    /// Логика взаимодействия для PagePrintHouse.xaml
    /// </summary>
    public partial class PagePrintHouse : Page
    {
        public PagePrintHouse()
        {
            InitializeComponent();
            var allTypes = App.DateBase.Types.ToList();
            allTypes.Insert(0, new Entities.Type
            {
                Name = "Все типы"
            });
            comboType.ItemsSource = allTypes;

            var allRealtors = App.DateBase.Realtors.ToList();
            allRealtors.Insert(0, new Entities.Realtor
            {
                LastName = "Все риелторы"
            });
            comboRealtor.ItemsSource = allRealtors;

            comboRealtor.SelectedIndex = 0;
            comboType.SelectedIndex = 0;

            try
            {
                UpdateHouse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void UpdateHouse()
        {
            var currentHouse = App.DateBase.Houses.ToList();

            if (comboRealtor.SelectedIndex > 0)
                currentHouse = currentHouse.Where(p => p.Realtor.FullName.Contains((comboRealtor.SelectedItem as Entities.Realtor).FullName)).ToList();

            if (comboType.SelectedIndex > 0)
                currentHouse = currentHouse.Where(p => p.Type.Name.Contains((comboType.SelectedItem as Entities.Type).Name)).ToList();

            dgHouse.ItemsSource = currentHouse;
        }
        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateHouse();
        }

        private void comboRealtor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateHouse();
        }
    }
}
