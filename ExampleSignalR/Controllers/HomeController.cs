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

        public JsonResult GraficoUnidadePessoa()
        {
            using (var db = new PEEntities())
            {
                var query = (from p in db.Pessoa
                             join u in db.UnidServ on p.CDUnidServ equals u.CDUnidServ
                             where p.DataCad.Year >= 2007
                             group p by new
                                            {
                                                Ano = p.DataCad.Year,
                                                Unidade = u.NMUnidServ
                                            }
                             into g
                             orderby new
                                         {
                                             g.Key.Ano,
                                             g.Key.Unidade
                                         }
                             select new
                                        {
                                            Ano = g.Key.Ano,
                                            Unidade = g.Key.Unidade,
                                            QuantidadePessoa = g.Count()
                                        }).AsNoTracking().ToList();

                var chart = new HighchartsRender<int, int>();

                foreach (var row in query)
                {
                    if (!chart.categories.Any(a => a == row.Ano))
                        chart.categories.Add(row.Ano);

                    if (!chart.series.Any(e => e.Key == row.Unidade))
                        chart.series.Add(row.Unidade, new List<int>());

                    var indice = chart.categories.IndexOf(row.Ano);
                    var serie = chart.series[row.Unidade];
                    try
                    {
                        serie.Insert(indice, row.QuantidadePessoa);
                    } catch(ArgumentOutOfRangeException)
                    {
                        serie.Insert(indice - 1, 0);
                        serie.Insert(indice, row.QuantidadePessoa);
                    }
                }

                return Json(chart);
            }
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
