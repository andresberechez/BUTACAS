using AppButaca.Aplicaciones.Interfaces;
using AppButaca.dominio;
using AppButaca.Infraestructura.Datos.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.Infraestructura.Datos.Repositorios
{
    internal class SeatRepositorio : IServicioSeatTransactions<SeatEntity>
    {
        private ButacasContexto db;

        public SeatRepositorio(ButacasContexto _db)
        {
            db = _db;
        }


        //=================================
        // ORDEN - 3A
        //=================================
        public object Inhabilitar(SeatEntity entidadId)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())

                try

                {
                    var asiento = db.Seats.Find(entidadId);

                    if (asiento != null)
                    {
                        asiento.Status = false;
                        db.SaveChanges();
                        dbContextTransaction.Commit();

                        var asientoInhabilitado = db.Seats.Find(entidadId);
                        //var asientoInhabilitado2 = db.Seats.Where(s => s.Id == entidadId);

                        var asientoModificado = new
                        {
                            number = asientoInhabilitado.Number,
                            rowNumber = asientoInhabilitado.Number,
                            roomName = asientoInhabilitado.RoomId,
                            status = asientoInhabilitado.Status
                        };

                        return asientoModificado;

                    }
                    else
                    {
                        throw new Exception("El asiento especificado no existe.");
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception("Error al inhabilitar el asiento: " + ex.Message);
                }
        }



    }


}
