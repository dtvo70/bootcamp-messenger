using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{

    public enum Role
    {
        SuperAdmin,
        VipMember,
        GoldMember,
        SimpleMember
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string NickName { get; set; }
        public Role UserRights { get; set; }

        
        public User(int id, string userName, string passWord, string nickName, Role userRights)
        {
            Id = id;
            UserName = userName;
            PassWord = passWord;
            NickName = nickName;
            UserRights = userRights;
        }

        //CREATE USER
        public static void Create()
        {

            bool value = true;
            do
            {
                
                Console.Write("Give Username: ");
                var username = Console.ReadLine();
                Console.Write("Give Password: ");
                var password = Console.ReadLine();
                Console.Write("Give Nickname: ");
                var usernickname = Console.ReadLine();
                string userrole;

                do
                {
                    Console.Write("Choose User rights (SuperAdmin, VipMember, GoldMember, SimpleMember): ");
                    userrole = Console.ReadLine();
                    switch (userrole)
                    {
                        case "SuperAdmin":
                            value = true;
                            break;
                        case "VipMember":
                            value = true;
                            break;
                        case "GoldMember":
                            value = true;
                            break;
                        case "SimpleMember":
                            value = true;
                            break;
                        default:
                            value = false;
                            break;
                    }
                } while (value == false);

                if (!Database.UserExists(username))
                {
                    Database.InsertUser(username, password, usernickname, userrole);
                    value = false;
                }
                else
                {
                    Console.WriteLine("Same Name exists, choose another!");
                }

            } while (value);
        }

        //UPDATE PASSWORD
        public static void UpdatePassword()
        {
            
            string input = "";
            bool value = true;
            do
            {
                Console.Write("Give the UserName of user to change Password: ");

                input = Console.ReadLine();
                if (!Database.UserExists(input))
                {
                    value = true;
                    Console.Write("Input does not exists. Please try again... ");
                }
                    
                else
                    value = false;
            } while (value);

            Console.Write("Enter a new Password for User: ");
            string newPassword = Console.ReadLine();
            Database.UpdateUserPassword(newPassword, input);
        }

        //UPDATE ROLE OF USER
        public static void UpdateRole()
        {
            
            string input = "";
            string newRole = "";
            bool value = true;
            do
            {
                Console.Write("Give the UserName of user to change Role (SuperAdmin, VipMember, GoldMember, SimpleMember): ");

                input = Console.ReadLine();
                if (!Database.UserExists(input))
                {
                    value = true;
                    Console.Write("User does not exist. Try again... ");
                }

                else
                    value = false;
            } while (value);

            do
            {
                Console.Write("Enter new Role for User: ");
                newRole = Console.ReadLine();
                switch (newRole)
                {
                    case "SuperAdmin":
                        value = true;
                        break;
                    case "VipMember":
                        value = true;
                        break;
                    case "GoldMember":
                        value = true;
                        break;
                    case "SimpleMember":
                        value = true;
                        break;
                    default:
                        value = false;
                        break;
                }
            } while (value == false);
            Database.UpdateUserRole(newRole, input);
        }

        //DELETE A USER
        public static void Delete()
        {
            
            string input = "";
            bool value = true;
            do
            {
                Console.Write("Give the UserName to delete: ");

                input = Console.ReadLine();
                if (!Database.UserExists(input))
                {
                    value = true;
                    Console.WriteLine("Username does not exist.Try again... ");
                }

                else
                    value = false;
            } while (value);

            Database.DeleteUser(input);
        }

        //VIEW ONLY USERNAMES
        public static void ViewOnlyUserNames()
        {
            Database.ViewOnlyUserNames();

        }

        //CHECK USERNAME
        public static bool ValidUserName(string userName)
        {
            bool value = false;
            value = Database.IsValidUserName(userName);
            return value;
        }

        //CHECK PASSWORD
        public static bool ValidPassword(string userName, string passWord)
        {
            bool value = false;
            value = Database.IsValidPassword(userName, passWord);
            return value;
        }

        //ROLE
        public static Role UserRole(string userName)
        {
            Role role;
            role = Database.RoleOfUser(userName);
            return role;
        }

        //VIEW ALL USERS
        public static void ViewAllUsers()
        {
            Database.ViewAllUsers();
        }

    }

}

