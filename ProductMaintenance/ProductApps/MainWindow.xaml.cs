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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;
        private const decimal DeliveryCharge = 25m;
        private const decimal WrapCharge = 5m;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));

                    cProduct.calTotalPayment();
                    totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

                    decimal totalCharge = cProduct.TotalPayment + DeliveryCharge;
                    totalChargeTextBlock.Text = Convert.ToString(totalCharge);

                    decimal wrapTotalCharge = cProduct.TotalPayment + DeliveryCharge + WrapCharge;
                    wrapChargeTextBlock.Text = Convert.ToString(wrapTotalCharge);

                    decimal gstTotalCharge = wrapTotalCharge * 1.1m;
                    gstChargeTextBlock.Text = Convert.ToString(gstTotalCharge);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBlock.Text = "";
            totalChargeTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
