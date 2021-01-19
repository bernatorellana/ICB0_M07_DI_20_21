using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210118_DemoDocumentacio.model
{
    /// <summary>
    ///  La classe vehicle representa tots els vehicles de la nostra flota..
    /// </summary>
    public  class Vehicle
    {
        private String matricula;
        private long numeroBastidor;
        private String marca;
        private String model;

        /// <summary>
        /// # Constructor base de la classe vehicle
        /// Per aquesta classe tindrem les següents subclasses:
        /// * Cotxe
        /// * Moto
        /// * "Furgoneta"
        /// 
        /// ## Altres subclasses
        /// 1. Primera
        /// 1. Segona
        /// 1. Tercera
        /// 
        /// ## Exemples
        /// 
        /// ### Exemple 1
        /// 
        /// <code language="csharp">
        /// <![CDATA[
        ///     Vehicle v = new Vehicle( "3423-YTR", 123123123123123123, "Seat", "Leon 4");
        /// ]]>
        /// </code>
        /// 
        ///  ### Exemple 2 (amb referència)
        /// 
        /// <code language="csharp" region="exemple_1" source="..\model\Vehicle.cs"></code>
        /// 
        /// </summary>
        /// <param name="matricula">Matricula en format "9999-XXX", no nul·la.</param>
        /// <param name="numeroBastidor"> Numèric de 20 posicions.</param>
        /// <param name="marca">Nom de la marca, mínim 3 caràcters.</param>
        /// <param name="model">Nom del model, mínim 1 caràcter</param>
        public Vehicle(string matricula, long numeroBastidor, string marca, string model)
        {
            this.Matricula = matricula;
            this.NumeroBastidor = numeroBastidor;
            this.Marca = marca;
            this.Model = model;
        }

        /// <summary>
        /// Matricula
        /// </summary>
        public string Matricula { get => matricula; set => matricula = value; }

        /// <summary>
        /// Número de bastidor
        /// </summary>
        public long NumeroBastidor { get => numeroBastidor; set => numeroBastidor = value; }

        /// <summary>
        /// La marca del vehicle. És un camp obligatori i com a mínim té 3 caràcters.
        /// </summary>
        public string Marca { get => marca; 
            set {
               if (value == null || value.Trim().Length < 3) throw new Exception("Marca invàlida.");
                marca = value; 
            } }

        /// <summary>
        /// El model del cotxe
        /// </summary>
        public string Model { get => model; set => model = value; }

        #region exemple_1
        private static void exemple_1()
        {
            Vehicle v = new Vehicle( "3423-YTR", 123123123123123123, "Seat", "Leon 4");
        }
        #endregion exemple_1


    }
}
