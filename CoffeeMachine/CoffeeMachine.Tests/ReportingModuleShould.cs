using System;
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
            var orderDetails = new OrderDetails(DrinkType.Coffee, 0.6m);
            reportingModule.AddOrder(orderDetails);
            
            Assert.Single(reportingModule.Orders);
            Assert.Equal(DateTime.Today, orderDetails.TimeStamp.Date);
        }

        [Fact]
        public void GenerateFullReportByGivenDate()
        {
            var expectedReport = "Date: 04-May-2020" + Environment.NewLine +
                                        "Coffee: 3" + Environment.NewLine + //180c
                                        "Hot Chocolate: 1" + Environment.NewLine + //50c
                                        "Tea: 2" + Environment.NewLine + //80c
                                        "Total Earned: $3.10";
            
            var reportingModule = new ReportingModule();
            reportingModule.AddOrder(new OrderDetails(DrinkType.Coffee, 0.6m));
            reportingModule.AddOrder(new OrderDetails(DrinkType.Coffee, 0.6m));
            reportingModule.AddOrder(new OrderDetails(DrinkType.Coffee, 0.6m));
            reportingModule.AddOrder(new OrderDetails(DrinkType.Tea, 0.4m));
            reportingModule.AddOrder(new OrderDetails(DrinkType.Tea, 0.4m));
            reportingModule.AddOrder(new OrderDetails(DrinkType.HotChocolate, 0.5m));
            
            Assert.Equal(expectedReport, reportingModule.GenerateReport(DateTime.Parse("2020-05-04")));
        }
    }
}