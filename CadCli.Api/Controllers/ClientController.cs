using CadCli.Domain;
using CadCli.Infra.DataContext;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CadCli.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class ClientController : ApiController
    {
        CadCliDataContext db = new CadCliDataContext();

        [Route("Clients")]
        public HttpResponseMessage GetClients()
        {
            try
            {
                var result = db.Client.Include("ClientType").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao obter Clientes. Erro: " + e.Message);
            }
        }


        [HttpPost]
        [Route("Clients")]
        public HttpResponseMessage PostClients(Client client)
        {
            try
            {
                if (client == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                db.Client.Add(client);
                db.SaveChanges();

                var result = client;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao cadastrar Cliente. Erro: " + e.Message);
            }
        }

        [HttpPut]
        [Route("Clients")]
        public HttpResponseMessage PutClients(Client client)
        {
            try
            {
                if (client == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();

                var result = client;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao atualizar Cliente. Erro: " + e.Message);
            }
        }

        [HttpDelete]
        [Route("Clients/{id}")]
        public HttpResponseMessage DeleteClients(int id)
        {
            try
            {
                db.Client.Remove(db.Client.Find(id));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente Removido com Sucesso");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao remover Cliente. Erro: " + e.Message);
            }
        }

    }
}