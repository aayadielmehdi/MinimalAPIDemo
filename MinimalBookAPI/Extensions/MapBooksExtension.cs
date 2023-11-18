
namespace MinimalBookAPI.Extensions
{
    public static class MapBooksExtension
    {
        public static WebApplication MapBook(this WebApplication app)
        {
            BookRepository repository = new();

            app.MapGet("/book", () =>
            {
                return repository.GetList();
            });

            app.MapGet("/book/{id}", (int id) =>
            {
                Book b = repository.Get(id);
                if (b is null)
                    return Results.NotFound("Book non trouvé");
                return Results.Ok(b);
            });

            app.MapPost("/book", (Book b) =>
            {
                repository.Add(b);
                return b;
            });

            app.MapPut("/book/{id}", (int id, Book updatedBook) =>
            {
                Book b = repository.Get(id);
                if (b is null)
                    return Results.NotFound("Book non trouvé");
                repository.Update(id, updatedBook);
                return Results.Ok(b);
            });

            app.MapDelete("/book/{id}",(int id) =>
            {
                Book b = repository.Get(id);
                if (b is null)
                    return Results.NotFound("Book non trouvé");
                repository.Delete(id);
                return Results.Ok(b);
            });

            return app;
        }
    }
}
