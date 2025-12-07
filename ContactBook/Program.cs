using ContactBook;

namespace ContactBook
{
    class Program
    {
        static void Main()
        {
            Input input = new Input();
            Contact contact = new Contact();
            contact.LoadContacts();
            while (true)
            {
                int programSelect = input.ReadInt("Choose an option \n1. Add Contact \n2. View Contacts \n3. Delete Contacts \n4. Exit Program", writeLine: true);
                switch (programSelect)
                {
                    case 1:
                        {
                            contact.AddContact(); break;
                        }
                    case 2:
                        {
                            contact.ViewContacts(); break;
                        }
                    case 3:
                        {
                            contact.DeleteContacts(); break;
                        }
                    case 4:
                        {
                            return;
                        }
                    default: { Console.WriteLine("Error - Enter a Valid Number to choose a program!"); break ; }
                }
            }
        }
    }
}