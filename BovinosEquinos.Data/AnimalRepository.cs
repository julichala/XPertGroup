namespace BovinosEquinos.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using BovinosEquinos.Core.Entities;
    using BovinosEquinos.Core;

    /// <summary>
    /// Clase que implementa la interfaz del repositorio la cual leerá desde el archivo y guardará los animales según el caso
    /// </summary>
    public class AnimalRepository : Interfases.IAnimalRepository
    {
        /// <summary>
        /// Obtiene los animales del archivo y los guarda en una lista
        /// </summary>
        /// <returns>retorna la lista con los animales ya clasificados por especie</returns>
        public List<Animal> GetAnimal()
        {
            List<Animal> ListaAnimales = new List<Animal>();
            Animal ObjAnimal;
            
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Core.Utilities.Constants.CARPETAARCHIVOS, Core.Utilities.Constants.NOMBREARCHIVO);
            
            var lines = File.ReadLines(filename);
            foreach (var line in lines)
            {
                ObjAnimal = new Animal(line.ToString());
                ListaAnimales.Add(ObjAnimal);
            }

            return ListaAnimales;
        }

        /// <summary>
        /// Guarda los 2 archiovs planos según la especie, dependiendo de la regla del negocio.
        /// </summary>
        /// <param name="listaAnimales"></param>
        /// <returns></returns>
        public bool SaveAnimalesByEspecie(List<Animal> listaAnimales)
        {

            string filenameBovinos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Core.Utilities.Constants.CARPETAARCHIVOS, Core.Utilities.Constants.ARCHIVOBOVINOS);
            string filenameEquinos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Core.Utilities.Constants.CARPETAARCHIVOS, Core.Utilities.Constants.ARCHIVOEQUINOS);

            File.Delete(filenameBovinos);
            File.Delete(filenameEquinos);

            foreach (Animal item in listaAnimales)
            {
                if (item.Especie.NombreEspecie.Equals(Core.Utilities.Constants.BOVINO))
                {
                    if (!File.Exists(filenameBovinos))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(filenameBovinos))
                        {
                            sw.WriteLine(item.Nombre);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(filenameBovinos))
                        {
                            sw.WriteLine(item.Nombre);
                        }
                    }
                }

                if (item.Especie.NombreEspecie.Equals(Core.Utilities.Constants.EQUINO))
                {
                    if (!File.Exists(filenameEquinos))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(filenameEquinos))
                        {
                            sw.WriteLine(item.Nombre);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(filenameEquinos))
                        {
                            sw.WriteLine(item.Nombre);
                        }
                    }
                }
            }

            return true;
        }
    }
}
