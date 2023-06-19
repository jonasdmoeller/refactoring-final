using System;

namespace LegacyApp.Consumer;

class Program
{
    static void Main(string[] args)
    {
        AddUser(args);
    }

    public static void AddUser(string[] args)
    {
        // DO NOT CHANGE THIS FILE AT ALL
            
        var userService = new UserService();
        var addResult = userService.AddUser("Magni", "Thorson", "magni@northerngods.com", new DateTime(1993, 1, 1), 4);
        Console.WriteLine("Adding Magni was " + (addResult ? "successful" : "unsuccessful"));
        addResult = userService.AddUser("Modi", "Thorson", "modi@northerngods.com", new DateTime(1993, 1, 1), 4);
        Console.WriteLine("Adding Modi was " + (addResult ? "successful" : "unsuccessful"));
        Console.ReadLine();
    }
}
