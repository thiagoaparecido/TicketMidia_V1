using SCBIntegration;
using SCBIntegration.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketMidia.Models;

namespace TicketMidia.Controllers
{
    public class HomeController : Controller
    {
        private TicketMidiaEntities db = new TicketMidiaEntities();
        List<MensagensANCINE> model = new List<MensagensANCINE>();

        public ActionResult Index()
        {
            DateTime bil_dia_cin;

            var bil_exists = from bil in db.TB_BILHETERIA
                    where bil.BIL_ID != 0
                    select bil;

            if( bil_exists.Any() )
            {
                bil_dia_cin = db.TB_BILHETERIA.Max(max => max.BIL_DIA_CIN);
                ViewBag.bil_dia_cin = bil_dia_cin.ToShortDateString();

                var qtdNaoEnviado = db.TB_BILHETERIA.Count(bil_nao => bil_nao.BIL_STATUS_PROT == "");
                ViewBag.qtdNaoEnviado = qtdNaoEnviado;

                var qtdErro = db.TB_BILHETERIA.Count(bil_err => bil_err.BIL_STATUS_PROT == "E" || bil_err.BIL_STATUS_PROT == "N" || bil_err.BIL_STATUS_PROT == "R");
                ViewBag.qtdErro = qtdErro;

                var qtdEmAnalise = db.TB_BILHETERIA.Count(bil_err => bil_err.BIL_STATUS_PROT == "A");
                ViewBag.qtdEmAnalise = qtdEmAnalise;
            }
            else
            {
                ViewBag.bil_dia_cin = 0;
                ViewBag.qtdNaoEnviado = 0;
                ViewBag.qtdErro = 0;
                ViewBag.qtdEmAnalise = 0;
            }

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}