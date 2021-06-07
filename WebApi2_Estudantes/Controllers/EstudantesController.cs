using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi2_Estudantes.Models;

namespace WebApi2_Estudantes.Controllers
{
    public class EstudantesController : ApiController
    {
        static readonly IEstudanteRepositorio estudanteRepositorio = new EstudanteRepositorio();
        /// <summary>
        /// retorna todos os estudantes;
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAllEstudantes() 
        {
            List<Estudante> listaEstudantes = estudanteRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Estudante>>(HttpStatusCode.OK, listaEstudantes);
        }


        public HttpResponseMessage GetEstudante(int id) //retorna um estudante;
        {
            Estudante estudante = estudanteRepositorio.Get(id);
            if(estudante == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Estudante não Localizado");
            }
            else
            {
                return Request.CreateResponse<Estudante>(HttpStatusCode.OK, estudante);
            }
        }

        public IEnumerable<Estudante> GetEstudantesPorGenero(string genero) //retorna os estudantes por genero;
        {
            return estudanteRepositorio.GetAll().Where(e => string.Equals(e.genero, genero, StringComparison.OrdinalIgnoreCase));
        }

        [System.Web.Http.Route("Estudante/ConsultaPorIdade")] //rota local para determinado metodo;
        public IEnumerable<Estudante>GetEstudantesPorIdade(int idade)//retorna os estudantes por idade;
        {
            return estudanteRepositorio.GetAll().Where(e => string.Equals(e.idade.ToString(), idade.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostEstudante(Estudante estudante) //inclui um novo estudante;
        {
            bool result = estudanteRepositorio.Add(estudante);
            if (result)
            {
                var response = Request.CreateResponse<Estudante>(HttpStatusCode.Created, estudante);
                string uri = Url.Link("DefaultApi", new { id = estudante.id }); 
                response.Headers.Location = new Uri(uri);
                return response;

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro Estudante não foi incluido ");
            }
        }
        public HttpResponseMessage PutEstudante(int id, Estudante estudante)//altera um estudante;
        {
            estudante.id = id;
            if (!estudanteRepositorio.Uptade(estudante))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não foi possivel atualizar para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
          

        public HttpResponseMessage DeleEstudante(int id)//exclui um estudante;
        {
            estudanteRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        } 


   
    }
}