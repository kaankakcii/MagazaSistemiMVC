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
   
        public class PersonnelMap : EntityTypeConfiguration<Personnel>
        {

            public PersonnelMap()
            {

                this.ToTable("tblPersonel");
            this.Property(p => p.PersonelId).HasColumnType("int");
            this.Property(p => p.PersonelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.PersonelName).HasColumnType("varchar").HasMaxLength(100);
                this.Property(p => p.PersonelSurname).HasColumnType("varchar").HasMaxLength(100);
                this.Property(p => p.PersonelTelephone).HasColumnType("int");
                this.Property(p => p.PersonelPassword).HasColumnType("varchar").HasMaxLength(100);
                this.Property(p => p.PersonelMail).HasColumnType("varchar").HasMaxLength(100);
                this.Property(p => p.PersonelAddress).HasColumnType("varchar").HasMaxLength(300);
                this.Property(p => p.PersonelEmploymentDate).HasColumnType("varchar").HasMaxLength(100);
                this.Property(p => p.PersonelAge).HasColumnType("int");
                this.Property(p => p.PersonelWage).HasColumnType("int");

                this.HasRequired(p => p.Authority).WithMany(p => p.Personnels).HasForeignKey(p => p.AuthorityId);
               

            }
        }
    }

