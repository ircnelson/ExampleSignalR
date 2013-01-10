using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExampleSignalR.Autenticacao;
using ExampleSignalR.Contexto.EF;
using ExampleSignalR.Models;

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
                var query = (from s in contexto.vwServicoLinear
                             where s.Descricao.Contains(term)

                             select new
                                        {
                                            Id = s.ID,
                                            CodigoInterno = s.CodigoInterno,
                                            Servico = s.Descricao
                                        })
                    .OrderBy(o => o.Servico)
                    .AsNoTracking()
                    .ToList();

                return Json(query, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AdicionarServico(long idServico)
        {
            using (var contexto = new GenesisEntities())
            {
                var servico = contexto.vwServicoClassificado.SingleOrDefault(e => e.ID == idServico);
                var codigoInterno = string.Format("{0}.", servico.Pai);
                
                var query = (from s in contexto.vwServicoClassificado
                             where s.IDTipo == 2 && s.CodigoInterno.StartsWith(codigoInterno)
                             select new
                                        {
                                            Id = s.ID,
                                            CodigoInterno = s.CodigoInterno,
                                            Servico = s.NomeServico
                                        }).ToList();

                return Json(query, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
