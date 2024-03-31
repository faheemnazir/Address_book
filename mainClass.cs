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
            Console.WriteLine("5. Get_count_by_city_name");
            Console.WriteLine("6. Get all person in same city");
            Console.WriteLine("7. exit");

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
                    Console.WriteLine("enter the city name to count the number of perons in that city");
                    string city= Console.ReadLine();
                    Console.WriteLine("the number of the persons in the same city are " + contactManager.GetContactCountByCity(city));
                    Console.WriteLine("here is the list of cities and related persons in that city");
                    contactManager.person_in_same_city();
                     break;
                case 6:
                    Console.WriteLine("enter the city to ckeck all person in that city");
                    string check_city=Console.ReadLine();
                    contactManager.person_in_same_city(check_city);break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}