using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunnWebApplication1.Controllers;
using RunnWebApplication1.Interfaces;
using RunnWebApplication1.Models;
using RunnWebApplication1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RunWebApplication1.Tests.Controller
{
    public class ClubControllerTests
    {
        private ClubController _clubController;
        private IClubRepository _clubRepository;
        private IPhotoService _photoService;
        private IHttpContextAccessor _httpContextAccessor;


        public ClubControllerTests()
        {
            _clubRepository = A.Fake<IClubRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT

            _clubController = new ClubController(_clubRepository, _photoService, _httpContextAccessor);
        }
        [Fact]
        public void ClubController_Index_ReturnsSuccess()
        {
            // Arrange What do I need to bring in?
            var clubs = A.Fake<IEnumerable<Club>>();

            A.CallTo(() => _clubRepository.GetAll()).Returns(clubs);

            // Act
            var result = _clubController.Index();

            //Assert - Object check actions

            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Fact]
        public void ClubController_Detail_ReturnsSuccesss()
        {
            //Arrange
            var id = 1;
            var club = A.Fake<Club>();
            A.CallTo(() => _clubRepository.GetByIdAsync(id)).Returns(club);

            //Act

            var result = _clubController.Detail(id);

            //Assert

            result.Should().BeOfType<Task<IActionResult>>();


        }
    }
}
