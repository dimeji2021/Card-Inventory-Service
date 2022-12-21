using CardInventoryServiceInfrastructure;
using CardInventoryServiceInfrastructure.IRepository;
using CardInventoryServiceInfrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Configure service
builder.Services.AddScoped<IStockRepository,StockRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var AuthConnString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<InventoryDbContext>(options => {
    options.UseSqlServer(AuthConnString);
});


var app = builder.Build();
await InventoryDbInitializer.Seed(app);


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
