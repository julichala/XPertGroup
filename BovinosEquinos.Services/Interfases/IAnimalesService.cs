namespace BovinosEquinos.Services.Interfases
{
    using BovinosEquinos.Core.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Interface que expone los métodos disponibles para el servicio de Animales
    /// </summary>
    public interface IAnimalesService
    {
        List<Animal> GetAnimales();
        void SaveAnimales(List<Animal> lstAnimal);
    }
}
