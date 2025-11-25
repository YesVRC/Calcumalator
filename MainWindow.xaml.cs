using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calcumalator
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        private Random rand = new();
        private bool wasRandom = false;
        private double lastResult = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text = "";
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += " / ";
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += " * ";
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += " - ";
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "7";
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "8";
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "9";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += " + ";
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "4";
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "5";
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "6";
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "1";
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "2";
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "3";
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            double result = Convert.ToDouble(new DataTable().Compute(OutputText.Text, null));
            if (wasRandom)
            {
                result = lastResult;
                wasRandom = false;
            }
            if (rand.Next(1000) > 950)
            {
                lastResult = result;
                wasRandom = true;
                result = rand.NextDouble() * (result * 1.1 - result * .9) + result * .9;
            }
            OutputText.Text = result.ToString(); 
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += "0";
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text += ".";
        }

        private void OutputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OutputText.Text.Contains("67"))
            {
                AppNotification notification = new AppNotificationBuilder()
                    .AddText("Brainrot Detected")
                    .AddText("You may not")
                    .BuildNotification();

                AppNotificationManager.Default.Show(notification);
                App.Current.Exit();
            }
        }
    }
}
