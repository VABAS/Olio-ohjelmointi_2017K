using System.Collections.Generic;

class Persons
{
    private List<Person> persons = new List<Person>();
    
    // Default constructor.
    public Persons ()
    {
        
    }
    
    // Paramerized constructor. List of persons to initially add into list.
    public Persons (List<Person> persons)
    {
        this.persons = persons;
    }
    // Paramerized constructor. Array of persons to initially add into list.
    public Persons (Person[] persons)
    {
        foreach (Person p in persons)
        {
            AddPerson(p);
        }
    }
    
    // Adds person object provided to persons list.
    public void AddPerson (Person person)
    {
        persons.Add(person);
    }
    
    // Adds new person object to array with provided id, firstName and lastName.
    public void AddPerson (string id, string firstName, string lastName)
    {
        persons.Add(new Person(id, firstName, lastName));
    }
    
    // Returns person with index number.
    public Person GetPerson (int index)
    {
        try
        {
            return persons[index];
        }
        catch
        {
            return null;
        }
    }
    
    // Method to find person with id. Returns person object found. Returns null
    // if person could not be found with id provided.
    public Person FindPerson (string id)
    {
        foreach (Person p in persons)
        {
            if (p.Id == id)
            {
                return p;
            }
        }
        return null;
    }
    
    // Prints information about every person object contained in persons list.
    public void PrintData ()
    {
        foreach (Person p in persons)
        {
            p.PrintData();
        }
    }
}