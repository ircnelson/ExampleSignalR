using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleSignalR.Autenticacao
{
    public class Autorizacao : AuthorizeAttribute
    {
        public new Permissao[] Roles
        {
            get
            {
                var roles = base.Roles.Split(',');
                return roles.ToList().ConvertAll(s => (Permissao)Enum.Parse(typeof(Permissao), s)).ToArray();
            }
            set
            {
                var roles = value.ToList().ConvertAll(r => ((int)r).ToString()).ToArray();
                base.Roles = string.Join(",", roles);
            }
        }
    }
}