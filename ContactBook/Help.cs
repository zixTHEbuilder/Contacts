//public void DeleteContact()
//{
//    LoadContacts(); // make sure list is current

//    if (contacts.Count == 0)
//    {
//        Console.WriteLine("No contacts.");
//        return;
//    }

//    for (int i = 0; i < contacts.Count; i++)
//        Console.WriteLine($"{i + 1}. {contacts[i].Name} | {contacts[i].PhoneNumber}");

//    int choice = input.ReadInt("Select contact to delete");

//    if (choice < 1 || choice > contacts.Count)
//    {
//        Console.WriteLine("Invalid choice.");
//        return;
//    }

//    contacts.RemoveAt(choice - 1);
//    SaveContacts();
//}
