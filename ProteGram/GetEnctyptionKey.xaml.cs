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

namespace ProteGram
{
    /// <summary>
    /// Логика взаимодействия для GetEnctyptionKey.xaml
    /// </summary>
    public partial class GetEnctyptionKey : Window
    {
        public GetEnctyptionKey()
        {
            InitializeComponent();
        }

        public static TextBox KeyField;
    
 
        private void Confirmkey_Click(object sender, RoutedEventArgs e)
        {
            KeyField = EncryptionKeyKield;
            if(KeyField.Text != "")
            {
                AesOperation.secret = KeyField.Text;
                MainWindow.Encryption = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Enter your Key");
            }
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
