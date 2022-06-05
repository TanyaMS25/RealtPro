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
    /// Логика взаимодействия для PagePrintClient.xaml
    /// </summary>
    public partial class PagePrintClient : Page
    {
        public PagePrintClient()
        {
            InitializeComponent();

            var allTypes = App.DateBase.Types.ToList();
            allTypes.Insert(0, new Entities.Type
            {
                Name = "Все типы"
            });
            comboType.ItemsSource = allTypes; 
            comboType.SelectedIndex = 0;

            try
            {
                UpdateClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void UpdateClient()
        {
            var currentClient = App.DateBase.Clients.Where(p => p.RealtorId == Models.Manager.realtor.Id).ToList();

            if (comboType.SelectedIndex > 0)
                currentClient = currentClient.Where(p => p.Type.Name.Contains((comboType.SelectedItem as Entities.Type).Name)).ToList();

            dgClient.ItemsSource = currentClient;
        }
        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateClient();
        }
    }
}
