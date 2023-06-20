using System;

namespace LegacyApp;

public class UserCreditService
{
    private readonly Random _rand;

    public UserCreditService()
    {
        _rand = new Random();
    }
    public int GetCreditLimit(string firstname, string surname, DateTime dateOfBirth)
    {
        return firstname.Contains('r') ? 0 : _rand.Next(1, 20000);
    }
}
