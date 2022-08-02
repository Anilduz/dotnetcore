using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace HelloWebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
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
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        } 

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(x => x.Id == id).SingleOrDefault();
            return book;
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
        public IActionResult AddBook([FromBody] Book newBook )
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if(book != null)
            {
                return BadRequest();
            }
            else
            {
                BookList.Add(newBook);
                return Ok();
            }

        }

        //PUT
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
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
                return Ok();
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                BookList.Remove(book);
                return Ok();
            }
        }
    }
}
