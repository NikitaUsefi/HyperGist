using HyperGistDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistPersistence.Configurations
{
    public class AbbreviatedLinkCounterConfigurations : BaseEntityConfigurations<AbbreviatedLinkCounter>
    {
        public override void Configure(EntityTypeBuilder<AbbreviatedLinkCounter> modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Property(x => x.Prefix)
                         .IsRequired()
                         .HasColumnType("nvarchar(50)");
            modelBuilder.Property(x => x.LastCount)
                         .IsRequired()
                         .HasColumnType("nvarchar(50)");
        }
    }

}
