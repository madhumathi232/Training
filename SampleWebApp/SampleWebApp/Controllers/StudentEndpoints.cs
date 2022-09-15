using Microsoft.EntityFrameworkCore;
using SampleWebApp.Data;
using SampleWebApp.Models;
namespace SampleWebApp.Controllers;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (SampleWebAppContext db) =>
        {
            return await db.Student.ToListAsync();
        })
        .WithName("GetAllStudents");

        routes.MapGet("/api/Student/{id}", async (int RollNo, SampleWebAppContext db) =>
        {
            return await db.Student.FindAsync(RollNo)
                is Student model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetStudentById");

        routes.MapPut("/api/Student/{id}", async (int RollNo, Student student, SampleWebAppContext db) =>
        {
            var foundModel = await db.Student.FindAsync(RollNo);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateStudent");

        routes.MapPost("/api/Student/", async (Student student, SampleWebAppContext db) =>
        {
            db.Student.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/Students/{student.RollNo}", student);
        })
        .WithName("CreateStudent");

        routes.MapDelete("/api/Student/{id}", async (int RollNo, SampleWebAppContext db) =>
        {
            if (await db.Student.FindAsync(RollNo) is Student student)
            {
                db.Student.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudent");
    }
}
