using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppButaca.Infraestructura.Datos.Configs
{
    class SeatConfig : IEntityTypeConfiguration<SeatEntity>
    {
        public void Configure(EntityTypeBuilder<SeatEntity> builder)
        {
            builder.ToTable("TBL_SEATS");
            //builder.HasKey(x => new { x.Id, x.RoomId });


            /*builder
                .HasOne(seat => seat.Room)
                .WithMany(room => room.);*/



        }
    }
}
