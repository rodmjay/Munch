using MunchBase.Users.Entities;

namespace MunchBase.Users.ViewModels;

public class UserInput 
{
    public string Displayname { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsModel { get; set; }
    public bool IsProducer { get; set; }
    public bool IsConsumer { get; set; }
    public bool IsEditor { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Code3 { get; set; }
    public string Iso2 { get; set; }
    public string Password { get; set; }
}