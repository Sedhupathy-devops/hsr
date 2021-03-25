using AspNetMvcUnitTest.Data.Models;
using AspNetMvcUnitTest.Data.Repositories;

namespace AspNetMvcUnitTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeTubeContext _context;

        public UnitOfWork()
        {
            _context = new WeTubeContext();

            Videos = new VideoRepository(_context);
        }

        public IVideoRepository Videos { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}