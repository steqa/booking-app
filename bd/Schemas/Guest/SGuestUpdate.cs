using bd.Exceptions;

namespace bd.Schemas.Guest;

public class SGuestUpdate
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
    
    public SGuestUpdate(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        
        var firstNameErrors = new List<string>();
        if (string.IsNullOrWhiteSpace(FirstName))
            firstNameErrors.Add("First Name is required.");
        else
            if (FirstName.Length > 100)
                firstNameErrors.Add("First Name cannot be longer than 100 characters.");
        
        var lastNameErrors = new List<string>();
        if (string.IsNullOrWhiteSpace(LastName))
            lastNameErrors.Add("Last Name is required.");
        else
            if (LastName.Length > 100)
                lastNameErrors.Add("Last Name cannot be longer than 100 characters.");
        
        var emailErrors = new List<string>();
        if (string.IsNullOrWhiteSpace(Email))
            emailErrors.Add("Email is required.");
        else
            if (Email.Length > 100)
                emailErrors.Add("Email cannot be longer than 100 characters.");
        
        var phoneErrors = new List<string>();
        if (string.IsNullOrWhiteSpace(Phone))
            phoneErrors.Add("Phone is required.");
        else
            if (Phone.Length > 100)
                phoneErrors.Add("Phone cannot be longer than 100 characters.");

        var errors = new Dictionary<string, List<string>>();

        if (firstNameErrors.Count > 0)
            errors.Add("firstName", firstNameErrors);
        if (lastNameErrors.Count > 0)
            errors.Add("lastName", lastNameErrors);
        if (emailErrors.Count > 0)
            errors.Add("email", emailErrors);
        if (phoneErrors.Count > 0)
            errors.Add("phone", phoneErrors);

        if (errors.Count != 0)
            throw new EValidation(errors);
    }
}