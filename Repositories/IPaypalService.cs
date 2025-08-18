public interface IPayPalService
{
    Task<string> CreateTransactionAsync(decimal amount);
}