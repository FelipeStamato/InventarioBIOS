using System;
using System.Management;
using System.Linq;


namespace InventarioBIOS.Handlers 
{
    public class BiosHandler
    {
        private ManagementScope _scope;

        public BiosHandler(ManagementScope scope)
        {
            _scope = scope;
        }

        public Bios GetBiosInfo()
        {
            Bios biosInfo = new Bios();

            try
            {
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_BIOS");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(_scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();

                ManagementBaseObject managementObject = queryCollection.Cast<ManagementBaseObject>().FirstOrDefault();

                if (managementObject != null)
                {
                    biosInfo.Nome = managementObject["Name"]?.ToString();
                    biosInfo.Descricao = managementObject["Description"]?.ToString();
                    biosInfo.Versao = managementObject["Version"]?.ToString();
                    biosInfo.Build = managementObject["BuildNumber"]?.ToString();
                    biosInfo.Fabricante = managementObject["Manufacturer"]?.ToString();
                    biosInfo.Serial = managementObject["SerialNumber"]?.ToString();
                    biosInfo.VersaoSmbios = managementObject["SMBIOSBIOSVersion"]?.ToString();
                }
                else
                {
                    Console.WriteLine("Informações da BIOS não encontradas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter informações da BIOS: {ex.Message}");
            }

            return biosInfo;
        }
    }
}
