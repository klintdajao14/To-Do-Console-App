using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_Console_App
{
     class user
    {
        private string userName;
        private string passWord;
        private int userId;

        private static int lastAssignedId = 0;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return userName;}
            set
            {
                if (value != null) {
                    userName = value;
                 }
                else
                Console.WriteLine("Error");
            }
        }
        public string Password
        {
            get { return passWord;}
            set { passWord = value; }
        }
        public user(string username, string password)
        {
            UserId = ++lastAssignedId;
            userName = username;
            passWord = password;
        }   
    }
}
