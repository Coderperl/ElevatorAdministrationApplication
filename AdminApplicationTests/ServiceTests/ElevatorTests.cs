using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ElevatorAdministrationApplicationTests.ServiceTests
{
    public class ElevatorTests
    {
        private readonly ElevatorService _sut;
        
        public ElevatorTests()
        {
            _sut = new ElevatorService();
        }

        [Fact]
        public void GetElevators_returns_a_list_of_elevatormodel()
        {
            var elevators = _sut.GetElevators();

            Assert.IsType<List<ElevatorModel>>(elevators);
        }
        [Fact]
        public void GetElevator_returns_elevatormodel()
        {
            var elevator = _sut.GetElevator(1);

            Assert.IsType<ElevatorModel>(elevator);
        }
    }
}
