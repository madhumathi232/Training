using Microsoft.EntityFrameworkCore;
using SampleTrainingApp.Data;
using SampleTrainingApp.Models;
namespace SampleTrainingApp.Controllers;

public static class InventoryEndpoints
{
    public static void MapInventoryEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Inventory", async (SampleTrainingAppContext db) =>
        {
            return await db.Inventory.ToListAsync();
        })
        .WithName("GetAllInventorys");

        routes.MapGet("/api/Inventory/{id}", async (int ProdId, SampleTrainingAppContext db) =>
        {
            return await db.Inventory.FindAsync(ProdId)
                is Inventory model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetInventoryById");

        routes.MapPut("/api/Inventory/{id}", async (int ProdId, Inventory inventory, SampleTrainingAppContext db) =>
        {
            var foundModel = await db.Inventory.FindAsync(ProdId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateInventory");

        routes.MapPost("/api/Inventory/", async (Inventory inventory, SampleTrainingAppContext db) =>
        {
            db.Inventory.Add(inventory);
            await db.SaveChangesAsync();
            return Results.Created($"/Inventorys/{inventory.ProdId}", inventory);
        })
        .WithName("CreateInventory");

        routes.MapDelete("/api/Inventory/{id}", async (int ProdId, SampleTrainingAppContext db) =>
        {
            if (await db.Inventory.FindAsync(ProdId) is Inventory inventory)
            {
                db.Inventory.Remove(inventory);
                await db.SaveChangesAsync();
                return Results.Ok(inventory);
            }

            return Results.NotFound();
        })
        .WithName("DeleteInventory");
    }
}
