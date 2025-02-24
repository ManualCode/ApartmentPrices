using ApartmentPrices.Application.Services;
using ApartmentPrices.Application.Shedulers;
using ApartmentPrices.DataAcces;
using ApartmentPrices.DataAcces.Repositories;
using ApartmentPrices.Domain.Abstractions.Repositories;
using ApartmentPrices.Domain.Abstractions.Services;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApartmentPricesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ApartmentPricesDbContext))));

builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IWebParsingService, WebParsingService>();
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
builder.Services.AddScoped<IPriceRepository, PriceRepository>();
builder.Services.AddScoped<ISubscribtionRepository, SubscriptionRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("PiceScheduler");
    q.AddJob<PiceScheduler>(opts => opts.WithIdentity(jobKey));
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("PiceScheduler-trigger")
        .WithSimpleSchedule(x => x
                .WithIntervalInMinutes(1)
                .RepeatForever())
    );
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
