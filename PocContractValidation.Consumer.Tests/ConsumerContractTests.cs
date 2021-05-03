using PocContractValidation.Consumer.Server.Models;
using PocContractValidation.Consumer.Server.Services;
using System.IO;
using System.Text.Json;
using Xunit;

namespace PocContractValidation.Consumer.Tests
{
    public class ConsumerContractTests
    {
        [Fact]
        public void OrderLocked_1()
        {
            var mockedOrderLockedJsonString = File.ReadAllText( $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}contract-validation/myorder/order_locked_1.mock.json");
            var mockedOrderLockedEvent = JsonSerializer.Deserialize<OrderLockedEvent>(mockedOrderLockedJsonString);

            var orderSerivce = new OrderService();

            // Test implementation of the function that reads and processses the message from the queue.
            var exception = Record.Exception(() => orderSerivce.DoSomethingWithOrderLocked(mockedOrderLockedEvent));

            Assert.Null(exception);
        }
    }
}
