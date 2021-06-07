using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2_Estudantes.Models
{
    interface IEstudanteRepositorio
    {
        IEnumerable<Estudante> GetAll();
        Estudante Get(int id);
        void Remove(int id);
        bool Uptade(Estudante estudante);
        bool Add(Estudante estudante);
    }

}
