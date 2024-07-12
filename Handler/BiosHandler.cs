using System;
using System.Linq;
using System.Management;

namespace InventarioBIOS.Handler
{

    public class BiosHandler
    {
        public string consulta;

        public BiosHandler(string consulta)
        {
            this.consulta = consulta;
        }

        public Bios Executa()
        {
            try
            {
                if (consulta == null)
                {
                    consulta = "SELECT * FROM Win32_BIOS";
                }

                Bios bios = new ManagementObjectSearcher(consulta)
                                   .Get()
                                   .Cast<ManagementBaseObject>()
                                   .Select(x => new Bios
                                   {
                                       Nome = x["Name"] as string,
                                       Descricao = x["Description"] as string,
                                       Versao = x["Version"] as string,
                                       Build = x["BuildNumber"] as string,
                                       Fabricante = x["Manufacturer"] as string,
                                       Serial = x["SerialNumber"] as string,
                                       VersaoSmbios = x["SMBIOSBIOSVersion"] as string,
                                       SMBIOSAssetTag = PegaAssetTag()
                                   }).FirstOrDefault();
                return bios;
            }
            catch (Exception ex)
            {
                // Log de exceção
            }

            return null;
        }
        private string PegaAssetTag()
        {
            try
            {
                string consultaSystemEnclosure = "SELECT * FROM Win32_SystemEnclosure";
                ManagementObjectSearcher systemEnclosureSearcher = new ManagementObjectSearcher(consultaSystemEnclosure);
                ManagementBaseObject systemEnclosureI = systemEnclosureSearcher.Get().Cast<ManagementBaseObject>().FirstOrDefault();
                return systemEnclosureI["SMBIOSAssetTag"] as string;
            }
            catch (Exception ex)
            {
                // Log de exceção
            }

            return string.Empty;
        }
    }
}

