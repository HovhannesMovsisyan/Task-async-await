using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson7
{
    public class PurchasedOrderProdecer
    {
        private readonly Queue<PurchasedOrder> ordersQueue;

        public PurchasedOrderProdecer()
        {
            this.ordersQueue = new Queue<PurchasedOrder>();
        }

        public async Task Produce()
        {
            await Task.Run(() =>
            {
                var newOrder = this.GenerateOrder();
                Console.WriteLine($"Item name is {newOrder.ItemName}");
                this.ordersQueue.Enqueue(newOrder);
                Thread.Sleep(2000);
            });

        }

        private PurchasedOrder GenerateOrder()
        {
            Random rnd = new Random();
            var itemNum = rnd.Next(1, 1000);
            return new PurchasedOrder { ItemId = itemNum, ItemName = $"ItemName{itemNum}", DeliveryAddress = $"Address{itemNum}" };
        }

        public IEnumerable<PurchasedOrder> GetOrders()=> this.ordersQueue;
       
    }
}
