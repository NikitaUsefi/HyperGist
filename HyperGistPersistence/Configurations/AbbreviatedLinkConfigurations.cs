using HyperGistDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistPersistence.Configurations
{
    public class AbbreviatedLinkConfigurations : BaseEntityConfigurations<AbbreviatedLink>
    {
        public override void Configure(EntityTypeBuilder<AbbreviatedLink> modelBuilder)
        {
            base.Configure(modelBuilder);
          
            modelBuilder.Property(x => x.ShortLink)
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");
            modelBuilder.Property(x => x.FullLink)
                         .IsRequired()
                         .HasColumnType("nvarchar(max)");
            modelBuilder.HasIndex(x => x.ShortLink)
                       .HasName($"IX_{nameof(AbbreviatedLink)}_{nameof(AbbreviatedLink.ShortLink)}")
                       .IsUnique(true);
        }
    }

}
