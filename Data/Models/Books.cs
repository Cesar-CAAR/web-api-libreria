using System;
using System.Collections.Generic;

namespace Libreria_CAAR.Data.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Tutilo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genero { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }


        // Propiedades de navegación (en esta parte es donde "mapeamos")
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> Book_Author { get; set; }
    }
}
