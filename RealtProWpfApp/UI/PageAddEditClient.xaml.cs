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
    /// Логика взаимодействия для PageAddEditClient.xaml
    /// </summary>
    public partial class PageAddEditClient : Page
    {
        private Entities.Client _currentClient = new Entities.Client();
        public PageAddEditClient(Entities.Client selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                _currentClient = selectedClient;

            DataContext = _currentClient;
            comboStatus.ItemsSource = App.DateBase.ObjectStatus.ToList();
            comboType.ItemsSource = App.DateBase.Types.ToList();
            comboMoney.ItemsSource = App.DateBase.Moneys.ToList();
            comboRealtor.ItemsSource = App.DateBase.Realtors.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();


            if (string.IsNullOrWhiteSpace(_currentClient.FirstName))
            {
                errors.AppendLine("Укажите имя");
                tbFirstName.BorderBrush = Brushes.Red;
            }
            else tbFirstName.BorderBrush = Brushes.Gray;
            /*if (!_currentClient.FirstName.All(Char.IsLetter) && !string.IsNullOrWhiteSpace(_currentClient.FirstName))
            {
                errors.AppendLine("Укажите имя только буквами");
                tbFirstName.BorderBrush = Brushes.Red;
            }
            else tbFirstName.BorderBrush = null;*/
            if (string.IsNullOrWhiteSpace(_currentClient.LastName))
            {
                errors.AppendLine("Укажите фамилию");
                tbLastName.BorderBrush = Brushes.Red;
            }
            else tbLastName.BorderBrush = Brushes.Gray;
            /*if (!_currentClient.LastName.All(Char.IsLetter) && !string.IsNullOrWhiteSpace(_currentClient.LastName))
            {
                errors.AppendLine("Укажите фамилию только буквами");
                tbLastName.BorderBrush = Brushes.Red;
            }
            else tbLastName.BorderBrush = null;*/
            if (string.IsNullOrWhiteSpace(_currentClient.Patronymic))
            {
                errors.AppendLine("Укажите отчество");
                tbPatronymic.BorderBrush = Brushes.Red;
            }
            else tbPatronymic.BorderBrush = Brushes.Gray;
            /*if (!_currentClient.Patronymic.All(Char.IsLetter) && !string.IsNullOrWhiteSpace(_currentClient.Patronymic))
            {
                errors.AppendLine("Укажите отчество только буквами");
                tbPatronymic.BorderBrush = Brushes.Red;
            }
            else tbPatronymic.BorderBrush = null;*/
            if (string.IsNullOrWhiteSpace(_currentClient.Phone))
            {
                errors.AppendLine("Укажите номер телефона");
                tbPhone.BorderBrush = Brushes.Red;
            }
            else tbPhone.BorderBrush = Brushes.Gray;
            if (_currentClient.ObjectStatu == null)
            {
                errors.AppendLine("Укажите статус");
                comboStatus.BorderBrush = Brushes.Red;
            }
            else comboStatus.BorderBrush = Brushes.Gray;
            if (_currentClient.Type == null)
            {
                errors.AppendLine("Укажите тип клиента");
                comboType.BorderBrush = Brushes.Red;
            }
            else comboType.BorderBrush = Brushes.Gray;
            if (_currentClient.Money == null)
            {
                errors.AppendLine("Укажите источник денег");
                comboMoney.BorderBrush = Brushes.Red;
            }
            else comboMoney.BorderBrush = Brushes.Gray;
            if (_currentClient.Realtor == null)
            {
                errors.AppendLine("Укажите риелтора");
                comboRealtor.BorderBrush = Brushes.Red;
            }
            else comboRealtor.BorderBrush = Brushes.Gray;
            if (_currentClient.StartDate == null)
            {
                errors.AppendLine("Укажите дату начала работы");
                datePickerStart.BorderBrush = Brushes.Red;
            }
            else datePickerStart.BorderBrush = Brushes.Gray;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClient.Id == 0)
                App.DateBase.Clients.Add(_currentClient);

            try
            {
                App.DateBase.SaveChanges();
                MessageBox.Show("Информация сохранена");
                Models.Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
