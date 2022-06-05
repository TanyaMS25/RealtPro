using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using System.Drawing;

namespace RealtProWpfApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageAddEditApartment.xaml
    /// </summary>
    public partial class PageAddEditApartment : Page
    {
        private byte[] imageApart;
        private Entities.Apartment _currentApart = new Entities.Apartment();
        public PageAddEditApartment(Entities.Apartment selectedApart)
        {
            InitializeComponent();

            if (selectedApart != null)
            {
                _currentApart = selectedApart;

                if (selectedApart.RealtorId != Models.Manager.realtor.Id)
                {
                    btnSave.IsEnabled = false;
                    tbNamePage.Text = "Информационная страница квартиры (просмотр)";
                }
                if (selectedApart.RealtorId == Models.Manager.realtor.Id)
                {
                    tbNamePage.Text = "Информационная страница квартиры (редактирование/просмотр)";
                }
            }
                

            DataContext = _currentApart;

            ComboAdOwner.ItemsSource = App.DateBase.AdOwners.ToList();
            ComboBalcony.ItemsSource = App.DateBase.Balconies.ToList();
            ComboBath.ItemsSource = App.DateBase.Bathrooms.ToList();
            ComboDeveloper.ItemsSource = App.DateBase.Developers.ToList();
            ComboLayout.ItemsSource = App.DateBase.Layouts.ToList();
            ComboMarket.ItemsSource = App.DateBase.Markets.ToList();
            ComboMaterial.ItemsSource = App.DateBase.Materials.ToList();
            ComboRealtor.ItemsSource = App.DateBase.Realtors.ToList();
            ComboType.ItemsSource = App.DateBase.Types.ToList();
            ComboClient.ItemsSource = App.DateBase.Clients.ToList();
            ComboObjectStatu.ItemsSource = App.DateBase.ObjectStatus.ToList();

            if (selectedApart == null)
            {
                tbNamePage.Text = "Информационная страница квартиры (добавление)";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentApart.MainImage != null)
            {
                ImgApart.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_currentApart.MainImage);
            }

            if (string.IsNullOrWhiteSpace(_currentApart.District))
            {
                errors.AppendLine("укажите район");
                tbDistrict.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbDistrict.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.Street))
            {
                errors.AppendLine("укажите улицу");
                tbStreet.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbStreet.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.House))
            {
                errors.AppendLine("укажите дом");
                tbHouse.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbHouse.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.Floor))
            {
                errors.AppendLine("укажите этаж");
                tbFloor.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbFloor.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.NumberOfFloors))
            {
                errors.AppendLine("укажите количество этажей");
                tbNOFloors.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbNOFloors.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.TotalArea))
            {
                errors.AppendLine("укажите площадь");
                tbTotAr.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbTotAr.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.LivingSpace))
            {
                errors.AppendLine("укажите жилую площадь");
                tbLivSpace.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbLivSpace.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.NumberOfRooms))
            {
                errors.AppendLine("укажите количестов комнат");
                tbNumbOfRooms.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbNumbOfRooms.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Balcony1 == null)
            {
                errors.AppendLine("Укажите наличие балкона");
                ComboBalcony.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboBalcony.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Bathroom == null)
            {
                errors.AppendLine("Укажите вид ванной");
                ComboBath.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboBath.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Market == null)
            {
                errors.AppendLine("Укажите рынок");
                ComboMarket.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboMarket.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentApart.YearOfConstruction.ToString()) || _currentApart.YearOfConstruction == 0)
            {
                errors.AppendLine("укажите год постройки");
                tbYearOfConstruction.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbYearOfConstruction.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Material == null)
            {
                errors.AppendLine("Укажите материал постройки");
                ComboMaterial.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboMaterial.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Layout == null)
            {
                errors.AppendLine("Укажите планировку");
                ComboLayout.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboLayout.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.AdOwner == null)
            {
                errors.AppendLine("Укажите владельа объявления");
                ComboAdOwner.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboAdOwner.BorderBrush = null;
            if (string.IsNullOrWhiteSpace(_currentApart.Price.ToString()) || _currentApart.YearOfConstruction == 0)
            {
                errors.AppendLine("укажите цену");
                tbPrice.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbPrice.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Type == null)
            {
                errors.AppendLine("Укажите тип объекта");
                ComboType.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboType.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Realtor == null)
            {
                errors.AppendLine("Укажите риелтора");
                ComboRealtor.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboRealtor.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.ObjectStatu == null)
            {
                errors.AppendLine("Укажите статус объекта");
                ComboObjectStatu.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboObjectStatu.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.Client == null)
            {
                errors.AppendLine("Укажите клиента");
                ComboClient.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboObjectStatu.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentApart.StartDate == null)
            {
                errors.AppendLine("Укажите дату начала работы с объектом");
                datePickerStartDate.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else datePickerStartDate.BorderBrush = System.Windows.Media.Brushes.Gray;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentApart.Id == 0)
                App.DateBase.Apartments.Add(_currentApart);
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

        private void btnSelectImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.JPG, *.PNG)|*.jpg;*.png;*.jpeg";
            if (fileDialog.ShowDialog() == true)
            {
                imageApart = File.ReadAllBytes(fileDialog.FileName);
                ImgApart.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(imageApart);
                _currentApart.MainImage = imageApart;
            }
        }
    }
}
