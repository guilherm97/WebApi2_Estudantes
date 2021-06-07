using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Estudantes.Models
{
    public class Estudante
    {
        public string nome { get; set; }
        public int id { get; set; }
        public string genero { get; set; }
        public int idade { get; set; }
    }
}