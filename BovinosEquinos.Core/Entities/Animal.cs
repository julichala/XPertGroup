namespace BovinosEquinos.Core.Entities
{
    /// <summary>
    /// Clase que representa un animal
    /// </summary>
    public class Animal : BaseClass
    {
        public string Nombre { get; set; }
        public Especie Especie { get; set; }

        /// <summary>
        /// Constructor de la clase en donde se va a implementar la validación de qué especie es según lo que contenga el nomrbe
        /// </summary>
        public Animal(string nombre)
        {
            this.Nombre = nombre;
            Especie ObjEspecie = new Especie();
            ObjEspecie.NombreEspecie = BusinessRules.GetEspeciePorNombre(nombre);            
            this.Especie = ObjEspecie;
        }
    }
}
