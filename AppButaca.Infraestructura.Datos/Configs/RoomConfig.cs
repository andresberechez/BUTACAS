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
    class RoomConfig : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.ToTable("TBL_ROOMS");
            //builder.HasKey(x =>  x.Id);
        }
    }
}
