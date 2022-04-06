using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;

namespace ProteGram.MVVM.Model
{
     class ContactModel
    {
        public string Username { get; set; }
        public User User { get; set; }
        public long UserID   { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public TL.UserProfilePhoto ImageSource { get; set; } 
        public ObservableCollection<MessageModel>? Messages { get; set; }

        //public string? LastMessage => Messages.Last().Message;
    }
}
