using AccesoDatos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccesoDatos.ModeloDTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public UsuarioDTO()
        {

        }

        public UsuarioDTO(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Nombre = usuario.Nombre;
        }

        public Usuario ToEntity()
        {
            return new Usuario() { Id=this.Id,Nombre=this.Nombre};
        }
    }
}
