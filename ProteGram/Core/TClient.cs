using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using WTelegram;


namespace ProteGram.Core
{
    public class TClient
    {

       public WTelegram.Client client;
       public TL.User my;

        public  async Task InitiolizeClient()
        {
            client = new WTelegram.Client(Config);
            my = await client.LoginUserIfNeeded();
            
        }

        public static string Config(string what)
        {
            switch (what)
            {
                case "api_id": return "13945360";
                case "api_hash": return "b337cd75fae64423411bf1b4a0c15e43";
                case "phone_number": return LogIn.PhoneNumber; // "+79091478848"; // I will have to implement getting it from GUI
                case "verification_code": return codeConfWindow.confCode; // Same goes here
                case "password": return  LogIn.Password;     // And here
                default: return null;
            }
        }

    }
}
