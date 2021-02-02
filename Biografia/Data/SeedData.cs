using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biografia.Data
{
    public class SeedData
    {
        private const string NOME_ADMIN = "feijoca96@hotmail.com";
        private const string PASSWORD_ADMIN = "Maneljaquim2021";

        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(NOME_ADMIN);
            if (utilizador == null)
            {
                utilizador = new IdentityUser(NOME_ADMIN);
                await gestorUtilizadores.CreateAsync(utilizador, PASSWORD_ADMIN);
            }
            
        }
    }
}
