using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    class Database
    {
        public static SqlConnection Connection()
        {
            string connectionString = @"Server=localhost\SQLExpress; Database = IndividualDB; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        //CREATE USER 
        public static void InsertUser(string userName, string passWord, string userNickname, string userRole)
        {

            SqlConnection connection = Connection();

            const string InsertIntoDb = "INSERT INTO UserTable (UserName, PassWord, NickName, Role) VALUES (@UserName, @PassWord, @NickName, @Role);";

            using (connection)
            {
                using (SqlCommand command = new SqlCommand(InsertIntoDb, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("UserName", $"{userName}");
                    command.Parameters.AddWithValue("PassWord", $"{passWord}");
                    command.Parameters.AddWithValue("NickName", $"{userNickname}");
                    command.Parameters.AddWithValue("Role", $"{userRole}");
                    int rowsUpdated = command.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Successfull");
                    }
                    else
                    {
                        Console.WriteLine("Error, try again.");
                    }

                }

            }

        }

        //CHECK IF USERNAME EXISTS 
        public static bool UserExists(string userName)
        {
            SqlConnection connection = Connection();
            bool value = false;
            const string Count = "SELECT COUNT(*) FROM UserTable WHERE userName = @userName";

            using (connection)
            {
                using (SqlCommand cmdSelect = new SqlCommand(Count, connection))
                {
                    connection.Open();
                    cmdSelect.Parameters.AddWithValue("userName", $"{userName}");
                    int result = (int)cmdSelect.ExecuteScalar(); //Get count in INT (cast) variable
                    if (result > 0)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }

                }

            }
            return value;
        }

        //UPDATE PASSWORD OF USER 
        public static void UpdateUserPassword(string newPassword, string userName)
        {

            SqlConnection connection = Connection();

            const string UpdatePass = "UPDATE UserTable SET PassWord = @newPassword WHERE UserName = @userName";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdatePass, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    cmdUpdate.Parameters.AddWithValue("newPassword", $"{newPassword}");
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Successfull");
                    }
                }
            }
        }

        //UPDATE ROLE OF USER
        public static void UpdateUserRole(string newRole, string userName)
        {
            SqlConnection connection = Connection();

            const string UpdateRole = "UPDATE UserTable SET Role = @newRole WHERE UserName = @userName";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRole, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("newRole", $"{newRole}");
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Successfull");
                    }
                }
            }
        }

        //DELETE A USER
        public static void DeleteUser(string userName)
        {

            Message.DelMessages(userName); //Delete messages if exist

            SqlConnection connection = Connection();

            const string DeleteUser = "DELETE FROM UserTable WHERE UserName = @userName";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(DeleteUser, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Successfull");
                    }
                }
            }
        }

        //VIEW ALL USERS FROM DATABASE
        public static void ViewAllUsers()
        {
            SqlConnection connection = Connection();
            SqlDataReader reader;

            const string ViewAllusers = "SELECT * FROM UserTable";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(ViewAllusers, connection))
                {
                    connection.Open();
                    reader = cmdUpdate.ExecuteReader(); //obtain a row from the query results
                    Console.WriteLine($"ID\tUSERNAME \t\t  PASSWORD \t\tNICKNAME \t\t    UserRIGHTS");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}  \t{reader[1]}     \t\t  {reader[2]}    \t\t{reader[3]}       \t  \t    {reader[4]}");
                    }
                }
            }
        }

        //VIEW ONLY THE USERNAMES
        public static void ViewOnlyUserNames()
        {
            SqlConnection connection = Connection();
            SqlDataReader reader;

            const string ViewOnlyUsers = "SELECT Id, UserName FROM UserTable";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(ViewOnlyUsers, connection))
                {
                    connection.Open();
                    reader = cmdUpdate.ExecuteReader(); //obtain a row from the query results
                    Console.WriteLine($"ID\tUSERNAME");
                    Console.WriteLine("------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}  \t{reader[1]}");
                    }
                }
            }
        }

        //CREATE A MESSAGE
        public static int CreateMessage(string Sender, string Receiver, string Message)
        {
            DateTime date = DateTime.Now;
            string Datesub = date.ToString("dd/MM/yyyy HH:mm:ss");
            int ID = 0;
            SqlConnection connection = Connection();

            const string CreateMsg = "INSERT INTO Messages(Message, Sender, Receiver, DateSubmitted) VALUES(@Message, (select Id from UserTable Where UserName = @Sender), (select Id from UserTable Where UserName = @Receiver), @Datesub); SELECT SCOPE_IDENTITY();";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(CreateMsg, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("Message", $"{Message}");
                    cmdUpdate.Parameters.AddWithValue("Sender", $"{Sender}");
                    cmdUpdate.Parameters.AddWithValue("Receiver", $"{Receiver}");
                    cmdUpdate.Parameters.AddWithValue("Datesub", $"{Datesub}");
                    ID = Convert.ToInt32(cmdUpdate.ExecuteScalar());
                }
            }
            return ID;
        }

        //UPDATE A MESSAGE
        public static void UpdateMessage(int Id, string Message)
        {
            DateTime date = DateTime.Now;
            string Datesub = date.ToString("dd/MM/yyyy HH:mm:ss");
            SqlConnection connection = Connection();

            const string UpdateMsg = "UPDATE Messages SET Message = @Message, DateUpdated = @Datesub WHERE Id = @Id";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateMsg, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("Message", $"{Message}");
                    cmdUpdate.Parameters.AddWithValue("Datesub", $"{Datesub}");
                    cmdUpdate.Parameters.AddWithValue("Id", $"{Id}");
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Successfull");
                    }
                }
            }
        }

        //DELETE A MESSAGE
        public static void DeleteMessage(int Id)
        {
            SqlConnection connection = Connection();

            const string DeleteMsg = "DELETE FROM Messages WHERE Id = @Id";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(DeleteMsg, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("Id", $"{Id}");
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Successfull");
                    }
                }
            }
        }

        //VIEW ALL MESSAGES
        public static void ViewAllMessages()
        {

            SqlConnection connection = Connection();
            SqlDataReader reader;
            const string ViewAllMsg = "SELECT Messages.Id, Messages.Message, u1.UserName Sender, u2.UserName Receiver, Messages.DateSubmitted, Messages.DateUpdated FROM Messages JOIN UserTable u1 ON Messages.Sender = u1.Id JOIN UserTable u2 ON Messages.Receiver = u2.Id";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(ViewAllMsg, connection))
                {
                    connection.Open();
                    reader = cmdUpdate.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Console.WriteLine($"MESSAGE_ID: {reader[0]}\n\t\tSENDER: {reader[2]}\n\t\tRECEIVER: {reader[3]}\n\t\tDATE_SUBMMITED: {reader[4]}\n\t\tDATE_UPDATED: {reader[5]}\n\t\tMESSAGE: {reader[1]}\n");
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        //VIEW CURRENT USER'S MESSAGES
        public static void ViewYourMessages(string userName)
        {

            SqlConnection connection = Connection();
            SqlDataReader reader;
            //const string ViewUserMsg = "SELECT * FROM Messages WHERE Sender =(select Id from UserTable Where UserName = @username) OR Receiver =(select Id from UserTable Where UserName = @username)";
            const string ViewUserMsg = "SELECT Messages.Id, Messages.Message, u1.UserName Sender, u2.UserName Receiver, Messages.DateSubmitted, Messages.DateUpdated FROM Messages JOIN UserTable u1 ON Messages.Sender = u1.Id JOIN UserTable u2 ON Messages.Receiver = u2.Id WHERE Sender = (select Id from UserTable Where UserName = @userName) OR Receiver = (select Id from UserTable Where UserName = @userName)";


            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(ViewUserMsg, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    reader = cmdUpdate.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Console.WriteLine($"MESSAGE_ID: {reader[0]}\n\t\tSENDER: {reader[2]}\n\t\tRECEIVER: {reader[3]}\n\t\tDATE_SUBMMITED: {reader[4]}\n\t\tDATE_UPDATED: {reader[5]}\n\t\tMESSAGE: {reader[1]}\n");
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        //VALID USERNAME
        public static bool IsValidUserName(string userName)
        {

            SqlConnection connection = Connection();
            SqlDataReader reader;
            bool value = false;
            const string ValidUserName = "SELECT UserName FROM UserTable WHERE UserName = @userName";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(ValidUserName, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    reader = cmdUpdate.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == userName)
                        {
                            value = true;
                        }
                    }
                }
            }
            return value;
        }

        //VALID PASSWORD
        public static bool IsValidPassword(string userName, string passWord)
        {
            SqlConnection connection = Connection();
            SqlDataReader reader;
            bool value = false;
            const string ValidUserPass = "SELECT PassWord FROM UserTable WHERE UserName = @userName";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(ValidUserPass, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    reader = cmdUpdate.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == passWord)
                        {
                            value = true;
                        }
                    }
                }
            }
            return value;
        }

        //ROLE USER
        public static Role RoleOfUser(string userName)
        {
            Role role = new Role();
            string role1;
            SqlConnection connection = Connection();
            const string RoleOfUser = "SELECT Role FROM UserTable WHERE UserName = @userName";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(RoleOfUser, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    SqlDataReader reader = cmdUpdate.ExecuteReader();
                    reader.Read();
                    role1 = reader.GetString(0);
                    role = (Role)Enum.Parse(typeof(Role), role1); //metatropi tou string 

                }
                return role;
            }
        }

        //DELETE MESSAGES (GIA THN DIAGRAFH USER POY EXEI MHNYMATA)
        public static void DelMessages(string userName)
        {
            SqlConnection connection = Connection();
            int count;

            const string DelMessages = "SELECT COUNT(*) FROM Messages WHERE Sender =(select Id from UserTable Where UserName = @username) OR Receiver =(select Id from UserTable Where UserName = @username)";

            using (connection)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(DelMessages, connection))
                {
                    connection.Open();
                    cmdUpdate.Parameters.AddWithValue("userName", $"{userName}");
                    count = (int)cmdUpdate.ExecuteScalar();
                    if (count > 0)
                    {
                        Console.WriteLine($"Messages found for User: {userName}");
                        Console.WriteLine("Deleting...");
                        SqlCommand cmdUpdate2 = new SqlCommand($"DELETE FROM Messages WHERE Sender =(select Id from UserTable Where UserName = @userName) OR Receiver =(select Id from UserTable Where UserName = @userName)", connection);
                        cmdUpdate2.Parameters.AddWithValue("userName", $"{userName}");
                        cmdUpdate2.ExecuteReader();
                    }
                }
            }
        }
    }
}
