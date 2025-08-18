using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MyOrder
{
    [Key]
    public int OrderId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public double TotalPrice { get; set; }
    public string ShippingAddress { get; set; }
    public string OrderStatus { get; set; }   
    public string PaymentStatus { get; set; } 
}