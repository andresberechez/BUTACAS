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
    class BaseConfig : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.ToTable("TBL_BASE");
            builder.HasKey(x => x.Id);





        }

    }

}
