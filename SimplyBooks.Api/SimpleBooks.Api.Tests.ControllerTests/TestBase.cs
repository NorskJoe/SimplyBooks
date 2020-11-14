using Moq;
using System;

namespace SimpleBooks.Api.Tests.ControllerTests
{
    public class TestBase<TController, TService> where TService: class
    {
        public TController ControllerUnderTest { get; set; }
        public Mock<TService> ServiceMock { get; set; }

        public TestBase()
        {
            ServiceMock = new Mock<TService>();
            ControllerUnderTest = (TController)Activator.CreateInstance(typeof(TController),
                new object[] { ServiceMock.Object });
        }
    }
}
