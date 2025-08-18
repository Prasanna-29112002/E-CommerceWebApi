using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository paymentRepository;
    

    public PaymentController(IPaymentRepository paymentRepository)
    {
        this.paymentRepository = paymentRepository;
        
    }

    [Authorize]
    [HttpGet]
    public ActionResult<List<Payment>> GetAllPayments()
    {
        return Ok(paymentRepository.GetPayments());
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Payment> GetPaymentById(int id)
    {
        var payment = paymentRepository.GetById(id);
        if (payment == null) return NotFound();
        return Ok(payment);
    }

    [Authorize]
    [HttpPost("CreatePayment")]
    public IActionResult CreatePayment([FromBody]Payment payment)
    {
        paymentRepository.Create(payment);
        return Ok();
    }

    [Authorize]
    [HttpPatch("UpdatePaymentData/{id}")]
    public IActionResult UpdateData(int id, [FromQuery] string status)
    {
        paymentRepository.Update(id, status);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("DeletingPayment/{id}")]
    public IActionResult DeletePayment(int id)
    {
        paymentRepository.Delete(id);
        return Ok();
    }
}
