using AspNetMvcUnitTest.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetMvcUnitTest.Data.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        private readonly WeTubeContext _context;

        public VideoRepository(WeTubeContext context) : base(context)
        {
            _context = context;
        }

        public Video GetMostViewedVideo()
        {
            return _context.Videos
                .OrderByDescending(x => x.ViewCount)
                .Take(1)
                .Single();
        }

        public IEnumerable<Video> GetLatestVideos(int? count = 5)
        {
            return _context.Videos
                .Take(count.GetValueOrDefault())
                .ToList();
        }
    }
}
