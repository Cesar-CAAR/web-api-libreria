using Libreria_CAAR.Data.Models;
using Libreria_CAAR.Data.ViewModels;
using Microsoft.OpenApi.Validations;
using System;
using System.ComponentModel;
using System.Linq;

namespace Libreria_CAAR.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }



        // Método que nos permite agregar un nuevo Autor en la BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }


        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Author.Select(n => n.Book.Tutilo).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
