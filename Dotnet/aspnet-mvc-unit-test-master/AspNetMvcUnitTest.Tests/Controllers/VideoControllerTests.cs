using AspNetMvcUnitTest.Data;
using AspNetMvcUnitTest.Data.Models;
using AspNetMvcUnitTest.Data.Repositories;
using AspNewMvcUnitTest.Web.Controllers;
using AspNewMvcUnitTest.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcUnitTest.Tests.Controllers
{
    [TestClass]
    public class VideoControllerTests
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly Mock<IVideoRepository> _mockVideoRepository = new Mock<IVideoRepository>();
        private VideoController _sut;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork.Videos = _mockVideoRepository.Object;
            _sut = new VideoController(_unitOfWork);
        }

        [TestMethod]
        public void Index_ValidRequest_ReturnsVideos()
        {
            // Arrange
            IList<Video> videos = null;
            _mockVideoRepository.Setup(x => x.GetLatestVideos(It.IsAny<int?>()))
                .Returns<int?>(x => videos = new List<Video> { new Video { Title = "Video 1" }, new Video { Title = "Video 2" } });

            // Act
            var result = _sut.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(videos.Count, ((IEnumerable<Video>)result.Model).Count());
            Assert.AreEqual(videos.First().Title, ((IEnumerable<Video>)result.Model).First().Title);
            Assert.AreEqual(videos.Last().Title, ((IEnumerable<Video>)result.Model).Last().Title);
        }

        [TestMethod]
        public void Details_ValidRequest_ReturnsVideo()
        {
            // Arrange
            var id = 1;
            Video video = null;
            _mockVideoRepository.Setup(x => x.Get(It.IsAny<int>()))
                .Returns<int>(x => video = new Video { VideoId = id, Title = "Video 1" } );

            // Act
            var result = _sut.Details(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            var viewResult = (ViewResult) result;
            var actualVideo = (Video) viewResult.Model;
            Assert.AreEqual(video.VideoId, actualVideo.VideoId);
            Assert.AreEqual(video.Title, actualVideo.Title);
        }

        [TestMethod]
        public void Details_VideoNotFound_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            Video video = null;
            _mockVideoRepository.Setup(x => x.Get(It.IsAny<int>()))
                .Returns<int>(x => video = new Video { VideoId = id, Title = "Video 1" });

            // Act
            var result = _sut.Details(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            var viewResult = (ViewResult)result;
            var actualVideo = (Video)viewResult.Model;
            Assert.AreEqual(video.VideoId, actualVideo.VideoId);
            Assert.AreEqual(video.Title, actualVideo.Title);
        }

        [TestMethod]
        public void Stats_ValidRequest_ReturnsVideoStatsViewModel()
        {
            // Arrange
            IList<Video> latestVideos = null;
            _mockVideoRepository.Setup(x => x.GetLatestVideos(It.IsAny<int?>()))
                .Returns<int?>(x => latestVideos = new List<Video> { new Video { Title = "Video 1" }, new Video { Title = "Video 2" } });
            Video mostViewedVideo = null;
            _mockVideoRepository.Setup(x => x.GetMostViewedVideo())
                .Returns(mostViewedVideo = new Video { Title = "Video 3" });

            // Act
            var result = _sut.Stats();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(result.Model, typeof(VideoStatsViewModel));
            Assert.AreEqual(latestVideos.Count, ((VideoStatsViewModel)result.Model).LatestVideos.Count);
            Assert.AreEqual(mostViewedVideo, ((VideoStatsViewModel)result.Model).MostViewedVideo);
        }
    }
}
