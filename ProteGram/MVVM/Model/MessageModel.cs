using System;
using TL;

namespace ProteGram.MVVM.Model
{
    class MessageModel
    {
        public string Username { get; set; }
        public string UsernameColor { get; set; }
        public TL.UserProfilePhoto ImageSource { get; set; }
        public string Message { get; set; }
        public Messages_MessagesBase? messageBase { get; set; }
        public DateTime Time { get; set; }
        public bool IsNativeOrigin { get; set; }
        public bool? FirstMessage { get; set; }
    }
}
