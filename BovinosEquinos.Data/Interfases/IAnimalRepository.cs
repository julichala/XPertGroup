namespace BovinosEquinos.Data.Interfases
{
    using BovinosEquinos.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAnimalRepository
    {
        /// <summary>
        /// Método que obtiene todos los animales del repositorio
        /// </summary>
        /// <returns></returns>
        List<Animal> GetAnimal();

        bool SaveAnimalesByEspecie(List<Animal> lstAnimales);

    }
}
