using ApartmentPrices.API.Contracts;
using ApartmentPrices.Domain.Abstractions.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentPrices.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService subscribtionService;

        public SubscriptionController(ISubscriptionService subscribtionService)
            => this.subscribtionService = subscribtionService;

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSubscription(string email, string url)
            => Ok(await subscribtionService.CreateSubscribtion(email, url));

        [HttpGet]
        public async Task<ActionResult<SubscriptionResponse>> GetSubscriptionInfo(string email)
        {
            var subscription = await subscribtionService.GetSubscribtion(email);

            if (subscription is null) return BadRequest("Проверьте введённый адрес");

            return Ok(new SubscriptionResponse(subscription.Id, subscription.Email, subscription.CreatedAt, subscription.Apartments
                    .Select(a => new ApartmentResponse(a.Id, a.Url, a.Address, a.Prices
                        .Select(p => new PriceHistoryResponse(p.Id, p.Price, p.CheckedAt)).ToList())).ToList()));
        }
    }
}
