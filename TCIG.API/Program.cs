using TCIG.Application.Interfaces;
using TCIG.Application.Mappings;
using TCIG.Application.Services;
using TCIG.Application.Validators;
using TCIG.Infrastructure.Data;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Infrastructure services
builder.Services.AddInfrastructureDI(builder.Configuration);

// Add Application services
builder.Services.AddScoped<IProductService, ProductService>();

// AutoMapper
//builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ProductMappingProfile>();
});


// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
