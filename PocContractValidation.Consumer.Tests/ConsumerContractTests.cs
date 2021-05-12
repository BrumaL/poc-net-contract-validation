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
            // This is the path to the file from the cloned repository
            var mockedOrderLockedJsonString = File.ReadAllText( $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}contract-validator-contracts{Path.DirectorySeparatorChar}myorder2{Path.DirectorySeparatorChar}order_locked{Path.DirectorySeparatorChar}order_locked.mock.json");
            var mockedOrderLockedEvent = JsonSerializer.Deserialize<OrderLockedEvent>(mockedOrderLockedJsonString);

            var orderSerivce = new OrderService();

            // Test implementation of the function that reads and processses the message from the queue. In our test we do this by fetching mocked data from our contracts-repo.
            // If our test pass with the mocked data, we can be certain our implementation is working.
            var exception = Record.Exception(() => orderSerivce.DoSomethingWithOrderLocked(mockedOrderLockedEvent));

            Assert.Null(exception);
        }
    }
}
