namespace BuberDinner.Domain.Entities;

public class User {

    public Guid Id = Guid.NewGuid();

    public string FirstName = null!;

    public string LastName = null!; 

    public string Email = null!;

    public string Password = null!;

}