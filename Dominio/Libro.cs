using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public string ImgTapa { get; set; }

        public Genero Genero { get; set; }

        public Usuario Usuario { get; set; }

        public string Sinopsis { get; set; }
        public bool Activo { get; set; }
    }
}
