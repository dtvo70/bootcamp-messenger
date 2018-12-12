using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    public class FileAccess
    {
        //DIMIOURGIA ARXEIOU
        public static void AddMessage(int Id, string Sender, string Receiver, string DateSub, string Message)
        {

            string path = $"{Id}.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"{DateSub}");
                    sw.WriteLine($"{Sender}");
                    sw.WriteLine($"{Receiver}");
                    sw.WriteLine($"{Message}");
                    sw.WriteLine();
                }
                Console.WriteLine("Create");
            }
            else
                Console.WriteLine("File Exists");

        }

        //UPDATE-EDIT ARXEIOU VASH ID
        public static void UpdateMessage(int Id, string DateUpdate, string MessageUpd, string Editor)
        {
            string path = $"{Id}.txt";
            if (File.Exists(path))
            {
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine($"{DateUpdate}");
                    file.WriteLine($"{Editor}");
                    file.WriteLine($"{MessageUpd}");
                    file.WriteLine();
                }
            }
            else
                Console.WriteLine("File Does Not Exist");
        }

        //DELETE ARXEIOU MOLIS SVHSOYME TO MYNHMA VASH ID
        public static void DeleteMessage(int Id)
        {
            string path = $"{Id}.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
                Console.WriteLine("File Does Not Exist");
        }
    }
}
