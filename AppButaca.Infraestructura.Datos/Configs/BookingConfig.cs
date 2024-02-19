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
    class BookingConfig : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("TBL_BOOKINGS");
            //builder.HasKey(x => new { x.Id ,x.BillboardId, x.SeatId, x.CustomerId});
        }
    }
}
