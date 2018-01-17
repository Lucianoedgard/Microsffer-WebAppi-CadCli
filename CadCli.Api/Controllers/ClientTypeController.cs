using CadCli.Infra.DataContext;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CadCli.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class ClientTypeController: ApiController
    {
        CadCliDataContext db = new CadCliDataContext();

        [Route("ClientTypes")]
        public HttpResponseMessage GetClientTypes()
        {
            try
            {
                var result = db.ClientType.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao obter os Tipos de clientes. Erro: " + e.Message);
            }
        }
    }
}