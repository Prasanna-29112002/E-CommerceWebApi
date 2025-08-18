public interface IOrderRepository
{
    List<MyOrder> GetOrders();
    void Create(MyOrder myorder);
    void Update(int id, MyOrder myorder);
     void Delete(int id);
}