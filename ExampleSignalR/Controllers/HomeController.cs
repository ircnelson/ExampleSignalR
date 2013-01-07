using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExampleSignalR.Autenticacao;
using ExampleSignalR.Contexto.EF;

namespace ExampleSignalR.Controllers
{
    public class HomeController : Controller
    {
        [Autorizacao(Roles = new[] { Permissao.Administrador })]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autocomplete()
        {
            return View();
        }

        public JsonResult PesquisaServicos(string term)
        {
            using (var contexto = new GenesisEntities())
            {
                var servicos = (from s in contexto.vwServicoClassificado

                                //join s2 in contexto.vwServicoClassificado on s.Pai equals s2.CodigoInterno into joins2
                                //from spai in joins2.DefaultIfEmpty()

                                //join s3 in contexto.vwServicoClassificado on spai.Pai equals s3.CodigoInterno into
                                //    joins3
                                //from svo in joins3.DefaultIfEmpty()

                                where s.NomeServico.Contains(term)

                                select new
                                           {
                                               Tipo = s.IDTipo,
                                               CodigoInterno = s.CodigoInterno,
                                               Servico = s.NomeServico
                                           })
                                .OrderBy(o => o.CodigoInterno)
                                .AsNoTracking()
                                .ToList();

                return Json(servicos, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AdicionarServico()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
