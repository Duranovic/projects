using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models;

namespace SharedKernel.Data.Configurations.CoreDbContext
{
    public class CastMovieEntityTypeConfiguration : BaseEntityTypeConfigurationNoVersioning<CastMovie, Guid>
    {
        public override void Configure(EntityTypeBuilder<CastMovie> builder)
        {
            base.Configure(builder);

            builder.HasData(
                new CastMovie
                {
                    Id = new Guid("f55f1898-3a6f-44ce-aee9-219dab718c3c"),
                    CastId = new Guid("3d5531dd-f2cc-4922-8f3c-8ca1918a294b"),
                    MovieId = new Guid("1aee9219-d85d-424c-adf9-a504a1b1f698")
                },
                new CastMovie
                {
                    Id = new Guid("200a9565-0135-41c9-9943-9c5adf40abf0"),
                    CastId = new Guid("c32c6133-977a-4a86-a95b-293861f58fd5"),
                    MovieId = new Guid("db03a785-ffbb-4599-9add-763ae9156d83")
                },
                new CastMovie
                {
                    Id = new Guid("b4462faf-1d7c-403a-9d93-c2bc6db50aad"),
                    CastId = new Guid("907c9c63-ac99-4832-a28a-20291ebdec56"),
                    MovieId = new Guid("1f921843-87da-476b-8dfb-4ab892977ba1")
                },
                new CastMovie
                {
                    Id = new Guid("483de099-44c2-4c70-a8da-eae68c124a22"),
                    CastId = new Guid("4e9bbba5-cb2c-444e-83bc-fc10c8e8c8c4"),
                    MovieId = new Guid("db03a785-ffbb-4599-9add-763ae9156d83")
                },
                new CastMovie
                {
                    Id = new Guid("427643bd-1465-4ec3-b194-bc959137bfb9b"),
                    CastId = new Guid("4e9bbba5-cb2c-444e-83bc-fc10c8e8c8c4"),
                    MovieId = new Guid("1f921843-87da-476b-8dfb-4ab892977ba1")
                },
                new CastMovie
                {
                    Id = new Guid("13cd344a-fc86-4974-9924-ab91fff0fd79"),
                    CastId = new Guid("d964f7e3-5cb7-43c5-9b4d-4065dd0dcdcd"),
                    MovieId = new Guid("de0d2ad7-d56e-41c5-9dbd-23fec0f11fa2")
                },
                new CastMovie
                {
                    Id = new Guid("4db6c2ae-66ac-4700-aeae-38c179715b2d"),
                    CastId = new Guid("7792a1fe-efc3-4dd6-80b6-31ffcd4d03ce"),
                    MovieId = new Guid("1f37fef0-edd9-444c-920f-804d95a43fb8")
                },
                new CastMovie
                {
                    Id = new Guid("49cf59b0-9233-40a4-b693-de1c38e2522c"),
                    CastId = new Guid("a97998dd-bf9a-4ca7-85f2-c7456ca54794"),
                    MovieId = new Guid("15a5b405-4f7f-4a67-9899-eb52326860ba")
                },
                new CastMovie
                {
                    Id = new Guid("c5f9b948-7a86-4a76-8237-a7eee1ed8da8"),
                    CastId = new Guid("bc2b5e6f-4aaa-4998-af0f-6de2c8aa1ae9"),
                    MovieId = new Guid("a01b2cf7-9496-4bb5-80ba-d475723897a7")
                },
                new CastMovie
                {
                    Id = new Guid("870e522a-bef6-47fd-bf00-05ce6b7de7e4"),
                    CastId = new Guid("8f059533-25f4-4465-90b0-2ca13b6bb155"),
                    MovieId = new Guid("46b687b2-6143-4255-800d-a4a1a2939d25")
                }
            );
        }
    }
}