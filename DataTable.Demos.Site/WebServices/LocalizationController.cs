using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataTable.Demos.Site.WebServices
{
    public class LocalizationController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public dynamic Get()
        {
            return new
            {
                processing = "Processando",
                search = "Buscar ",
                lengthMenu = "Exibindo _MENU_ por página",
                info = "Exibindo de _START_ a _END_ de _TOTAL_ elementos",
                infoEmpty = "Sem registros encontrados",
                infoFiltered = "(filtro sobre _MAX_ registros no total)",
                infoPostFix = "",
                loadingRecords = "Carregando informações...",
                zeroRecords = "Nada encontrado",
                emptyTable = "Nada para exibir",
                paginate = new
                {
                    first = "Primeira",
                    previous = "Anterior",
                    next = "Pr&oacute;xima",
                    last = "Última"
                }
            };
        }
    }
}