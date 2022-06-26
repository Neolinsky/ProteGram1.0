using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ProteGram
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    /// 
 
    public partial class LogIn : Window
    {
        public static string  PhoneNumber;
        public static string? Password;
        
        public LogIn()
        {
            InitializeComponent();
        }

        #region moving, closing, minimizing and maximizing Log in window.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {

            if(Phone_Number_Field.Text == String.Empty || Phone_Number_Field.Text == "Enter your phone number")
            {
                MessageBox.Show("Please Enter your phone number");
            }
            else
            {
                PhoneNumber = this.Phone_Number_Field.Text.ToString();
            }

            if (Password_Field.Password.ToString() == "Enter your Password if needed")
            {
                MessageBox.Show("Please Enter your phone number");
            }
            else
            {
                Password = this.Password_Field.Password.ToString();
            }

            Window ConfCodeWIndow = new codeConfWindow();
            ConfCodeWIndow.ShowDialog();

            // It waits for user to log in.
            while(!MainWindow.LogedIn){
                Thread.Sleep(100);
            };

            // And when user is finally logged in this window closes on it's own.
            this.Close();
        }
    }
}
