using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models;

namespace SharedKernel.Data.Configurations.CoreDbContext
{
    public class CastTvShowEntityTypeConfiguration : BaseEntityTypeConfigurationNoVersioning<CastTvShow, Guid>
    {
        public override void Configure(EntityTypeBuilder<CastTvShow> builder)
        {
            base.Configure(builder);

            builder.HasData();
        }
    }
}
