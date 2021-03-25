using AspNetMvcUnitTest.Data.Models;
using System.Collections.Generic;

namespace AspNetMvcUnitTest.Data.Repositories
{
    public interface IVideoRepository : IRepository<Video>
    {
        Video GetMostViewedVideo();
        IEnumerable<Video> GetLatestVideos(int? count);
    }
}