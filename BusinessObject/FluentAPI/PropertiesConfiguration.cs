using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPI
{
    public class PropertiesConfiguration : IEntityTypeConfiguration<Propertie>
    {
        public void Configure(EntityTypeBuilder<Propertie> builder)
        {
            builder.ToTable("Propertie");
            builder.HasKey(x => x.PID);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Price);
            builder.Property(x => x.Status);
           







        }
    }
}
