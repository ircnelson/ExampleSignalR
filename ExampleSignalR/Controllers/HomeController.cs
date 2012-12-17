using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExampleSignalR.Autenticacao;

namespace ExampleSignalR.Controllers
{
    public class HomeController : Controller
    {
        [Autorizacao(Roles = new[] { Permissao.Administrador })]
        public ActionResult Index()
        {
            return View();
        }
    }
}
