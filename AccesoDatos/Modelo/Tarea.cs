using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Modelo
{
    public class Tarea
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int DuracionPlanificada { get; set; } 
        public int ? UsuarioId { get; set;} 
        public virtual Usuario Usuario { get; set; }

    }
}
