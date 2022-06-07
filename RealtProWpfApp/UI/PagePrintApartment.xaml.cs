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
    /// Логика взаимодействия для PagePrintApartment.xaml
    /// </summary>
    public partial class PagePrintApartment : Page
    {
        public PagePrintApartment()
        {
            InitializeComponent();

            var allTypes = App.DateBase.Types.ToList();
            allTypes.Insert(0, new Entities.Type
            {
                Name = "Все типы"
            });
            comboType.ItemsSource = allTypes;
            var allStatus = App.DateBase.ObjectStatus.ToList();
            allStatus.Insert(0, new Entities.ObjectStatu
            {
                Name = "Все статусы"
            });
            comboStatus.ItemsSource = allStatus;

            comboStatus.SelectedIndex = 0;

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
                UpdateApart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void UpdateApart()
        {
            var currentAparts = App.DateBase.Apartments.ToList();

            if (comboRealtor.SelectedIndex > 0)
                currentAparts = currentAparts.Where(p => p.Realtor.FullName.Contains((comboRealtor.SelectedItem as Entities.Realtor).FullName)).ToList();

            if (comboType.SelectedIndex > 0)
                currentAparts = currentAparts.Where(p => p.Type.Name.Contains((comboType.SelectedItem as Entities.Type).Name)).ToList();

            if (comboStatus.SelectedIndex > 0)
                currentAparts = currentAparts.Where(p => p.ObjectStatu.Name.Contains((comboStatus.SelectedItem as Entities.ObjectStatu).Name)).ToList();

            dgApart.ItemsSource = currentAparts;
        }
        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApart();
        }

        private void comboRealtor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApart();
        }

        private void comboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApart();
        }
    }
}
