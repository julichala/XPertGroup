namespace BovinosEquinos.Services
{
    using BovinosEquinos.Core.Entities;
    using BovinosEquinos.Data.Interfases;
    using System;
    using System.Collections.Generic;
    public class AnimalesService : Interfases.IAnimalesService
    {
        /// <summary>
        /// Instancia de la interfaz que se inyectará a través del constructor de la clase
        /// </summary>
        private IAnimalRepository repository;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public AnimalesService(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public List<Animal> GetAnimales()
        {
            try
            {
                return repository.GetAnimal();
            }
            catch (Exception ex)
            {
                Core.Utilities.ExceptionHandling.ManageException(ex);
                return null;                
            }            
        }

        public void SaveAnimales(List<Animal> listaAnimales)
        {
            try
            {                
                repository.SaveAnimalesByEspecie(listaAnimales);
            }
            catch (Exception ex)
            {
                Core.Utilities.ExceptionHandling.ManageException(ex);                
            }
        }
    }
}
