using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoletoBus.Modulo.Domain.Entities.Empleado
{
    public class Empleados : AuditEntity<int>
    {
        #region "Atributos"

        [Column("IdEmpleado")]

        public override int Id { get; set; }

    }
    #endregion
}