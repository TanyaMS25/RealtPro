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
    /// Логика взаимодействия для PageAddEditUser.xaml
    /// </summary>
    public partial class PageAddEditUser : Page
    {
        private Entities.User _currentUser = new Entities.User();
        public PageAddEditUser(Entities.User selectedUser)
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
            {
                errors.AppendLine("Укажите логин");
                tbLogin.BorderBrush = Brushes.Red;
            }
            else tbLogin.BorderBrush = Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
            {
                errors.AppendLine("Укажите пароль");
                tbPassword.BorderBrush = Brushes.Red;
            }
            else tbPassword.BorderBrush = Brushes.Gray;
            if (ClassLibraryPasswordValidation.PasswordCheck.CheckPassword(_currentUser.Password))
            {
                errors.AppendLine("Пароль не соответствует требованиям корректности: длина от 6 до 50 символов, состав только из букв + цифр");
                tbPassword.BorderBrush = Brushes.Red;
            }
            else tbPassword.BorderBrush = Brushes.Gray;
            if (_currentUser.Login.Length < 6 || _currentUser.Login.Length > 50)
            {
                errors.AppendLine("Длина логина должна быть от 6 до 50 символов");
                tbLogin.BorderBrush = Brushes.Red;
            }
            else tbLogin.BorderBrush = Brushes.Gray;
            if (!_currentUser.Login.Any(Char.IsLetter))
            {
                errors.AppendLine("В логине должны быть буквы");
                tbLogin.BorderBrush = Brushes.Red;
            }
            else tbLogin.BorderBrush = Brushes.Gray;
            if (_currentUser.Login.Intersect("#$%^&_№:").Count() > 0)
            {
                errors.AppendLine("Введите логин только при помощи букв (символы: #$%^&_№: не допустимы)");
                tbLogin.BorderBrush = Brushes.Red;
            }
            else tbLogin.BorderBrush = Brushes.Gray;
            if (_currentUser.Role == null)
            {
                errors.AppendLine("Укажите роль");
                ComboRole.BorderBrush = Brushes.Red;
            }
            else ComboRole.BorderBrush = Brushes.Gray;
            if (_currentUser.Activate == null)
            {
                errors.AppendLine("Укажите активацию");
                ComboActivate.BorderBrush = Brushes.Red;
            }
            else ComboActivate.BorderBrush = Brushes.Gray;

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
