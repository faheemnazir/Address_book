using System.Text.RegularExpressions;



using System;
using System.Collections.Generic;
namespace Address_book;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ZipCode { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public override bool Equals(object? obj)
    {
        return FirstName == ((Contact)obj).FirstName;
    }
    public override int GetHashCode()
    {
        return FirstName.GetHashCode();
    }

}
public class MyNumberException : ApplicationException
{
    public override string Message
    {
        get
        {
            return "please input a number type";
        }
    }
}

public class MyStringException : ApplicationException
{
    public override string Message
    {
        get
        {
            return "please input string type";
        }
    }
}

public class manageContacts
{
    private List<Contact> contacts;
    public Dictionary<string, List<string>> person_city_dict = new Dictionary<string, List<string>>();

    public manageContacts()
    {
        contacts = new List<Contact>();
    }

    public void AddContact()
    {
        Contact newContact = new Contact();
        try
        {


            Console.WriteLine("Enter First Name:");
            newContact.FirstName = Console.ReadLine();
            Regex reg= new Regex(@"^\d+$");
            if (reg.IsMatch(newContact.FirstName))
                throw new MyStringException();

            Console.WriteLine("Enter Last Name:");
            newContact.LastName = Console.ReadLine();

            Console.WriteLine("Enter Zip Code:");
            newContact.ZipCode = Console.ReadLine();
            Regex regex = new Regex(@"^\d+$");
            if (!(regex.IsMatch(newContact.ZipCode)))
                throw new MyNumberException();
            Console.WriteLine("Enter Address:");
            newContact.Address = Console.ReadLine();

            Console.WriteLine("Enter City:");
            newContact.City = Console.ReadLine();

            Console.WriteLine("Enter Phone Number:");
            newContact.PhoneNumber = Console.ReadLine();
            Regex regex2 = new Regex(@"^\d+$");
            if (!(regex2.IsMatch(newContact.PhoneNumber)))
                throw new MyNumberException();
            Console.WriteLine("Enter Email:");
            newContact.Email = Console.ReadLine();

            /* if (!contacts.Any(person => person.FirstName.Equals(newContact.FirstName, StringComparison.OrdinalIgnoreCase)))
             {
                 contacts.Add(newContact);
                 Console.WriteLine($"{newContact.FirstName} added to the list sucessesfully.");
             }
             else
             {
                 Console.WriteLine($"{newContact.FirstName} is already in the list. Not adding duplicate.");
             }*/
            if (!contacts.Contains(newContact))
            {
                contacts.Add(newContact);
                Console.WriteLine("contact added sucesesfully");
            }
            else
                Console.WriteLine("\ncontact with the name " + newContact.FirstName + " alreday exists");


        }
        finally
        {
        }
        

      
    }

    public void DeleteContact()
    {
        Console.WriteLine("Enter the First Name of the contact you want to delete:");
        string firstName = Console.ReadLine();

        Contact contactToRemove = contacts.Find(contact => contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            Console.WriteLine("Contact deleted successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found!");
        }
    }

    public void EditContact()
    {
        Console.WriteLine("Enter the First Name of the contact you want to edit:");
        string firstName = Console.ReadLine();

        Contact contactToEdit = contacts.Find(contact => contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

        if (contactToEdit != null)
        {
            Console.WriteLine("Enter new First Name:");
            contactToEdit.FirstName = Console.ReadLine();

            Console.WriteLine("Enter new Last Name:");
            contactToEdit.LastName = Console.ReadLine();

            Console.WriteLine("Enter new Zip Code:");
            contactToEdit.ZipCode = Console.ReadLine();

            Console.WriteLine("Enter new Address:");
            contactToEdit.Address = Console.ReadLine();

            Console.WriteLine("Enter new City:");
            contactToEdit.City = Console.ReadLine();

            Console.WriteLine("Enter new Phone Number:");
            contactToEdit.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter new Email:");
            contactToEdit.Email = Console.ReadLine();

            Console.WriteLine("Contact edited successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found!");
        }
    }

    public void DisplayAllContacts()
    {
        Console.WriteLine("Contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"First Name: {contact.FirstName}\n Last Name: {contact.LastName} \n " +
                              $"Zip Code: {contact.ZipCode} \n Address: {contact.Address} \n " +
                              $"City: {contact.City}\n Phone Number: {contact.PhoneNumber} \n" +
                              $"Email: {contact.Email}");
            Console.WriteLine("---------------------------------------------------------------------------");
        }


    }

    public void person_in_same_city()
    {
        foreach (var person in contacts)
        {
            if (!person_city_dict.ContainsKey(person.City))
                person_city_dict[person.City] = new List<string>();
            person_city_dict[person.City].Add(person.FirstName);
        }

        foreach (var city in person_city_dict)
        {
            Console.WriteLine($"City: {city.Key}");
            foreach (var name in city.Value)
            {
                Console.WriteLine($"- {name}");
            }
        }
    }
    public void check_person_by_city(string city) {

        Console.WriteLine("persons in the city " + city + " are");
        if (person_city_dict.ContainsKey(city))
        {
            foreach (var names in person_city_dict[city])
                Console.WriteLine(names);
        }
        else
        {
            Console.WriteLine("city not found enter the valid city");

        }
    }

    public int GetContactCountByCity(string city)
    {
        int count = 0;
        foreach (var person in contacts)
        {
            if (person.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                count++;
        }
        return count;
    }
}