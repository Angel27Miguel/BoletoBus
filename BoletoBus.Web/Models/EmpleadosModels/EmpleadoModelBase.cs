using System.ComponentModel.DataAnnotations;

namespace BoletoBus.Web.Models.EmpleadosModels
{
    public abstract class EmpleadoModelBase
    {
        #region "Atributos"

        public int id { get; set; }
        public string nombre { get; set; }
        public string cargo { get; set; }


        #endregion
    }
}
