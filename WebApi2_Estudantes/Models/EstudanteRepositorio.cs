using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Estudantes.Models
{
    public class EstudanteRepositorio : IEstudanteRepositorio // herdando os parametros da Interface Repositorio
    {
        private List<Estudante> estudantes = new List<Estudante>(); //crinado uma lista estudante de acesso privado
        private int _nextld = 1;

        public EstudanteRepositorio()
        {
            Add(new Estudante { nome = "Guilherme", id = 1, genero = "Masculino", idade = 23 });
            Add(new Estudante { nome = "Gabriela", id = 2, genero = "Feminino", idade = 20 });
            Add(new Estudante { nome = "Leonardo", id = 3, genero = "Masculino", idade = 33 });
            Add(new Estudante { nome = "Felipe", id = 4, genero = "Masculino", idade = 19 });
            Add(new Estudante { nome = "Sandra", id = 5, genero = "Feminino", idade = 25 });
        }
        // Ienumerable: fazer uma busca geral
        public IEnumerable<Estudante> GetAll()
        {
            return estudantes;
        }

        public Estudante Get(int id)
        {
            return estudantes.Find(s => s.id == id); //Find : busca / fazendo uma busca do parametro especifico do tipo que foi solicitado.
        }
         // metodo de inclusão de estudante 
         /// <summary>
         /// add recebe o tipo Estudante e valida num laço if.
         /// se true ele adiciona em novo estudante em na variavel estudante;
         /// se null ela irá retorna false;
         /// </summary>
         /// <param name="estudante"></param>
         /// <returns></returns>
        public bool Add(Estudante estudante)
        {
            bool addResult = false;
            if(estudante == null)
            {
                return addResult;
            }

            int index = estudantes.FindIndex(s => s.id == estudante.id);
            if (index == -1)
            {
                estudantes.Add(estudante);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }
        
        // remove um id do tipo estudante ;
        public void Remove(int id)
        {
            estudantes.RemoveAll(s => s.id == id);
        }

        //atualizaçao : faz uma validação do tipo estudante na variavel estudante
        //se for null ele trata com uma exceção
        //varivael index : busca determinado id e se nao encontrado ele retornara -1;
        //caso contrario ele adiciona o valor na variavel estudante , removendo o valor contido no determinado index e sobrescrevendo;
        public bool Uptade(Estudante estudante)
        {
            if (estudante == null)
            {
                throw new ArgumentNullException("estudante");
            }
            int index = estudantes.FindIndex(s => s.id == estudante.id);
            if (index == -1)
            {
                return false;
            }

            estudantes.RemoveAt(index);
            estudantes.Add(estudante);
            return true;
        }
    } 
}