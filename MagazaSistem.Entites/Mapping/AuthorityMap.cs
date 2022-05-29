using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Mapping
{
     public class AuthorityMap : EntityTypeConfiguration<Authority>
    {
        public AuthorityMap()
        {

            this.ToTable("tblAuthority");
            this.Property(p => p.AuthorityId).HasColumnType("int");
            this.Property(p => p.AuthorityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.AuthorityName).HasColumnType("varchar").HasMaxLength(100);


        }
    }
}
