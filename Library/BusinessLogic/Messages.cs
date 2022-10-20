using Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.BusinessLogic;

public class Messages : IMessages
{
    private ILogger<Messages> _logger;

    public Messages(ILogger<Messages> logger)
    {
        _logger = logger;
    }

    public string Greeting(string language)
    {
        return LookupCustomText("Greeting", language);
    }

    private string LookupCustomText(string key, string language)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            List<CustomText>? messageSets = JsonSerializer.Deserialize<List<CustomText>>
                (File.ReadAllText("CustomText.json"), options);

            CustomText? messages = messageSets?.Where(x => x.Language == language).First();

            if (messages is null)
            {
                throw new NullReferenceException("The specified language was not found in the json");
            }

            return messages.Translations[key];
        }
        catch (Exception ex)
        {
            _logger.LogError("Error loading CustomText.json", ex);
            throw;
        }
    }
}
