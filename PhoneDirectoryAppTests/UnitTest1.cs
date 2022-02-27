using Xunit;
using PersonAPI.Controllers;
using PersonAPI.Models;
using PersonAPI.Services;
using FakeItEasy;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PhoneDirectoryAppTests
{
    public class UnitTest1
    {
        [Fact]
        public void HomeControllerGetContactById()
        {
            //Arrange
            string id = "621860bbd7d08938cc97fb2f";
            person fakePerson = new person();
            fakePerson.id = "621860bbd7d08938cc97fb20";
            fakePerson.firstName = "Merve";
            fakePerson.lastName = "Eser";
            fakePerson.company = "Rise Techonology";

            var dataStore = A.Fake<personService>();
            var controller = new personController(dataStore);

            //Act
            var actionResult = controller.Get(id);

            //Assert
            var res = actionResult;
            var returnPerson = res;
            Assert.Equal(returnPerson.firstName, fakePerson.firstName);
        }

        [Fact]
        public void HomeControllerGetAll()
        {
            //Arrange
            List<person> pList = new List<person>();
            person fakePerson = new person();
            fakePerson.id = "621860bbd7d08938cc97fb20";
            fakePerson.firstName = "Merve";
            fakePerson.lastName = "Eser";
            fakePerson.company = "Rise Techonology";

            pList.Add(fakePerson);

            var dataStore = A.Fake<personService>();
            var controller = new personController(dataStore);

            //Act
            var actionResult = controller.Get();

            //Assert
            var res = actionResult;
            var returnPerson = res;
            Assert.Equal(returnPerson[0].firstName, fakePerson.firstName);
        }

        [Fact]
        public void HomeControllerCreatePerson()
        {
            //Arrange
            person fakePerson = new person();
            fakePerson.firstName = "Merve";
            fakePerson.lastName = "Eser";
            fakePerson.company = "Rise Techonology Unit Test";
            fakePerson.contactInfo = new contactInfo();

            var dataStore = A.Fake<personService>();
            var controller = new personController(dataStore);

            //Act
            var actionResult = controller.Post(fakePerson);

            //Assert
            var res = actionResult;
        }

        [Fact]
        public void HomeControllerUpdatePerson()
        {
            //Arrange
            string id = "621b708f97e18f5b2077ea69";
            person fakePerson = new person();
            fakePerson.firstName = "Merve Unit Test";
            fakePerson.lastName = "Eser";
            fakePerson.company = "Rise Techonology Unit Test";
            fakePerson.contactInfo = new contactInfo();

            var dataStore = A.Fake<personService>();
            var controller = new personController(dataStore);

            //Act
            var actionResult = controller.Update(id, fakePerson);

            //Assert
            var res = actionResult;
        }

        [Fact]
        public void HomeControllerDelete()
        {
            //Arrange
            string id = "621b68c2c151cd7ab36d14ee";
            
            var dataStore = A.Fake<personService>();
            var controller = new personController(dataStore);

            //Act
            var actionResult = controller.Delete(id);

            //Assert
            var res = (actionResult as StatusCodeResult).StatusCode;
            Assert.Equal(res, 200);
        }
    }
}
