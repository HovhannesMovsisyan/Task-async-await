using Lesson7.Extend;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson7
{
    internal class ConsoleHost
    {
        internal async Task Run()
        {
            while (true)
            {
                var orderProducer1 = new PurchasedOrderProdecer();
                var orderProcessor1 = new PurchasedOrderProcessor(orderProducer1.GetOrders().As<Queue<PurchasedOrder>>());

                var orderProducer2 = new PurchasedOrderProdecer();
                var orderProcessor2 = new PurchasedOrderProcessor(orderProducer2.GetOrders().As<Queue<PurchasedOrder>>());
                await orderProducer1.Produce();
                await orderProcessor1.ProcessItem();
                await orderProducer2.Produce();
                await orderProcessor2.ProcessItem();
            }
        }
    }
}