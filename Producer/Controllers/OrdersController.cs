using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Producer.Models;
using SharedModels;

namespace Producer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public OrdersController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDto orderDto)
    {
        await _publishEndpoint.Publish<IOrderCreated>(orderDto);

        return Ok();
    }
}