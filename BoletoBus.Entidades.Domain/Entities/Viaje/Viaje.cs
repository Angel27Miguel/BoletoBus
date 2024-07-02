﻿using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoletoBus.Entidades.Domain.Entities.Viaje
{
    public class Viaje : AuditEntity<int>
    {
        [Column("IdViaje")]
        public override int Id { get; set; }
    }
}
