namespace BovinosEquinos.Core
{
    using System.Web.Configuration;

    /// <summary>
    /// Aquí se implementará la regla de negocio que indica "los Bovinos siempre tienen una “B” en el nombre" y se hará dinámico a través del 
    /// web.config por si la regla de negocio es cambiada. 
    /// </summary>
    public class BusinessRules
    {
        public static string GetEspeciePorNombre(string nombre)
        {
            //La llave del Web.Config tiene la letra indicada por la regla de negocio o en su defecto, varias letras separadas por comas
            //que corresponden a las letras que tiene el animal en el nombre para determinar si es un bovino.
            string LetrasBovinos = WebConfigurationManager.AppSettings[Utilities.Constants.LETRASESPECIEBOVINO];

            char separador = ',';
            string[] ArrLetrasBovinos = LetrasBovinos.Split(separador);

            bool esBovino = true;

            //Se itera sobre las letras, si el nombre no contiene aluna de las letras de la regla de negocio es porque
            //el animal no es bovino sino que es equino
            foreach (string item in ArrLetrasBovinos)
            {
                if (!nombre.ToLower().Contains(item.ToLower()))
                {
                    esBovino = false;
                    break;
                }
            }

            return esBovino ? Utilities.Constants.BOVINO : Utilities.Constants.EQUINO;
        }
    }
}
