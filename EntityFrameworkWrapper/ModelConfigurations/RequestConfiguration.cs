using System.Data.Entity.ModelConfiguration;
using WordsCountSkyrtaOliinyk.DBModels;

namespace EntityFrameworkWrapper.ModelConfigurations
{
    public class RequestConfiguration : EntityTypeConfiguration<Request>
    {
        public RequestConfiguration()
        {
            ToTable("Requests");
            HasKey(d => d.Guid);
            Property(d => d.Guid).HasColumnName("Id").IsRequired();
            Property(d => d.Path).HasColumnName("Path").IsRequired();
            Property(d => d.DateOfRequest).HasColumnName("DOR").HasColumnType("datetime2").IsRequired();
            Property(d => d.CharsNumber).HasColumnName("Chars").IsRequired();
            Property(d => d.WordsNumber).HasColumnName("Words").IsRequired();
            Property(d => d.StringsNumber).HasColumnName("Strings").IsRequired();

        }
    }
}
