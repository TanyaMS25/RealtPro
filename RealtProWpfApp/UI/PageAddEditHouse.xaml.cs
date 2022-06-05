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
    /// Логика взаимодействия для PageAddEditHouse.xaml
    /// </summary>
    public partial class PageAddEditHouse : Page
    {
        private byte[] imageHouse;
        private Entities.House _currentHouse = new Entities.House();
        public PageAddEditHouse(Entities.House selectedHouse)
        {
            InitializeComponent();

            if (selectedHouse != null)
            {
                _currentHouse = selectedHouse;

                if (selectedHouse.RealtorId != Models.Manager.realtor.Id)
                {
                    btnSave.IsEnabled = false;
                    tbNamePage.Text = "Информационная страница дома (просмотр)";
                }
                if (selectedHouse.RealtorId == Models.Manager.realtor.Id)
                {
                    tbNamePage.Text = "Информационная страница дома (редактирование/просмотр)";
                }
            }
                

            DataContext = _currentHouse;

            ComboAdOwner.ItemsSource = App.DateBase.AdOwners.ToList();
            ComboGasSupply.ItemsSource = App.DateBase.GasSupplies.ToList();
            ComboHeating.ItemsSource = App.DateBase.Heatings.ToList();
            ComboDeveloper.ItemsSource = App.DateBase.Developers.ToList();
            ComboSewerage.ItemsSource = App.DateBase.Sewerages.ToList();
            ComboMarket.ItemsSource = App.DateBase.Markets.ToList();
            ComboMaterial.ItemsSource = App.DateBase.Materials.ToList();
            ComboRealtor.ItemsSource = App.DateBase.Realtors.ToList();
            ComboType.ItemsSource = App.DateBase.Types.ToList();
            ComboClient.ItemsSource = App.DateBase.Clients.ToList();
            ComboObjectStatu.ItemsSource = App.DateBase.ObjectStatus.ToList();
            ComboWaterSupply.ItemsSource = App.DateBase.WaterSupplies.ToList();
            ComboBathroom.ItemsSource = App.DateBase.Bathrooms.ToList();

            
            if (selectedHouse == null)
            {
                tbNamePage.Text = "Информационная страница дома (добавление)";
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentHouse.MainImage != null)
            {
                ImgHouse.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_currentHouse.MainImage);
            }


            if (string.IsNullOrWhiteSpace(_currentHouse.District))
            {
                errors.AppendLine("укажите район");
                tbDistrict.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbDistrict.BorderBrush = System.Windows.Media.Brushes.Gray;
            /*if ((_currentHouse.District.Intersect("#$%^&_№:123456789").Count() > 0) && (!string.IsNullOrEmpty(tbDistrict.Text)))
            {
                errors.AppendLine("укажите район только буквами");
                tbDistrict.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbDistrict.BorderBrush = null;*/
            if (string.IsNullOrWhiteSpace(_currentHouse.Street))
            {
                errors.AppendLine("укажите улицу");
                tbStreet.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbStreet.BorderBrush = System.Windows.Media.Brushes.Gray;
            /*if (_currentHouse.Street.Any(Char.IsDigit) && !string.IsNullOrWhiteSpace(_currentHouse.Street))
            {
                errors.AppendLine("укажите улицу только буквами");
                tbStreet.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbStreet.BorderBrush = null;*/
            if (string.IsNullOrWhiteSpace(_currentHouse.House1))
            {
                errors.AppendLine("укажите дом");
                tbHouse.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbHouse.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.KitchenArea))
            {
                errors.AppendLine("укажите площадь кухни");
                tbKitchAr.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbKitchAr.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.NumberOfFloors))
            {
                errors.AppendLine("укажите количество этажей");
                tbNOFloors.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbNOFloors.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.TotalArea))
            {
                errors.AppendLine("укажите площадь");
                tbTotAr.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbTotAr.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.LivingSpace))
            {
                errors.AppendLine("укажите жилую площадь");
                tbLivSpace.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbLivSpace.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.NumberOfRooms))
            {
                errors.AppendLine("укажите количестов комнат");
                tbNumbOfRooms.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbNumbOfRooms.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Bathroom == null)
            {
                errors.AppendLine("Укажите вид ванной");
                ComboBathroom.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboBathroom.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Market == null)
            {
                errors.AppendLine("Укажите рынок");
                ComboMarket.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboMarket.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.YearOfConstruction.ToString()) || _currentHouse.YearOfConstruction==0)
            {
                errors.AppendLine("укажите год постройки");
                tbYearOfConstruction.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbYearOfConstruction.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Material == null)
            {
                errors.AppendLine("Укажите материал постройки");
                ComboMaterial.BorderBrush = System.Windows.Media.Brushes.Red;
                ComboMaterial.Background = System.Windows.Media.Brushes.Red;
            }
            else ComboMaterial.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.AdOwner == null)
            {
                errors.AppendLine("Укажите владельа объявления");
                ComboAdOwner.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboAdOwner.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.Price.ToString()) || _currentHouse.Price == 0)
            {
                errors.AppendLine("укажите цену");
                tbPrice.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbPrice.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.KitchenArea))
            {
                errors.AppendLine("укажите площадь кухни");
                tbKitchAr.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbKitchAr.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (string.IsNullOrWhiteSpace(_currentHouse.LandArea))
            {
                errors.AppendLine("укажите площадь участка");
                tbLandAr.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else tbLandAr.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Sewerage == null)
            {
                errors.AppendLine("Укажите канализацию");
                ComboSewerage.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboSewerage.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.WaterSupply == null)
            {
                errors.AppendLine("Укажите водоснабжение");
                ComboWaterSupply.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboWaterSupply.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Heating == null)
            {
                errors.AppendLine("Укажите отопление");
                ComboHeating.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboHeating.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.GasSupply == null)
            {
                errors.AppendLine("Укажите газоснобжение");
                ComboGasSupply.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboGasSupply.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Type == null)
            {
                errors.AppendLine("Укажите тип объекта");
                ComboType.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboType.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Realtor == null)
            {
                errors.AppendLine("Укажите риелтора");
                ComboRealtor.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboRealtor.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.ObjectStatu == null)
            {
                errors.AppendLine("Укажите статус объекта");
                ComboObjectStatu.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboObjectStatu.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.Client == null)
            {
                errors.AppendLine("Укажите клиента");
                ComboClient.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else ComboObjectStatu.BorderBrush = System.Windows.Media.Brushes.Gray;
            if (_currentHouse.StartDate == null)
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
            if (_currentHouse.Id == 0)
                App.DateBase.Houses.Add(_currentHouse);
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
                imageHouse = File.ReadAllBytes(fileDialog.FileName);
                ImgHouse.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(imageHouse);
                _currentHouse.MainImage = imageHouse;
            }
        }
    }
}
