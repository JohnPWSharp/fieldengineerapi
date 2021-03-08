using Microsoft.EntityFrameworkCore;

namespace FieldEngineerApi.Models
{

    public class BoilerPartsContext : DbContext
    {
        public BoilerPartsContext(DbContextOptions<BoilerPartsContext> options)
            : base(options)
        {

        }

        public DbSet<BoilerPart> BoilerParts { get; set; }
    }

}