using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
  private readonly IOrderRepository _orderRepository;
  public OrderController(IOrderRepository orderRepository)
  {
    this._orderRepository = orderRepository;
  }
  [HttpGet]
  public List<MyOrder> GetOrders()
  {
    return _orderRepository.GetOrders();
  }
  [HttpPost("AddNewOrder")]
  public void Create(MyOrder myorder)
  {
    _orderRepository.Create(myorder);
  }
  [HttpPut("UpdateOrder")]
  public void Update(int id, MyOrder myorder)
  {
    _orderRepository.Update(id, myorder);
  }
  [HttpDelete("DeleteOrder")]
  public void Delete(int id)
  {
    _orderRepository.Delete(id);
  }
}