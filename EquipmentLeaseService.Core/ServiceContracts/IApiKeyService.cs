using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.ServiceContracts
{
    public interface IApiKeyService
    {
        string GetApiKey();
        void RotateApiKey();
    }
}
