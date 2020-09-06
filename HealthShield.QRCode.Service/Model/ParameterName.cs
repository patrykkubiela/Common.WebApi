using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace HealthShield.QRCode.Service.Model
{
    public class ParameterName
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }

    internal class ParameterNameEntityTypeConfiguration : IEntityTypeConfiguration<ParameterName>
    {
        public void Configure(EntityTypeBuilder<ParameterName> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("ParameterName");

            entityTypeBuilder.HasKey(e => e.Id);
            
            entityTypeBuilder
                .HasMany(e => e.ParameterValues)
                .WithOne(e => e.ParameterName)
                .HasForeignKey(e => e.ParameterNameId);
        }
    }
}
