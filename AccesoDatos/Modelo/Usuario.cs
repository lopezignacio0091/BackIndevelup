using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Modelo
{
   public  class Usuario
    {
        public  int Id { get; set; }
        public string Nombre { get; set; } 
       
        public virtual List<Tarea> Tareas { get; set;}
    }

   
}
