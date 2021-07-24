using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.ViewModel
{
    public class RegistroViewModel
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
        public string DescripcionGenero { get; set; }
    }
}
