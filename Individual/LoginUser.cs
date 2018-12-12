using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    class LoginUser
    {
        public static void Login()
        {
            string userName = "";
            string passWord = "";

            bool login = false;
            do
            {
                Console.WriteLine("#############################");
                Console.WriteLine("    L o g i n  P a g e");
                Console.WriteLine("#############################");
                Console.WriteLine();
                Console.Write("Give your Username: ");
                userName = Console.ReadLine();

                Console.Write("Give your Password: ");
                passWord = Console.ReadLine();
                login = Login(userName, passWord);
                if (!login)
                    Console.WriteLine("Invalid username or password ! Try again ...");
            }
            while (login == false);

            RoleRecognition(userName);


        }

        //ELENGXOS USERNAME - PASSWORD
        public static bool Login(string usernameInserted, string passwordInserted)
        {
            //SqlConnection con = Sql.Connection();
            bool value = false;
            bool userName = User.ValidUserName(usernameInserted);
            bool passWord = User.ValidPassword(usernameInserted, passwordInserted);
            bool match = userName && passWord;
            if (!match)
            {
                Console.WriteLine("Invalid username or password... ");
            }
            else
            {
                value = true;
            }
            return value;
        }
        
        //ANAGNORISH ROLOY
        public static void RoleRecognition(string userName)
        {

            Role role = User.UserRole(userName);



            switch (role)
            {
                case Role.SimpleMember:
                    ApplicationMenu.SimpleMenuMessages(userName);
                    break;
                case Role.GoldMember:
                    ApplicationMenu.GoldMenuMessages(userName);
                    break;
                case Role.VipMember:
                    ApplicationMenu.VipMenuMessages(userName);
                    break;
                case Role.SuperAdmin:
                    ApplicationMenu.AdminMenuStart(userName);
                    break;
                default:
                    Login();
                    break;

            }

        }
    }
}
