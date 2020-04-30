using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReportingModuleShould
    {
        [Fact]
        public void CaptureOrderDetails()
        {
            var reportingModule = new ReportingModule();
            var orderDetails = Mock.Of<OrderDetails>(); 
            reportingModule.AddOrder(orderDetails);
            
            Assert.Single(reportingModule.Orders);
        }
    }
}