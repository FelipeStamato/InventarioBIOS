using System;
using InventarioBIOS.Handler;

namespace InventarioBIOS.Servicos
{
    class Servico
    {
        public static void Bios()
        {
            BiosHandler bios = new BiosHandler();
            try
            {
                bios.AtualizarInformacoes();
                ImprimeInformacoes(bios);
            }
            catch (Exception ex)
            {
                // Log de exceção
            }
        }
        public static void ImprimeInformacoes(BiosHandler bios)
        {
            Console.WriteLine("Nome: " + bios.Nome);
            Console.WriteLine("Descrição: " + bios.Descricao);
            Console.WriteLine("Versão: " + bios.Versao);
            Console.WriteLine("Build: " + bios.Build);
            Console.WriteLine("Fabricante: " + bios.Fabricante);
            Console.WriteLine("Serial: " + bios.Serial);
            Console.WriteLine("Versão SMBIOS: " + bios.VersaoSmbios);
            Console.WriteLine("SMBIOSAssetTag: " + bios.SMBIOSAssetTag);
        }
    }
}