using System.Collections.Generic;

public interface IPaymentRepository
{
    List<Payment> GetPayments();

    Payment GetById(int id);

    Payment Create(Payment payment);

    void Update(int id, string status);

    void Delete(int id);

    decimal CalculateTotalPriceForUser(int userId);
}
