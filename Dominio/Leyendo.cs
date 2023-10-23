using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Leyendo
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public Libro Libro { get; set; }

        public bool Devolvio { get; set; }

    }
}