using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApi.Models;

namespace TaskApi.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<Models.Todo>
    {
        public void Configure(EntityTypeBuilder<Models.Todo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
