using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using TODEB_INVOICES_PROJECT.Application.BackgroundJobs.Abstract;
using TODEB_INVOICES_PROJECT.Application.Services.Concrete;
using TODEB_INVOICES_PROJECT.Domain.Entities.Concrete;
using TODEB_INVOICES_PROJECT.Domain.Repositories.EntityTypeRepo;
using Xunit;

namespace TODEB_INVOICES_PROJECT.TestProject
{
    public class CustomerServiceTest
    {
        [Fact]
        public void CustomerServiceCreate_Success()
        {
            //arrange
            var customerRepositoryMock = new Mock<IUserRepository>();
            customerRepositoryMock.Setup(x => x.Add(It.IsAny<User>()));

            var jobsMock = new Mock<IJobs>();
            jobsMock.Setup(x => x.FireAndForget(It.IsAny<int>(), It.IsAny<string>()));
            jobsMock.Setup(x => x.DelayedJob(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<TimeSpan>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new Mapper());
            });

            IMapper mapper = new Mapper(mapperConfig);
           // mapper.ConfigurationProvider.AssertConfigurationIsValid();

            
            var customerService =
                new UserService(customerRepositoryMock.Object, mapper, jobsMock.Object);

            var customerRequest = new CreateCustomerRequest()
            {
                Email = "nihatcanertug@gmail.com",
                Phone = "05453457892",
                Name = "Nihatcan",
                Surname = "Ertuğ"
            };
            //act


            var response = customerService.Insert(customerRequest);

            response.Status.Should().BeTrue();

        }
    }
}
