using PocContractValidation.Consumer.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocContractValidation.Consumer.Server.Services
{
    public class OrderService
    {
        public void DoSomethingWithOrderLocked(OrderLockedEvent orderLocked)
        {
            if (string.IsNullOrEmpty(orderLocked.orderNumber))
            {
                throw new Exception("OrderNumber is required.");
            }

            if (orderLocked.payment == null)
            {
                throw new Exception("Payment is required.");
            }

        }
    }
}
