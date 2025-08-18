public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext appDbContext;

    public PaymentRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public List<Payment> GetPayments() => appDbContext.Payments.ToList();

    public Payment GetById(int id) => appDbContext.Payments.Find(id);

    public Payment Create(Payment payment)
    {
        appDbContext.Payments.Add(payment);
        appDbContext.SaveChanges();
        return payment;
    }

    public void Update(int id, string status)
    {
        var payment = appDbContext.Payments.Find(id);
        if (payment != null)
        {
            payment.status = status;
            appDbContext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var payment = appDbContext.Payments.Find(id);
        if (payment != null)
        {
            appDbContext.Payments.Remove(payment);
            appDbContext.SaveChanges();
        }
    }

    // Calculate total price from shopping cart for a user
    public decimal CalculateTotalPriceForUser(int userId)
    {
        var cartItems = appDbContext.ShoppingCarts
            .Where(c => c.UserId == userId)
            .ToList();

        // Assuming ShoppingCart item has Quantity and Price per item (PricePerUnit)
        return cartItems.Sum(item => item.Quantity * (decimal)item.TotalPrice);
    }
}
