﻿using System;

namespace Libreria_CAAR.Data.ViewModels
{
    public class BookVM
    {
        public string Tutilo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string CoverUrl { get; set; }
    }
}