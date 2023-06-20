using System;

namespace LegacyApp;

public class UserService
{
    public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
    {
        if (NameIsInvalid(firstName, lastName)) return false;

        if (EmailIsInvalid(email)) return false;

        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;

        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
        {
            age--;
        }

        if (age < 21)
        {
            return false;
        }

        var clientRepository = new ClientRepository();
        var client = clientRepository.GetById(clientId);

        var user = new User
        {
            ClientId = client.Id,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            Firstname = firstName,
            Surname = lastName
        };

        if (client.Name == "VeryImportantClient")
        {
            // Skip credit chek
            user.HasCreditLimit = false;
        }
        else if (client.Name == "ImportantClient")
        {
            // Do credit check and double credit limit
            user.HasCreditLimit = true;
            var userCreditService = new UserCreditService();
            var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
            creditLimit = creditLimit * 2;
            user.CreditLimit = creditLimit;
        }
        else
        {
            // Do credit check
            user.HasCreditLimit = true;
            var userCreditService = new UserCreditService();
            var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
            user.CreditLimit = creditLimit;
        }

        if (user.HasCreditLimit && user.CreditLimit < 500)
        {
            return false;
        }
            
        new UserDataAccess().AddUser(user);

        return true;
    }

    private static bool EmailIsInvalid(string email)
    {
        return email.Contains("@") && !email.Contains(".");
    }

    private static bool NameIsInvalid(string firstName, string lastName)
    {
        return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);
    }
}
