using System;
using Libreria_CAAR.Data.Models;
using Libreria_CAAR.Data.ViewModels;

namespace Libreria_CAAR.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        
        // Método que nos permite agregar una nueva Editora en la BD
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
