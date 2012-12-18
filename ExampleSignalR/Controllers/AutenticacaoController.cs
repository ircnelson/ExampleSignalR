using System.Web.Mvc;
using System.Web.Security;
using ExampleSignalR.Models;

namespace ExampleSignalR.Controllers
{
    public class AutenticacaoController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Membership.ValidateUser(viewModel.Usuario, viewModel.Senha);
                FormsAuthentication.SetAuthCookie(viewModel.Usuario, false);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }
    }
}