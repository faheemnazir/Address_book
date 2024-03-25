namespace Address_book;
public class mainClass
{
    static void Main(string[] args)
    {
        manageContacts contactManager = new manageContacts();
        while (true)
        {
            Console.WriteLine("\n================== ADDRESS BOOK  ===================");
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Delete Contact");
            Console.WriteLine("3. Edit Contact");
            Console.WriteLine("4. Display All Contacts");
            Console.WriteLine("5. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    contactManager.AddContact();
                    break;
                case 2:
                    contactManager.DeleteContact();
                    break;
                case 3:
                    contactManager.EditContact();
                    break;
                case 4:
                    contactManager.DisplayAllContacts();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}