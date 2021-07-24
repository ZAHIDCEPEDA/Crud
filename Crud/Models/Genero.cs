﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class Genero
    {
       public Genero()
       {
         Registros = new HashSet<Registro>();
       }

       public int Codigo { get; set; }
       public string Descripicion { get; set; }
       public int Estado { get; set; }

       public virtual ICollection<Registro> Registros { get; set; }
    }
}
