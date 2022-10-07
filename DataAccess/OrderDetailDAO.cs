using BusinessObjects.Data;
using BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO? instance = null;
        private static readonly object iLock = new object();
        public OrderDetailDAO()
        {
        }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public void Add(OrderDetail orderDetail)
        {
            try
            {
                var db = new AppDbContext();
                db.OrderDetails!.Add(orderDetail);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var db = new AppDbContext();
                orderDetails = db.OrderDetails!.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetails;
        }

        public OrderDetail GetById(Guid? orderId)
        {
            OrderDetail? orderDetail = null;
            try
            {
                var db = new AppDbContext();
                orderDetail = db.OrderDetails!.Include(c => c.Product).SingleOrDefault(c => c.OrderId == orderId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetail!;
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetById(orderDetail.OrderId);
                if (_orderDetail != null)
                {
                    var db = new AppDbContext();
                    //db.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
                    db.OrderDetails!.Update(orderDetail);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find Order detail");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                OrderDetail _orderDetail = GetById(id);
                if (_orderDetail != null)
                {
                    var db = new AppDbContext();
                    db.OrderDetails!.Remove(_orderDetail);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Order detail does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}