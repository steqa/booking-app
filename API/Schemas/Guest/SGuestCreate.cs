using backend.Exceptions;

namespace backend.Schemas.Guest;

public class SGuestCreate
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
    
    public SGuestCreate(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        
        _validate();
    }
    
    private void _validate()
    {
        var firstNameErrors = Validator.ValidateFirstName(FirstName);
        var lastNameErrors = Validator.ValidateLastName(LastName);
        var emailErrors = Validator.ValidateEmail(Email);
        var phoneErrors = Validator.ValidatePhone(Phone);
        
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
            throw new EHttpValidation(errors);
    }
}