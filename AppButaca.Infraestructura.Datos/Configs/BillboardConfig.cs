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
    class BillboardConfig : IEntityTypeConfiguration<BillboardEntity>
    {
        public void Configure(EntityTypeBuilder<BillboardEntity> builder)
        {
            builder.ToTable("TBL_BILLBOARDS");
            //builder.HasKey(x => new { x.Id });
            //builder.HasKey(x => new { x.Id, x.RoomId, x.MovieId });



        }

    }

}
