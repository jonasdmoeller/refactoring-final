using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace LegacyApp;

public class ClientRepository
{
    public static Client GetById(int id)
    {
        var jsonString = GetDocumentAsString();
        var clients = JsonConvert.DeserializeObject<List<Client>>(jsonString);
        var client = clients.FirstOrDefault(c => c.Id == id);
        
        if (client == null)
        {
            throw new Exception("Client not found");
        }

        return client;
    }

    private static string GetDocumentAsString()
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LegacyApp.Assets.clients.json");
        using var reader = new StreamReader(stream!);
        return reader.ReadToEnd();
    }
}