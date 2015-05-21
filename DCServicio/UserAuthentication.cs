using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using DCModelo;
using LinqKit;

namespace DCServicio
{
    public class UserAuthentication : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            try
            {
                string[] userNames = userName.Split('|');
                string[] passwords = password.Split('|');
                var predicate = PredicateBuilder.False<DCModelo.Cuenta>();

                for (int i = 0; i < userNames.Length; i++)
                {
                    string user = userNames[i];
                    string pass = passwords[i];
                    predicate = predicate.Or(c => c.CuentaID == user && c.Password == pass);
                }

                DCModelo.Entities contexto;
                using (contexto = new DCModelo.Entities())
                {
                    var cuentas = contexto.Cuentas.AsExpandable().Where(predicate);
                    if (cuentas.Count() != userNames.Length)
                    {
                        throw new FaultException("Los usuarios y/o password son incorrectos");
                    }
                }
            }
            catch
            {
                throw new FaultException("Error en el protocolo de autenticación");
            }
        }
    }
}