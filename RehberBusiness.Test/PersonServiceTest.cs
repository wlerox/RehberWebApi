//using NPOI.SS.Formula.Functions;
using Moq;
using Rehber.API.Controllers;
using Rehber.Business.Abstract;
using Rehber.Entities.DtoModel;
using Xunit;

namespace RehberBusiness.Test
{
    public class PersonServiceTest
    {
        public Mock<IPersonService> mock = new Mock<IPersonService>();

        [Fact]
        public async void CreatePerson()
        {
            var person = new PersonSetDto()
            {
                Name = "engin",
                Surname = "yolco",
                Company = "uygun san."
            };
            var persondto = new PersonDto();
            mock.Setup(p => p.CreatePerson(person)).ReturnsAsync(persondto);
            var controller = new PersonController(mock.Object);
            var result = await controller.CreateNewPerson(person);
            Assert.True(person.Equals(persondto));

        }
    }
}
