using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TipCalculatorUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Tip tip;

        public MainPage()
        {
            this.InitializeComponent();

            tip = new Tip();
        }

        private void billAmountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void billAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO FIX THIS

            performCalculation();
        }

        private void billAmountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void amountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = tip.BillAmount;
        }

        private void amountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = "";
        }

        private void performCalculation()
        {
            var selectedRadio = myStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            //Debug.WriteLine(selectedRadio.Tag.ToString());

            var tagTipPercentage = double.Parse(selectedRadio.Tag.ToString(), CultureInfo.InvariantCulture);

            //Debug.WriteLine(tagTipPercentage);

            tip.CalculateTip(billAmountTextBox.Text, tagTipPercentage);

            amountToTipTextBlock.Text = tip.TipAmount;
            totalTextBlock.Text = tip.TotalAmount;
        }
    }
}
