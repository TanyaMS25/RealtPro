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
    /// Логика взаимодействия для PageAuthHistory.xaml
    /// </summary>
    public partial class PageAuthHistory : Page
    {
        public PageAuthHistory()
        {
            InitializeComponent();
            try
            {
                dgAuthHistory.ItemsSource = App.DateBase.AuthHistories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerFrom.SelectedDate != null && datePickerUntill.SelectedDate != null)
            {
                if (datePickerFrom.SelectedDate < datePickerUntill.SelectedDate)
                {
                    dgAuthHistory.ItemsSource = App.DateBase.AuthHistories.Where(p => p.Date >= datePickerFrom.SelectedDate && p.Date <= datePickerUntill.SelectedDate).ToList();
                    if (dgAuthHistory.Items.Count == 0)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Начальная дата не можеть быть меньше конечной", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else
            {
                dgAuthHistory.ItemsSource = App.DateBase.AuthHistories.ToList();
            }
        }
    }
}
