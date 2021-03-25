using System.Data.Entity;

namespace AspNetMvcUnitTest.Data.Models
{
    public class WeTubeContext : DbContext
    {
        public WeTubeContext() : base("name=WeTubeContext")
        {
        }

        public DbSet<Video> Videos { get; set; }
    }
}
