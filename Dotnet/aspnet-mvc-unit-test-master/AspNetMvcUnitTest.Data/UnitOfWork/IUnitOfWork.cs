using AspNetMvcUnitTest.Data.Repositories;

namespace AspNetMvcUnitTest.Data
{
    public interface IUnitOfWork
    {
        IVideoRepository Videos { get; set; }

        void Complete();
    }
}