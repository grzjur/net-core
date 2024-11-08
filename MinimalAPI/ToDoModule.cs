using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

internal static class ToDoModule
{
    internal static void AddToDoModule(this IEndpointRouteBuilder app)
    {
        app.MapGet("/todos", async (ToDoDb db) => await ToDosListGetTaskAsync(db))
            .WithTags("ToDo")
            .WithOpenApi();

        app.MapGet("/todos/{id}", async (int id, ToDoDb db) => await ToDosGetTaskAsync(id, db))
            .WithTags("ToDo")
            .WithOpenApi();

        app.MapPost("/todos", async (string description, ToDoDb db) => await ToDosPostTaskAsync(description, db))
            .WithTags("ToDo")
            .WithOpenApi();

        app.MapDelete("/todos/{id}", async (int id, ToDoDb db) => await ToDosDeleteTaskAsync(id, db))
            .WithTags("ToDo")
            .WithOpenApi();

        app.MapPut("/todos/{id}", async (int id, string description, ToDoDb db) => await ToDosPutTaskAsync(id,description,db))
            .WithTags("ToDo")
            .WithOpenApi();     

    }


    internal static async Task<IResult> ToDosGetTaskAsync(int id, ToDoDb db)
    {
         var todo = await db.ToDos.FindAsync(id);
         if (todo is null) return Results.NotFound();
        return Results.Ok(todo);
    }

    internal static async Task<IResult> ToDosPostTaskAsync(string description, ToDoDb db)
    {
        var todo = new ToDo { Description = description };
        db.ToDos.Add(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    internal static async Task<IResult> ToDosListGetTaskAsync(ToDoDb db)
    {
        var response = await db.ToDos.ToListAsync();
        return Results.Ok(response);
    }

    internal static async Task<IResult> ToDosDeleteTaskAsync(int id, ToDoDb db)
    {
        var toDo = await db.ToDos.FindAsync(id);
         if (toDo == null) return Results.NotFound();
        db.ToDos.Remove(toDo);
        await db.SaveChangesAsync();
        return Results.Ok();
    }

    internal static async Task<IResult> ToDosPutTaskAsync(int id, string description, ToDoDb db)
    {
        var toDo = await db.ToDos.FindAsync(id);
         if (toDo == null) return Results.NotFound();
        toDo.Description  = description;
        await db.SaveChangesAsync();
        return Results.Ok(toDo);
    }

}