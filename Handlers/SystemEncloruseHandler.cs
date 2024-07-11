using System;
using System.Management;
using System.Linq;

namespace InventarioBIOS.Handlers
{
    public class SystemEnclosureHandler
    {
        private ManagementScope _scope;

        public SystemEnclosureHandler(ManagementScope scope)
        {
            _scope = scope;
        }

        public string GetAssetTag()
        {
            string assetTag = string.Empty;

            try
            {
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_SystemEnclosure");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(_scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();

                ManagementBaseObject managementObject = queryCollection.Cast<ManagementBaseObject>().FirstOrDefault();

                if (managementObject != null && managementObject["SMBIOSAssetTag"] != null)
                {
                    assetTag = managementObject["SMBIOSAssetTag"].ToString();
                    Console.WriteLine($"Asset Tag adicionado: {assetTag}");
                }
                else
                {
                    Console.WriteLine("Asset Tag não encontrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter Asset Tag: {ex.Message}");
            }

            return assetTag;
        }
    }
}
