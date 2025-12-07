using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ContactBook
{
    class Contact
    {
        string directoryPath = @"C:\Users\xylea\source\repos\Contacts";
        Input input = new Input();
        public static List<ClassContact> contacts = new List<ClassContact>();
        public void AddContact()
        {
            string Name = input.ReadString("Enter Contact Name", intChecker : true);
            long phoneNumber = input.ReadLong("Enter Phone Number", NumLimit : true); 
            string emailAddress = input.ReadString("Enter Email Address (Press Enter if no Email)", EmptyString:true);
            emailAddress = string.IsNullOrEmpty(emailAddress)? "No Email Address" : emailAddress;

            contacts.Add(new ClassContact(Name, phoneNumber, emailAddress));
            SaveContacts();
        }
        private string SerializeContacts(ClassContact cont)
        {
            return $"{cont.Name}, {cont.PhoneNumber}, {cont.EmailAddress}";
        }
        private ClassContact? DeserializeContact(string line)
        {
            var parts = line.Split(',');
            if (parts.Length != 3) return null;  // this counts the number of parts and not the commas so u don't get confused
            if (!long.TryParse(parts[1], out long pN)) return null ;    // this checks if the conversion is successful, if it is, then it proceeds to give long pN, else it returns null. i first thought "if it fails to convert then it'll do -> out long pN, but there's a "!" operator which means "if the conversion is successful ,return true (which would proceed to give out long pN but the "!" turns it into false)
            return new ClassContact(parts[0], pN, parts[2]);
        }

        public void SaveContacts()
        {
            var lines = string.Join(Environment.NewLine, contacts.Select(SerializeContacts));   //this joins all the strings into one giant string, with Environment.NewLine separating the line after each selected contact.

            using (FileStream add = new FileStream(Path.Combine(directoryPath, "Contacts.txt"), FileMode.Create))
            {
                byte[] dataAdd = Encoding.UTF8.GetBytes(lines);
                add.Write(dataAdd, 0, dataAdd.Length);
            }
        }
        public void LoadContacts()
        {
            if (!File.Exists(Path.Combine(directoryPath, "Contacts.txt"))) return;
            contacts.Clear();
            var LoadedContacts = File.ReadAllLines(Path.Combine(directoryPath, "Contacts.txt"));
            foreach (var line in LoadedContacts)
            {
                var contact = DeserializeContact(line);
                if (contact != null)
                    contacts.Add(contact);
            }
        }
        public void ViewContacts()
        {
            if (contacts.Count == 0)
            { Console.WriteLine("No Contacts Found!"); return; }
            using (FileStream read = new FileStream(Path.Combine(directoryPath, "Contacts.txt"), FileMode.Open))
            {
                byte[] dataRead = new byte[read.Length];
                read.Read(dataRead, 0, dataRead.Length);
                Console.WriteLine(Encoding.UTF8.GetString(dataRead));
            }
            //Console.WriteLine(File.ReadAllText(Path.Combine(directoryPath, "Contacts.txt"))); this is an easier way that u can do this but i wanted to try out FileStream
        }
        public void DeleteContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Found"); return;
            }

            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"{i+1}. {contacts[i].Name}");
            }
            Console.WriteLine();
            int delRequest = input.ReadInt("Enter the contact you want to delete");
            if (delRequest <= 0 || delRequest > contacts.Count)
            {
                Console.WriteLine("No such Contact found"); 
                return;
            }
            delRequest = delRequest - 1;    //u cant do these before confirming because if suppose the user entered 4 when there are 3 contacts available, it'll get converted to 3 and the checker will still validate the users input.
            string confirmation = input.ReadString($"Are you sure you want to delete contact {contacts[delRequest].Name} (y/n)");
            if (confirmation == "y")
            {
                Console.WriteLine($"Contact : {contacts[delRequest].Name} Has Been Successfully Deleted");
                contacts.RemoveAt(delRequest);
                SaveContacts();
                return;
            }
            Console.WriteLine("Deletion Cancelled!");
        }
    }
}