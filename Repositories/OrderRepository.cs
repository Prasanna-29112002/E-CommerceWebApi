using log4net;

public class OrderRepository : IOrderRepository
{
    private AppDbContext appDbContext;
    private static readonly ILog log = LogHelper.Logger;
    public OrderRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public List<MyOrder> GetOrders()
    {
        log.Info("Getting all orders Data!..");
        return appDbContext.MyOrders.ToList();    
    }



    public void Create(MyOrder myorder)
    {
        log.Warn("Adding the New Order!..");
        appDbContext.MyOrders.Add(myorder);
        appDbContext.SaveChanges();
        log.Info("New Order is added.");
    }
    public void Update(int id, MyOrder myorder)
    {
        var orderToUpdate = appDbContext.MyOrders.Find(id);
        if (orderToUpdate == null)
        {
            log.Warn("Updating data of Order!..");
            orderToUpdate.ShippingAddress = myorder.ShippingAddress;
            appDbContext.SaveChanges();
            log.Info("Updated data successfully.");
        }
        else
        {
            log.Error("User Order not found");
        }
    }
    public void Delete(int id)
    {
        var order = appDbContext.MyOrders.Find(id);
        if (order != null)
        {
            log.Warn("Deleting Order data");
            appDbContext.Remove(order);
            appDbContext.SaveChanges();
              log.Info("Deleted Order data");
        }
        else
        {
            log.Error("Unsuccessfull Deletion of Order..!!!!");
        }
    }
}

