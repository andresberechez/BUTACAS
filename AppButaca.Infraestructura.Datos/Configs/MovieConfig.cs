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
    class MovieConfig : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("TBL_MOVIES");
            //builder.HasKey(x => x.Id);
        }

    }

}
