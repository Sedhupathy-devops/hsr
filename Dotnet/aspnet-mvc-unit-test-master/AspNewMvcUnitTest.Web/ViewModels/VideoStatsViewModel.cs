using AspNetMvcUnitTest.Data.Models;
using System.Collections.Generic;

namespace AspNewMvcUnitTest.Web.ViewModels
{
    public class VideoStatsViewModel
    {
        public string Title { get; set; }

        public IList<Video> LatestVideos { get; set; }

        public Video MostViewedVideo { get; set; }
    }
}