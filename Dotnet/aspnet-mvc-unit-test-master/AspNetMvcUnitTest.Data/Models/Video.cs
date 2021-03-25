using System;

namespace AspNetMvcUnitTest.Data.Models
{
    public class Video
    {
        public int VideoId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public int Duration { get; set; }

        public int ViewCount { get; set; }

        public DateTime UploadTime { get; set; }
    }
}
