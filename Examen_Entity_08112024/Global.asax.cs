using Examen_Entity_08112024.Context;
using Examen_Entity_08112024.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Examen_Entity_08112024
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Deshabilitar inizializador que intente verificar la compatibilidad del modelo de base de datos
            Database.SetInitializer<dbContext>(null); // Se deshabilita el inicializador de la base de datos para evitar que se intente verificar la compatibilidad del modelo de base de datos
        }

    }
}