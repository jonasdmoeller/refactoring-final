using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LegacyApp;

public class UserDataAccess
{
    public void AddUser(User user)
    {
        var users = GetUsers().ToList();
        users.Add(user);
        var usersString = JsonConvert.SerializeObject(users);
        File.WriteAllText(GetUsersFilePath(), usersString);
    }

    private IEnumerable<User> GetUsers()
    {
        var usersString = File.ReadAllText(GetUsersFilePath());
        return JsonConvert.DeserializeObject<IEnumerable<User>>(usersString);
    }

    private string GetUsersFilePath()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var file = Path.Combine(currentDirectory, @"..\..\..\..\LegacyApp\Assets\users.json"); 
        return Path.GetFullPath(file);  
    }
}
