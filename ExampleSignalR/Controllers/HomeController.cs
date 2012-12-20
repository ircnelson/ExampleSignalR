using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExampleSignalR.Autenticacao;
using ExampleSignalR.Contexto.EF;
using ExampleSignalR.Highcharts;

namespace ExampleSignalR.Controllers
{
    public class HomeController : Controller
    {
        //[Autorizacao(Roles = new[] { Permissao.Administrador })]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GraficoProposta()
        {
            using (var contexto = new GenesisEntities())
            {
                var propostas = (from p in contexto.tbPropostaComercial
                                 where p.IDSituacao == 1
                                 group p by new { Mes = p.DataHoraInclusao.Value.Month, Tipo = "Elaboração" }
                                     into g
                                     select new { g.Key.Tipo, Mes = g.Key.Mes, Qtd = g.Count() }).Union(

                                     from p in contexto.tbPropostaComercial
                                     where p.IDSituacao == 2
                                     group p by new { Mes = p.DataHoraConclusao.Value.Month, Tipo = "Concluída" }
                                         into g
                                         select new { g.Key.Tipo, Mes = g.Key.Mes, Qtd = g.Count() }).Union(

                                         from p in contexto.tbPropostaComercial
                                         where p.IDSituacao == 3
                                         group p by new { Mes = p.DataHoraAprovacao.Value.Month, Tipo = "Aprovada" }
                                             into g
                                             select new { g.Key.Tipo, Mes = g.Key.Mes, Qtd = g.Count() }).Union(

                                             from p in contexto.tbPropostaComercial
                                             where p.IDSituacao == 4
                                             group p by
                                                 new { Mes = p.DataHoraCancelamento.Value.Month, Tipo = "Cancelada" }
                                                 into g
                                                 select new { g.Key.Tipo, Mes = g.Key.Mes, Qtd = g.Count() }).Union(

                                                 from p in contexto.tbPropostaComercial
                                                 where p.IDSituacao == 5
                                                 group p by
                                                     new { Mes = p.DataHoraRejeicao.Value.Month, Tipo = "Rejeitada" }
                                                     into g
                                                     select new { g.Key.Tipo, Mes = g.Key.Mes, Qtd = g.Count() }).Union(

                                                     from p in contexto.tbPropostaComercial
                                                     where p.IDSituacao == 6
                                                     group p by
                                                         new
                                                         {
                                                             Mes = p.DataValidadeProposta.Value.Month,
                                                             Tipo = "Vencida"
                                                         }
                                                         into g
                                                         select new { g.Key.Tipo, Mes = g.Key.Mes, Qtd = g.Count() });

                var highchart = new List<HighchartsBasic<decimal>>();

                foreach (var proposta in propostas.AsNoTracking().ToList())
                {
                    var serie = highchart.FirstOrDefault(e => e.name == proposta.Tipo);
                    if (serie == null)
                    {
                        serie = new HighchartsBasic<decimal> { name = proposta.Tipo, data = new List<decimal>(12) };

                        for (var i = 0; i < 12; i++)
                            serie.data.Insert(i, 0);

                        highchart.Add(serie);
                    }

                    serie.data[proposta.Mes - 1] = proposta.Qtd;
                }

                return Json(highchart);
            }
        }
    }
}
