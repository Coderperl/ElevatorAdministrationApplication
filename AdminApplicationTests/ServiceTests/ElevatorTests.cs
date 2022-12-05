using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Moq;
using AutoFixture;

namespace ElevatorAdministrationApplicationTests.ServiceTests
{
    public class ElevatorTests
    {
        private readonly ElevatorService _sut;
        private Mock<IElevatorService> _elevatorService;

        public ElevatorTests()
        {
            _elevatorService = new Mock<IElevatorService>();
        }

        [Fact]
        public void GetElevators_returns_a_list_of_elevatormodel()
        {
            _elevatorService.Setup(a => a.GetElevators()).Returns(new List<ElevatorModel>());        

            Assert.IsType<List<ElevatorModel>>(_elevatorService.Object.GetElevators());
        }
        [Fact]
        public void GetElevator_returns_elevatormodel()
        {
            _elevatorService.Setup(a => a.GetElevator(It.IsAny<int>())).Returns(new ElevatorModel());

            Assert.IsType<ElevatorModel>(_elevatorService.Object.GetElevator(It.IsAny<int>()));
        }
    }
}
