namespace vehicle_app.Driver;

public class Person
{
    private string FirstName { get; set; }

    private string LastName { get; set; }
    

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}