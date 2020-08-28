using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson7
{
    public class PurchasedOrderProcessor
    {
        private readonly Queue<PurchasedOrder> ordersQueue;

        public PurchasedOrderProcessor(Queue<PurchasedOrder> ordersQueu)
        {
            this.ordersQueue = ordersQueu;
        }

        public async Task ProcessItem()
        {
            var order = default(PurchasedOrder);

            if (this.ordersQueue.Count > 0)
                order = this.ordersQueue.Dequeue();

            if (order != default)
            {
                Console.WriteLine($"CurrentThreadId {Thread.CurrentThread.ManagedThreadId} Processing item {order.ItemName}");
                await this.FindItem(order);
                await this.PackItem(order);
                await this.ShipItem(order);
            }
        }

        private async Task FindItem(PurchasedOrder order)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(200);
                Console.WriteLine($"Item found {order.ItemName}");
            });
        }

        private async Task PackItem(PurchasedOrder order)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"Item packed {order.ItemName}");
            });
        }

        private async Task ShipItem(PurchasedOrder order)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(200);
                Console.WriteLine($"Item shiped {order.ItemName}");
            });
        }

    }
}
