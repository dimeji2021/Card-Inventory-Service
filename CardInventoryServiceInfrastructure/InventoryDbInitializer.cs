using CardInventoryServiceDomain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceInfrastructure
{
    public class InventoryDbInitializer
    {
        public static async Task Seed(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<InventoryDbContext>();
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"CardInventoryServiceInfrastructure\Data\");
            if (await context.Database.EnsureCreatedAsync()) return;
            if (!context.Stocks.Any())
            {
                var readText = await File.ReadAllTextAsync(filePath + "Stocks.json");
                var stock = JsonConvert.DeserializeObject<List<Stock>>(readText);
                await context.AddRangeAsync(stock);
            }
            await context.SaveChangesAsync();
        }
    }
}
