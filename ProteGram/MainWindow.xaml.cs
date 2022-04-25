using ProteGram.Core;
using ProteGram.MVVM.Model;
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
using TL;

namespace ProteGram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 
    public partial class MainWindow : Window
    {
        
        public static readonly Dictionary<long, User> Users = new();
        public static readonly Dictionary<long, ChatBase> Chats = new();
        public static TextBox msField;
        public static ListView myLisview;

        // don't need no explanation.
        public static bool LogedIn = false;

        // Here I create an instance of Telegram Client, but don't initiolize it yet.
        public static TClient cl = new TClient();
        // I use it to store messages in here.
        public  static Messages_MessagesBase Msgbase;
        private static ContactModel? selectedContact;

        public  MainWindow()
        {
            // First log in window has to be loaded ( I really will have to work on this one later on cuz it works like crap).
            Window LoginWindnow = new LogIn();
            LoginWindnow.ShowDialog();

            // After user loged in we initiolize main window components
            InitializeComponent();
            // If we are not loged in, this will crash my program.
            UserNameLabel.Content = $"{cl.my.first_name.ToString()}";
            MainWindow.cl.client.Update += Client_Update;
            msField = MessageField;
            myLisview = ListViewDialogs;
        }

        private static async void Client_Update(IObject arg)
        {
            if (arg is not UpdatesBase updates) return;
            updates.CollectUsersChats(Users, Chats);
            foreach (var update in updates.UpdateList)
                switch (update)
                {
                    case UpdateNewMessage unm:
                        if (selectedContact != null)
                        {
                            RefreshMessages();
                        }
                     break;                 
                }
        }

        public static async Task RefreshMessages()
        {
            selectedContact.Messages.Clear();

            // Then we load the new ones in Msgbase.
            Msgbase = await cl.client.Messages_GetHistory(selectedContact.User.ToInputPeer());



            // Then we go throug each one message model in Msgbase, but in reverse order.
            foreach (var msg in Msgbase.Messages.Reverse())
            {
                // If message model is message and not an image or gif for example, we add  the message to selectdContact.Messages
                if (msg is Message ms)
                {
                    selectedContact.Messages.Add(new MessageModel
                    {
                        Username = selectedContact.User.username,
                        UsernameColor = "#4098ff",
                        ImageSource = selectedContact.User.photo,
                        Message = ms.message,
                        Time = ms.date,
                        IsNativeOrigin = ms.id != cl.my.id ? false : true,
                        FirstMessage = false
                    });
                    Decorator border = VisualTreeHelper.GetChild(MainWindow.myLisview, 0) as Decorator;
                    ScrollViewer scrollViewer = border.Child as ScrollViewer;
                    scrollViewer.ScrollToEnd();

                }
            }
        }

        /// <summary>
        /// Here we add drag and move to Main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();  
            }
        }

        /// <summary>
      /// This one is Maximizing and normolizing window.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        /// <summary>
        /// Minimizing the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Closing the winodow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// We have no use for this one, but let it be here for a while, i will change it later on. probobly just delet it, or will change 
        /// it's purpose for example, it won't be loggin us in, but will log us out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window LoginWindnow = new LogIn();
            LoginWindnow.ShowDialog();
        }


        /// <summary>
        /// This one is a little bit complex. It detects SelectionChanged event on our contacts list. And loads the dialog with the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = ContactsListView.SelectedItem as ContactModel;

            // Here we change content of user tg that you chat with.
            UserYouChatWith.Content = selectedContact.User.first_name;

            // First when u changed contat you are trying to chat with, we need to clear all the messages  that were here  before.
            selectedContact.Messages.Clear();
            
            // Then we load the new ones in Msgbase.
            Msgbase = await cl.client.Messages_GetHistory(selectedContact.User.ToInputPeer());

            

            // Then we go throug each one message model in Msgbase, but in reverse order.
            foreach (var msg in Msgbase.Messages.Reverse())
            {
                // If message model is message and not an image or gif for example, we add  the message to selectdContact.Messages
                if (msg is Message ms)
                {
                   selectedContact.Messages.Add(new MessageModel
                    {
                        Username = selectedContact.User.username,
                        UsernameColor = "#4098ff",
                        ImageSource = selectedContact.User.photo,
                        Message = ms.message,
                        Time = ms.date,
                        IsNativeOrigin = ms.id != cl.my.id ? false : true,
                        FirstMessage = false
                    });

                }
            }
        }
    }
}
