using System;
using System.Linq;
using System.Management;

namespace InventarioBIOS.Handler
{
    public class BiosHandler
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Versao { get; set; }
        public string Build { get; set; }
        public string Fabricante { get; set; }
        public string Serial { get; set; }
        public string VersaoSmbios { get; set; }
        public string SMBIOSAssetTag { get; set; }
        public void AtualizarInformacoes()
        {
            string consultaBios = "SELECT * FROM Win32_BIOS";
            string consultaSystemEnclosure = "SELECT * FROM Win32_SystemEnclosure";
            ManagementObjectSearcher Bios = new ManagementObjectSearcher(consultaBios);
            ManagementObjectSearcher SystemEnclosure = new ManagementObjectSearcher(consultaSystemEnclosure);
            ManagementBaseObject biosInfo = Bios.Get().Cast<ManagementBaseObject>().FirstOrDefault();
            ManagementBaseObject systemEnclosureInfo = SystemEnclosure.Get().Cast<ManagementBaseObject>().FirstOrDefault();

            try
            {
                Nome = biosInfo["Name"] as string;
                Descricao = biosInfo["Description"] as string;
                Versao = biosInfo["Version"] as string;
                Build = biosInfo["BuildNumber"] as string;
                Fabricante = biosInfo["Manufacturer"] as string;
                Serial = biosInfo["SerialNumber"] as string;
                VersaoSmbios = biosInfo["SMBIOSBIOSVersion"] as string;
                SMBIOSAssetTag = systemEnclosureInfo["SMBIOSAssetTag"] as string;
            }
            catch
            {
                // Log de exceção
            }
        }
    }
}
