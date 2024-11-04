using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Libreria_CAAR.Data.Models;
using System.Linq;
using System.Threading;
using System;

namespace Libreria_CAAR.Data
{
    public class AppDbInitializer
    {
        // Metodo, para agregar datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Books()
                    {
                        Tutilo = "1st Book Title",
                        Descripcion = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Biography",
                        Autor = "1st Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    },

                    new Books()
                    {
                        Tutilo = "2nd Book Title",
                        Descripcion = "2nd Book Description",
                        IsRead = true,
                        Genero = "Biography",
                        Autor = "2nd Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}