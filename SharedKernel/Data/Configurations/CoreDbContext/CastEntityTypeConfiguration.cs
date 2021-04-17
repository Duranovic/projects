using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models;

namespace SharedKernel.Data.Configurations.CoreDbContext
{
    public class CastEntityTypeConfiguration : BaseEntityTypeConfigurationNoVersioning<Cast, Guid>
    {
        public override void Configure(EntityTypeBuilder<Cast> builder)
        {
            base.Configure(builder);

            builder
                .HasMany(p => p.CastActors)
                .WithOne(p => p.Cast);

            builder.HasData(
                new Cast
                {
                    Id = new Guid("3d5531dd-f2cc-4922-8f3c-8ca1918a294b")
                },
                new Cast
                {
                    Id = new Guid("c32c6133-977a-4a86-a95b-293861f58fd5")
                },
                new Cast
                {
                    Id = new Guid("907c9c63-ac99-4832-a28a-20291ebdec56")
                },
                new Cast
                {
                    Id = new Guid("4e9bbba5-cb2c-444e-83bc-fc10c8e8c8c4")
                },
                new Cast
                {
                    Id = new Guid("d964f7e3-5cb7-43c5-9b4d-4065dd0dcdcd")
                },
                new Cast
                {
                    Id = new Guid("7792a1fe-efc3-4dd6-80b6-31ffcd4d03ce")
                },
                new Cast
                {
                    Id = new Guid("a97998dd-bf9a-4ca7-85f2-c7456ca54794")
                },
                new Cast
                {
                    Id = new Guid("bc2b5e6f-4aaa-4998-af0f-6de2c8aa1ae9")
                },
                new Cast
                {
                    Id = new Guid("8f059533-25f4-4465-90b0-2ca13b6bb155")
                }
            );
        }
    }
}