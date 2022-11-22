using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorAdministrationApplicationTests.ServiceTests
{
    public class CaseTests
    {
        
        private Mock<ICaseService> _sut;
        public CaseTests()
        {
            _sut = new Mock<ICaseService>();
        }

        [Fact]
        public void GetCases_returns_a_list_of_CaseModel()
        {
            //Arrange
            var caseList = new List<CaseModel>();
            //Act
            _sut.Setup(a => a.GetCases()).Returns(caseList);
            //Assert
            Assert.IsType<List<CaseModel>>(_sut.Object.GetCases());
        }
        [Fact]
        public void GetCase_returns_CaseModel()
        {
            //Arrange
            var Case = new CaseModel();
            //Act
            _sut.Setup(a => a.GetCase(It.IsAny<int>())).Returns(Case);
            //Assert
            Assert.IsType<CaseModel>(_sut.Object.GetCase(It.IsAny<int>()));
        }
    }
}
