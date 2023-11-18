namespace MinimalBookAPI.Repository
{
    public class BookRepository : IRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>
            {
                new Book(){Id=1,Title="title1",Author="Author1"},
                new Book(){Id=2,Title="title2",Author="Author2"},
                new Book(){Id=3,Title="title3",Author="Author3"},
                new Book(){Id=4,Title="title4",Author="Author4"}
            };
        }
        public List<Book> GetList()
        {
            return this.books;
        }
        public Book Get(int id)
        {
            return this.books.Find(x => x.Id == id);
            //return books[id]; retourn un element du tableau 
        }
        public void Add(Book book)
        {
            this.books.Add(book);
        }
        public void Update(int id, Book book)
        {
            Book b = this.Get(id);
            if (b is not null)
            {
                b.Title = book.Title;
                b.Author = book.Author;
            }
        }
        public void Delete(int id)
        {
            this.books.Remove(this.Get(id));
        }
    }
}
