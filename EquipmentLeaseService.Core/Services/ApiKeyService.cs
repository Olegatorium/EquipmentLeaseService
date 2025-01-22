using EquipmentLeaseService.Core.ServiceContracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Services
{
    public class ApiKeyService : IApiKeyService
    {
        private static string _currentApiKey;
        private static readonly ConcurrentDictionary<string, bool> _apiKeyStore = new();

        public ApiKeyService(IConfiguration configuration)
        {
            _currentApiKey = configuration["ApiKey"] ?? GenerateApiKey();
            _apiKeyStore[_currentApiKey] = true;
        }

        public string GetApiKey() => _currentApiKey;

        public void RotateApiKey()
        {
            var newApiKey = GenerateApiKey();
            _apiKeyStore[newApiKey] = true;
            _currentApiKey = newApiKey;
        }

        private string GenerateApiKey() => Guid.NewGuid().ToString("N");
    }
}
