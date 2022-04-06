using ProteGram.Core;
using ProteGram.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TL;

namespace ProteGram.MVVM.ViewModel
{
     class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        public TL.Messages_Dialogs Dialogs;

        /* Commands */

        public RellayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value;
                OnPropertyChanged();
            }
        }


        public async Task GetDialogs()
        {
            Dialogs = await MainWindow.cl.client.Messages_GetAllDialogs();

            foreach (var (id, user) in Dialogs.users)
            {
                //var messages = await MainWindow.cl.client.Messages_GetHistory(user.ToInputPeer(),-5);
                //foreach (var msg in messages.Messages)
                //{
                //    //if(msg is Message ms)
                //    //{
                //    //    Messages.Add(new MessageModel
                //    //    {
                //    //        Username = user.username,
                //    //        UsernameColor = "#4098ff",
                //    //        ImageSource = user.photo,
                //    //        Message = ms.message,
                //    //        Time = msg.Date,
                //    //        IsNativeOrigin = msg.ID != MainWindow.cl.my.ID ? false : true,
                //    //        FirstMessage = false
                //    //    });
                        
                //    //}

                    
                //}

                Contacts.Add(new ContactModel
                {
                    first_name = user.first_name,
                    User = user,
                    UserID = user.ID,
                    last_name = user.last_name,
                    Username = user.username,
                    ImageSource = user.photo,
                    Messages = Messages

                });
            }

        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;  OnPropertyChanged();
            }
        }


        
         
        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RellayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

              MainWindow.cl.client.SendMessageAsync(SelectedContact.User.ToInputPeer(), Message);
            });


            GetDialogs();

            #region letItBeHereForAWail
            //Messages.Add(new MessageModel
            //{
            //    Username = "Allison",
            //    UsernameColor = "#4098ff",
            //    ImageSource = "https://i.pinimg.com/236x/33/2f/51/332f51d65b03fa74d9c6c785244d5dd8.jpg",
            //    Message = "Test message",
            //    Time = DateTime.Now,
            //    IsNativeOrigin = false,
            //    FirstMessage = true
            //});


            //for(int i = 0; i < 3; i++)
            //{
            //    Messages.Add(new MessageModel
            //    {
            //        Username = "Allison",
            //        UsernameColor = "#4098ff",
            //        ImageSource = "https://i.pinimg.com/236x/33/2f/51/332f51d65b03fa74d9c6c785244d5dd8.jpg",
            //        Message = "Test message" + i,
            //        Time = DateTime.Now,
            //        IsNativeOrigin = false,
            //        FirstMessage = true
            //    });
            //}


            //for (int i = 0; i < 4; i++)
            //{
            //    Messages.Add(new MessageModel
            //    {
            //        Username = "Bunny",
            //        UsernameColor = "#4098ff",
            //         ImageSource = "https://i.imgur.com/DVJcEE3.jpeg",
            //        Message = "Test message" + i,
            //        Time = DateTime.Now,
            //        IsNativeOrigin = true,
            //        FirstMessage = false
            //    });
            //}

            //Messages.Add(new MessageModel
            //{
            //    Username = "Bunny",
            //    UsernameColor = "#4098ff",
            //    ImageSource = "https://i.imgur.com/DVJcEE3.jpeg",
            //    Message = "Last",
            //    Time = DateTime.Now,
            //    IsNativeOrigin = true,
            //    FirstMessage = true
            //}); 

            //for (int i = 0; i < 5; i++)
            //{
            //    Contacts.Add(new ContactModel
            //    {
            //        Username = $"Allison {i}",
            //        Messages = Messages
            //    });
            //}
            #endregion

        }
    }
}
