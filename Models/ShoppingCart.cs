using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShoppingCart
{
    [Key]
    public int CartItemId { get; set; }


    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }  
    
    
}