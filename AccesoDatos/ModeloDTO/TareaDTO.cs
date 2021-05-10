using AccesoDatos.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.ModeloDTO
{
    public class TareaDTO
    {
        public TareaDTO()
        {

        }
        public int Id { get; set; }
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
        public int DuracionPlanificada { get; set; }

        public int ? UsuarioId { get; set; }

        public UsuarioDTO Usuario { get; set; }

        public TareaDTO(Tarea tarea)
        {

            this.Id = tarea.Id;
            if (tarea.Usuario != null)
            { 
                this.Usuario = new UsuarioDTO(tarea.Usuario);
            }
           
            this.DuracionPlanificada = tarea.DuracionPlanificada;
            this.Descripcion = tarea.Descripcion;
            this.Codigo = tarea.Codigo;
            this.UsuarioId = tarea.UsuarioId;
       
        }

        public Tarea ToEntity()
        {
            return new Tarea() { Id = this.Id, Descripcion = this.Descripcion, Codigo = this.Codigo, DuracionPlanificada = this.DuracionPlanificada ,UsuarioId = this.UsuarioId };
        }
    }
}
