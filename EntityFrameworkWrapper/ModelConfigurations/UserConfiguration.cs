using System.Data.Entity.ModelConfiguration;
using WordsCountSkyrtaOliinyk.DBModels;

namespace EntityFrameworkWrapper.ModelConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(user => user.Guid);
            Property(user => user.Guid).HasColumnName("Guid").IsRequired();
            Property(user => user.FirstName).HasColumnName("FirstName").IsRequired();
            Property(user => user.LastName).HasColumnName("LastName").IsRequired();
            Property(user => user.Login).HasColumnName("Login").IsRequired();
            Property(user => user.Email).HasColumnName("Email").HasMaxLength(256).IsRequired();
            Property(user => user.Password).HasColumnName("Password").IsRequired();
            Property(user => user.DateOfEnter).HasColumnName("DOE").HasColumnType("datetime2").IsRequired();
            HasIndex(ind => ind.Email).IsUnique(true);
        }
    }
}

