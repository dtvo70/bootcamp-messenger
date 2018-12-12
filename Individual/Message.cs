using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    public class Message
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateUpdated { get; set; }

        //DIMIOURGIA MESSAGE
        public static void CreateMessage(string Sender)
        {
            
            DateTime date = DateTime.Now;
            string Datesub = date.ToString("dd/MM/yyyy HH:mm:ss");
            int FileID = 0;
            

            Console.Write("Write the message (Limit is 250 characters): ");
            string message = Console.ReadLine();

            if (message.Length > 250)
                message = message.Substring(0, 250);

            Console.Write("Give ReceiverName: ");
            var Receiver = Console.ReadLine();

            string lineSender = $"Sender: {Sender}";
            string lineReceiver = $"Receiver: {Receiver}";
            string lineDateSub = $"Date of submission: {Datesub}";
            string lineMessage = $"Message: {message}";
            // 
            FileID = Database.CreateMessage(Sender, Receiver, message);

            FileAccess.AddMessage(FileID, lineSender, lineReceiver, lineDateSub, lineMessage);
            
        }

        //UPDATE-EDIT MESSAGE VASH ID
        public static void UpdateMessage(string Sender)
        {
            Console.Write("Give ID to Update a message: ");
            string IdToUpdate = Console.ReadLine();
            int Id = int.Parse(IdToUpdate);
            DateTime date = DateTime.Now;
            string Datesub = date.ToString("dd/MM/yyyy HH:mm:ss");
            
            string DateUpdate = $"Date of update: {Datesub}";
            string Editor = $"Editor: {Sender}";

            Console.Write("Change the message: ");
            string InputMessage = Console.ReadLine();
            string UpdMessage = $"Message: {InputMessage}";


            FileAccess.UpdateMessage(Id, DateUpdate, UpdMessage, Editor);
            Database.UpdateMessage(Id, InputMessage);
        }

        //DELETE MESSAGE VASH ID
        public static void DeleteMessage()
        {
            
            Console.Write("Give ID to Delete a message: ");
            string IdToDelete = Console.ReadLine();
            int Id = int.Parse(IdToDelete);
            Database.DeleteMessage(Id);
            FileAccess.DeleteMessage(Id);
        }

        //ANAGNOSH OLON TON MYNHMATON
        public static void ViewAllMessages()
        {
            Database.ViewAllMessages();
        }

        //ANAGNOSH TON MYNHMATON TOY TREXON XRHSTH BASH USERNAME
        public static void ViewYourMessages(string userName)
        {
            Database.ViewYourMessages(userName);
        }

        //ANAGNOSH TON MYNHMATON KAPOIOY ALLOY XRHSTH BASH USERNAME
        public static void ViewOtherMessages()
        {
            Console.Write("Give Username to View Messages: ");
            string userName = Console.ReadLine();
            Database.ViewYourMessages(userName);
        }

        //DELETE TON MESSAGES AN YPARXOUN PRIN THN DIAGRAFH TOU USER
        public static void DelMessages(string userName)
        {
            Database.DelMessages(userName);
        }
    }
}
