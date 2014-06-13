using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Models;

namespace Spedycja.Model.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        int CreateNewOrder(Order order);

        List<Order> getAllOrders();

        Order getOrder(int id);

        bool deleteOrder(int id);

        void updateOrder(EditOrderModel model);
    }
}
