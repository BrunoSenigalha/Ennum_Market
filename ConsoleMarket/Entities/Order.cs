using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMarket.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
            OrderItems = new List<OrderItem>();
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in OrderItems)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Convert.ToString(Status));
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in OrderItems)
            {
                sb.Append(item.product.Name);
                sb.Append(", $");
                sb.Append(item.product.Price.ToString("F2"));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity + ", ");
                sb.AppendLine("Subtotal: $" + item.SubTotal().ToString("F2"));
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2"));


            return sb.ToString();
        }
    }
}
