namespace backend.Schemas.Guest;

public static class Validator
{
    public static List<string> ValidateFirstName(string firstName)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(firstName))
        {
            errors.Add("First Name is required.");
        }
        else
        {
            if (firstName.Length > 100)
                errors.Add("First Name cannot be longer than 100 characters.");
        }
        return errors;
    }
    
    public static List<string> ValidateLastName(string lastName)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(lastName))
        {
            errors.Add("Last Name is required.");
        }
        else
        {
            if (lastName.Length > 100)
                errors.Add("Last Name cannot be longer than 100 characters.");
        }
        return errors;
    }
 
    public static List<string> ValidateEmail(string email)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(email))
        {
            errors.Add("Email is required.");
        }
        else
        {
            if (email.Length > 100)
                errors.Add("Email cannot be longer than 100 characters.");
        }
        return errors;
    }
    
    public static List<string> ValidatePhone(string phone)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(phone))
        {
            errors.Add("Phone is required.");
        }
        else
        {
            if (phone.Length > 15)
                errors.Add("Phone cannot be longer than 15 characters.");
        }
        return errors;
    }
}