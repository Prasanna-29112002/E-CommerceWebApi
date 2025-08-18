using System.ComponentModel.DataAnnotations.Schema;

public enum PaymentType { UPI, CreditCard, DebitCard, NetBanking}

public class Payment
{
    public int paymentId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("ShoppingCart")]
    public int CartItemId { get; set; }

    public int Amount { get; set; }

    public string status { get; set; }

    public PaymentType paymentType { get; set; }

    public string TransactionId { get; set; }

    public DateTime TransactionDate { get; set; }
}