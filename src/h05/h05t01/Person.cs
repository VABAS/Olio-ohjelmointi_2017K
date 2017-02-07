class Person 
{
    private string id;
    private string firstName;
    private string lastName;
    
    // Properties.
    public string Id {
        get { return id; }
        set { id = value; }
    }
    public string FirstName {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName {
        get { return lastName; }
        set { lastName = value; }
    }
    
    // Constructor
    public Person (string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    
    public override string ToString ()
    {
        return "ID: " + Id + " Name: " + FirstName + " " + LastName;
    }
    public void PrintData ()
    {
        System.Console.WriteLine(ToString());
    }
    
}