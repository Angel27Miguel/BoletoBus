﻿
using BoletoBus.Reserva.Application.Base;
using BoletoBus.Reserva.Application.Dtos;

namespace BoletoBus.Reserva.Application.Interfaces
{
    public interface  IReservaServices
    {
        ServiceResult GetReselva();
        ServiceResult GetReselvaById(int Id);
        ServiceResult GuardarReserva(ReservaGuardarModel guardarReserva);
        ServiceResult EditarReserva(ReservaEditarModel editarReserva);
        ServiceResult EliminarReserva(ReservaEliminarModel eliminarReserva);

    }
}