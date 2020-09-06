using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthShield.QRCode.Service.Model
{
    public class ParameterValue
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int ParameterNameId { get; set; }
        public virtual ParameterName ParameterName { get; set; }
    }
    
    internal class ParameterValueEntityTypeConfiguration : IEntityTypeConfiguration<ParameterValue>
    {
        public void Configure(EntityTypeBuilder<ParameterValue> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("ParameterValue");

            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder
                .HasOne(e => e.ParameterName)
                .WithMany(e => e.ParameterValues)
                .HasForeignKey(e => e.ParameterNameId);
        }
    }
}
