using Microsoft.EntityFrameworkCore;
using TestingApp.Data;
using TestingApp.Models;
namespace TestingApp.Controllers;

public static class MyDetailsEndpoints
{
    public static void MapMyDetailsEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/MyDetails", async (TestingAppContext db) =>
        {
            return await db.MyDetails.ToListAsync();
        })
        .WithName("GetAllMyDetailss");

        routes.MapGet("/api/MyDetails/{id}", async (int EmpId, TestingAppContext db) =>
        {
            return await db.MyDetails.FindAsync(EmpId)
                is MyDetails model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetMyDetailsById");

        routes.MapPut("/api/MyDetails/{id}", async (int EmpId, MyDetails myDetails, TestingAppContext db) =>
        {
            var foundModel = await db.MyDetails.FindAsync(EmpId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateMyDetails");

        routes.MapPost("/api/MyDetails/", async (MyDetails myDetails, TestingAppContext db) =>
        {
            db.MyDetails.Add(myDetails);
            await db.SaveChangesAsync();
            return Results.Created($"/MyDetailss/{myDetails.EmpId}", myDetails);
        })
        .WithName("CreateMyDetails");
       
        routes.MapDelete(  "/api/MyDetails/{id}", async (int EmpId, TestingAppContext db) =>
        {
            if (await db.MyDetails.FindAsync(EmpId) is MyDetails myDetails)
            {
                db.MyDetails.Remove(myDetails);
                await db.SaveChangesAsync();
                return Results.Ok(myDetails);
            }

            return Results.NotFound();
        })
        .WithName("DeleteMyDetails");
    }
}
