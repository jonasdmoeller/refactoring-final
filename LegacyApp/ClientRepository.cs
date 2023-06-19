using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LegacyApp;

public class ClientRepository
{
    public Client GetById(int id)
    {
        var jsonString = File.ReadAllText(GetUsersFilePath());
        var clients = JsonConvert.DeserializeObject<List<Client>>(jsonString);
        var client = clients.FirstOrDefault(c => c.Id == id);
        
        if (client == null)
        {
            throw new Exception("Client not found");
        }

        return client;
    }

    private string GetUsersFilePath()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var file = Path.Combine(currentDirectory, @"..\..\..\..\LegacyApp\Assets\clients.json"); 
        return Path.GetFullPath(file);  
    }
}
