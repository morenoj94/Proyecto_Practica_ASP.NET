using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokedex_Web
{
    public static class Consulta
    {
        public static bool IsLoging(Usuario user)
        {
            if (user != null)
                return true;
            else
                return false;
        }
    }
}