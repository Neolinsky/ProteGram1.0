using ProteGram.Core;
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
using System.Windows.Shapes;
using TL;

namespace ProteGram
{
    /// <summary>
    /// Interaction logic for codeConfWindow.xaml
    /// </summary>
    public partial class codeConfWindow : Window
    {

        public static string confCode;
        
        // Here we authorize our Telegram client with the phone number we got from Log in window.
        public codeConfWindow()
        {
            MainWindow.cl.client = new WTelegram.Client(TClient.Config);
            var code = GetCode();

            InitializeComponent();
        }
        
        public async Task GetCode()
        {
            MainWindow.cl.my = await MainWindow.cl.client.LoginUserIfNeeded();
            
            if (MainWindow.cl.my != null)
            {
                MainWindow.LogedIn = true;
                MainWindow.Users[MainWindow.cl.my.id] = MainWindow.cl.my;

                this.Close();
            }
        }
        
        private void  LogInButton_Click(object sender, RoutedEventArgs e)
        {
          confCode  = this.Conf_CodeField.Text.ToString();
           GetCode();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
