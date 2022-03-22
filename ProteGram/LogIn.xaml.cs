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
            if (this.WindowState != WindowState.Maximized)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if(Phone_Number_Field.Text.ToString() == null || Phone_Number_Field.Text == "Enter your phone number")
            {
                MessageBox.Show("Please Enter your phobe bymber");
            }
            else
            {
                PhoneNumber = this.Phone_Number_Field.Text.ToString();
            }

            if (Password_Field.Text.ToString() == "Enter your Password if needed")
            {
                MessageBox.Show("Please Enter your phobe bymber");
            }
            else
            {
                Password = this.Password_Field.Text.ToString();
            }

           Window ConfCodeWIndow = new codeConfWindow();
           ConfCodeWIndow.ShowDialog();
        }
    }
}
