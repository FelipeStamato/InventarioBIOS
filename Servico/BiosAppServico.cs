using InventarioBIOS.Handler;

namespace InventarioBIOS.Servicos
{
    public class BiosAppServico
    {
        public static Bios PegaBios(string consulta = null)
        {
            return new BiosHandler(consulta).Executa();
        }
    }
}
