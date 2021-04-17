using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models;

namespace SharedKernel.Data.Configurations.CoreDbContext
{
    public class CastActorEntityTypeConfiguration : BaseEntityTypeConfigurationNoVersioning<CastActor, Guid>
    {
        public override void Configure(EntityTypeBuilder<CastActor> builder)
        {
            base.Configure(builder);

            builder.HasData(
                new CastActor
                {
                    Id = new Guid("d3940e55-c01f-4322-818b-85e8c1e69995"),
                    CastId = new Guid("3d5531dd-f2cc-4922-8f3c-8ca1918a294b"),
                    ActorId = new Guid("7945162a-95e4-4fc8-8aad-1e99fbc850c0")
                },
                new CastActor
                {
                    Id = new Guid("066548a7-01fd-4f7b-bdb7-aa4dd151ca3e"),
                    CastId = new Guid("3d5531dd-f2cc-4922-8f3c-8ca1918a294b"),
                    ActorId = new Guid("a999e831-978f-49b6-8c1c-ff82bb3231f3")
                }
            );
        }
    }
}