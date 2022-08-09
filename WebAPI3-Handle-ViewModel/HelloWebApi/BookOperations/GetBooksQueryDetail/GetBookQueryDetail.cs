using System;
using System.Linq;
using HelloWebApi.Commen;
using HelloWebApi.DbOperations;

namespace HelloWebApi.BookOperations.GetBooksQueryDetail
{
    public class GetBookQueryDetail
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }

        public GetBookQueryDetail(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if(book == null)
            {
                throw new InvalidOperationException("kitap bulunamadı");
            }
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.ToString("dd/mm/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }
        
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
