using CliSenhas2024.Models;
using Microsoft.AspNetCore.Http.HttpResults;    
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CliSenhas2024.Filtros_adm
{
    public class PaginaParaAdm : ActionFilterAttribute  //F12. Essa biblioteca tem o metodo OnActionExecuting, e toda vez que cai nesse metodo,
                                                        //antes de executar qualquer ação dos controladores, primeiro cai nesse metodo
    {
        public override void OnActionExecuting(ActionExecutingContext context) //override pois eu subscrevo o metodo que tem na biblioteca acima,
                                                                               // void pois n retorna nada
        {
            //verificacao pra ver se o utilizador esta logado ou nao 
             string sessaoUtilizador = context.HttpContext.Session.GetString("sessaoUtilizadorLogado");

            if (string.IsNullOrEmpty(sessaoUtilizador))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action","IndexLogin"} });
            }
            else 
            {
                Utilizador utilizador = JsonConvert.DeserializeObject <Utilizador>(sessaoUtilizador);
                if (utilizador == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "IndexLogin" } });
                }
                if (utilizador.Perfil != TipoDaConta.Tipo_conta.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "RestritoAdm" }, { "action", "IndexRestritoAdm" } });
                }

            }
                base.OnActionExecuting(context); // pra pegar todo o codigo base que tem dentro desse metodo
        }
    }
}
