using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    public class ApplicationMenu
    {
        //SUPERADMIN : 1.EDIT-CREATE USERS <-> 2.READ SEND UPDATE DELETE  MESSAGES
        //VIPMEMBER : 1.READ SEND UPDATE DELETE  MESSAGES
        //GOLDMEMBER : 1.READ SEND UPDATE  MESSAGES
        //SIMPLEMEMBER: 1.READ SEND  MESSAGES

        //ADMIN LOGIN CHOOSE USERS OR MESSAGES
        public static void AdminMenuStart(string username)
        {
            while (true)
            {
                
                ShowMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);                       
                        break;
                    case "1":
                        AdminMenuUsers(username);
                        break;
                    case "2":
                        AdminMenuMessages(username);
                        break;
                    case "3":
                        Console.Clear();
                        LoginUser.Login();
                        break;
                    default:
                        AdminMenuStart(username);
                        break;
                }
            }

            void ShowMenu()
            {
                Console.Clear();
                Console.WriteLine("#############################");
                Console.WriteLine(" YOU ARE ADMIN IN START MENU ");
                Console.WriteLine("     WELCOME SuperADMIN ");
                Console.WriteLine("#############################");
                Console.WriteLine("1. Choose Users");
                Console.WriteLine("2. Choose Messages");
                Console.WriteLine("3. Log Out");
                Console.WriteLine("0. Exit");
            }
        }

        //ADMIN LOGIN - USERS MENU
        private static void AdminMenuUsers(string username)
        {
            while (true)
            {
                
                ShowMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.Clear();
                        User.Create();
                        break;
                    case "2":
                        Console.Clear();
                        User.ViewAllUsers();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        User.Delete();
                        break;
                    case "3":
                        Console.Clear();
                        User.ViewAllUsers();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        User.UpdatePassword();
                        break;
                    case "4":
                        Console.Clear();
                        User.ViewAllUsers();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        User.UpdateRole();
                        break;
                    case "5":
                        Console.Clear();
                        User.ViewAllUsers();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "6":
                        AdminMenuStart(username);
                        break;
                    case "7":
                        Console.Clear();
                        LoginUser.Login();
                        break;
                    default:
                        AdminMenuUsers(username);
                        break;
                }
            }

            void ShowMenu()
            {
                Console.WriteLine("Press a key to continue... ");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("################################");
                Console.WriteLine("          SUPERADMIN ");
                Console.WriteLine("    YOU ARE IN USERS MENU ");
                Console.WriteLine("################################");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Delete User");
                Console.WriteLine("3. Update Password of a User");
                Console.WriteLine("4. Change the Role of a User");
                Console.WriteLine("5. View all Users");
                Console.WriteLine("6. Return to Main menu");
                Console.WriteLine("7. Log Out");
                Console.WriteLine("0. Exit");
            }


        }

        //ADMIN LOGIN - MESSAGES MENU
        private static void AdminMenuMessages(string username)
        {
            
            while (true)
            {
               
                ShowMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.CreateMessage(username);
                        break;
                    case "2":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.UpdateMessage(username);
                        break;
                    case "3":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.DeleteMessage();
                        break;
                    case "4":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "5":
                        Console.Clear();
                        Message.ViewYourMessages(username);
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "6":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.ViewOtherMessages();
                        break;
                    case "7":
                        AdminMenuStart(username);
                        break;
                    case "8":
                        Console.Clear();
                        LoginUser.Login();
                        break;
                    default:
                        AdminMenuMessages(username);
                        break;
                }
            }

            void ShowMenu()
            {
                Console.WriteLine("Press a key to continue... ");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("################################");
                Console.WriteLine("           ADMIN   ");
                Console.WriteLine("    YOU ARE IN MENU MESSAGES ");
                Console.WriteLine("################################");
                Console.WriteLine("1. Send a Message");
                Console.WriteLine("2. Update a Message");
                Console.WriteLine("3. Delete a Message");
                Console.WriteLine("4. Show all Messages");
                Console.WriteLine("5. Show Your Messages");
                Console.WriteLine("6. Show other users Messages");
                Console.WriteLine("7. Return to Main menu");
                Console.WriteLine("8. Log Out");
                Console.WriteLine("0. Exit");
            }
        }

        //VIPMEMBER LOGIN - MESSAGES MENU
        public static void VipMenuMessages(string username)
        {
            // AdminMenuMessages(username);
            while (true)
            {

                ShowMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.CreateMessage(username);
                        break;
                    case "2":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.UpdateMessage(username);
                        break;
                    case "3":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.DeleteMessage();
                        break;
                    case "4":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "5":
                        Console.Clear();
                        Message.ViewYourMessages(username);
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "6":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.ViewOtherMessages();
                        break;
                    case "7":
                        Console.Clear();
                        LoginUser.Login();
                        break;
                    default:
                        AdminMenuMessages(username);
                        break;
                }
            }

            void ShowMenu()
            {
                Console.WriteLine("Press a key to continue... ");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("################################");
                Console.WriteLine("           VIPMEMBER ");
                Console.WriteLine("    YOU ARE IN MENU MESSAGES ");
                Console.WriteLine("################################");
                Console.WriteLine("1. Send a Message");
                Console.WriteLine("2. Update a Message");
                Console.WriteLine("3. Delete a Message");
                Console.WriteLine("4. Show all Messages");
                Console.WriteLine("5. Show Your Messages");
                Console.WriteLine("6. Show other users Messages");
                Console.WriteLine("7. Log Out");
                Console.WriteLine("0. Exit");
            }
        


    }

        //GOLDMEMBER LOGIN - MESSAGES MENU
        public static void GoldMenuMessages(string username)
        {
            
            while (true)
            {
                
                ShowMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.CreateMessage(username);
                        break;
                    case "2":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.UpdateMessage(username);
                        break;
                    case "3":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "4":
                        Console.Clear();
                        Message.ViewYourMessages(username);
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "5":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.ViewOtherMessages();
                        break;
                    case "6":
                        Console.Clear();
                        LoginUser.Login();
                        break;
                    default:
                        GoldMenuMessages(username);
                        break;
                }
            }

            void ShowMenu()
            {
                Console.WriteLine("Press a key to continue... ");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("################################");
                Console.WriteLine("          GOLDMEMBER ");
                Console.WriteLine("    YOU ARE IN MENU MESSAGES ");
                Console.WriteLine("################################");
                Console.WriteLine("1. Send a Message");
                Console.WriteLine("2. Update a Message");
                Console.WriteLine("3. Show all Messages");
                Console.WriteLine("4. Show Your Messages");
                Console.WriteLine("5. Show other users Messages");
                Console.WriteLine("6. Log Out");
                Console.WriteLine("0. Exit");
            }


        }

        //SIMPLEMEMBER LOGIN - MESSAGES MENU
        public static void SimpleMenuMessages(string username)
        {
            
            while (true)
            {
                
                ShowMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.CreateMessage(username);
                        break;
                    case "2":
                        Console.Clear();
                        Message.ViewAllMessages();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "3":
                        Console.Clear();
                        Message.ViewYourMessages(username);
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        break;
                    case "4":
                        Console.Clear();
                        User.ViewOnlyUserNames();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Message.ViewOtherMessages();
                        break;
                    case "5":
                        Console.Clear();
                        LoginUser.Login();
                        break;
                    default:
                        SimpleMenuMessages(username);
                        break;
                }
            }

            void ShowMenu()
            {
                Console.WriteLine("Press a key to continue... ");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("################################");
                Console.WriteLine("          SIMPLEMEMBER ");
                Console.WriteLine("    YOU ARE IN MENU MESSAGES ");
                Console.WriteLine("################################");
                Console.WriteLine("1. Send a Message");
                Console.WriteLine("2. Show all Messages");
                Console.WriteLine("3. Show Your Messages");
                Console.WriteLine("4. Show other users Messages");
                Console.WriteLine("5. Log Out");
                Console.WriteLine("0. Exit");
            }


        }

    }
}
