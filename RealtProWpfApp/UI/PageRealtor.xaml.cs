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
    /// Логика взаимодействия для PageRealtor.xaml
    /// </summary>
    public partial class PageRealtor : Page
    {
        public PageRealtor()
        {
            InitializeComponent();
        }

        private void btnCalculation_Click(object sender, RoutedEventArgs e)
        {
            if (tbPrice.Text.Length == 0)
            {
                MessageBox.Show("Введите цену объекта");
            }
            if (tbPrice.Text.Any(Char.IsLetter))
            {
                MessageBox.Show("Введите цену объекта только при помощи цифр");
            }
            try
            {
                double price = Convert.ToDouble(tbPrice.Text);
                double profit = ClassLibraryCalculation.CommissionCalculation.CalculationCommission(price, 0);
                tBlockProfit.Text = Convert.ToString(profit) + " руб.";
                double levelCommission = Convert.ToDouble(Models.Manager.realtor.Level.CommissionPercentage);
                tBlockCommission.Text = Convert.ToString(profit* levelCommission) + " руб.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            if (tbPrice.Text.Length > 50)
            {
                tBlockCommission.Text = " ";
                tBlockProfit.Text = " ";
                MessageBox.Show("В поле для ввода не должно быть больше 50 символов");
            }
            try
            {
                if (Convert.ToDouble(tbPrice.Text) < 200000)
                {
                    tBlockCommission.Text = "";
                    tBlockProfit.Text = " ";
                    MessageBox.Show("Стоимость объекта не может быть меньше 200 тыс. руб.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            try
            {
                if (Convert.ToDouble(tbPrice.Text) > 500000000)
                {
                    tBlockCommission.Text = "";
                    tBlockProfit.Text = " ";
                    MessageBox.Show("Стоимость объекта не может быть больше 500 млн. руб.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            try
            {
                if (tbPrice.Text.Intersect("#$%^&_№:").Count() > 0)
                {
                    tBlockCommission.Text = "";
                    tBlockProfit.Text = " ";
                    MessageBox.Show("Введите цену объекта только при помощи цифр (символы: #$%^&_ не допустимы)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            try
            {
                if (tbPrice.Text.Intersect(".").Count() > 0)
                {
                    tBlockCommission.Text = "";
                    tBlockProfit.Text = " ";
                    MessageBox.Show("Используйте <<,>> вместо <<.>>");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
