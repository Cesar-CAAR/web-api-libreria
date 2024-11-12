using Libreria_CAAR.Data.Models;
using Libreria_CAAR.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Libreria_CAAR.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }



        // Método que nos permite agregar un nuevo libro en la BD
        public void AddBookWithAuthors(BookVM book)
         {
            var _book = new Books()
            {
                Tutilo = book.Tutilo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID
            };
            _context.Books.Add(_book);
            _context.SaveChanges();


            foreach (var id in book.AuthorIDs)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }


        // Método que nos permite obtener una lista de todos los libros de la BD
        public List<Books> GetAllBks() => _context.Books.ToList();


        // Método que nos permite obtener el libro que estamos pidiendo de la BD
        public BookWithAuthorsVM GetBookById(int bookid)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookid).Select(book => new BookWithAuthorsVM()
            {
                Tutilo = book.Tutilo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Author.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }


        // Método que nos permite modificar un libro que se encuentra en la BD
        public Books UpdateBookById(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookid);
            if (_book != null)
            {
                _book.Tutilo = book.Tutilo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }


        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookid);
            if (_book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }
    }
}