using AspNetMvcUnitTest.Data;
using AspNewMvcUnitTest.Web.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AspNewMvcUnitTest.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index()
        {
            var videos = _unitOfWork.Videos.GetLatestVideos(5);

            return View(videos);
        }

        public ActionResult Details(int id)
        {
            var video = _unitOfWork.Videos.Get(id);

            if (video == null)
                return HttpNotFound();

            return View(video);
        }

        public ViewResult Stats()
        {
            var latestVideos = _unitOfWork.Videos.GetLatestVideos(5).ToList();
            var mostViewedVideo = _unitOfWork.Videos.GetMostViewedVideo();

            var model = new VideoStatsViewModel
            {
                Title = "Video Stats as of " + DateTime.Today,
                LatestVideos = latestVideos,
                MostViewedVideo = mostViewedVideo
            };

            return View(model);
        }
    }
}