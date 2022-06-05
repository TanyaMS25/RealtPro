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
    /// Логика взаимодействия для PageUserData.xaml
    /// </summary>
    public partial class PageUserData : Page
    {
        private Entities.User _currentUser = new Entities.User();
        public PageUserData(Entities.User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
                _currentUser = selectedUser;

            DataContext = _currentUser;

            ComboRole.ItemsSource = App.DateBase.Roles.ToList();
            ComboActivate.ItemsSource = App.DateBase.Activates.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Укажите пароль");
            if (ClassLibraryPasswordValidation.PasswordCheck.CheckPassword(_currentUser.Password)==false)
                errors.AppendLine("Пароль не соответствует требованиям корректности: длина от 6 до 50 символов, состав только из букв + цифр");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentUser.Id == 0)
                App.DateBase.Users.Add(_currentUser);
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
