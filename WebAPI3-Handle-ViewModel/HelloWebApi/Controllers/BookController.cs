using System;
using System.Collections.Generic;
using System.Linq;
using HelloWebApi.BookOperations.CreateBook;
using HelloWebApi.BookOperations.GetBooks;
using HelloWebApi.BookOperations.GetBooksQueryDetail;
using HelloWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static HelloWebApi.BookOperations.CreateBook.CreateBooksCommand;

namespace HelloWebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }


        /*private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id = 1,
                Title = "Lean startup",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime (2001,06,12)
            },
            new Book{
                Id = 2,
                Title = "Hearland",
                GenreId = 2,
                PageCount = 230,
                PublishDate = new DateTime (2010,03,11)
            },
              new Book{
                Id = 3,
                Title = "Dune",
                GenreId = 3,
                PageCount = 530,
                PublishDate = new DateTime (2014,12,11)
            }
        };*/

        [HttpGet]
        public IActionResult GetBook()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        } 

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookQueryDetail query = new GetBookQueryDetail(_context);
                query.BookId = id;
                result = query.Handle();
               

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(result);
        }

        /*[HttpGet]
        public int BookCount()
        {
            int book = BookList.Count;
            return book;
        }
        */

        /*[HttpGet]
        public Book Get([FromQuery]string id)
        {
            var book = BookList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
        */

        //POST
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBooksCommand command = new CreateBooksCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }

        //PUT
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(id == null)
            {
                return BadRequest();
            }
            else
            {
                book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
                book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
                book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
                book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
                _context.SaveChanges();
                return Ok();
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
