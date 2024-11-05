using System;
using System.Collections.Generic;

namespace Libreria_CAAR.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // Propiedades de navegación
        public List<Books> Books { get; set; }
    }
}
