//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionInventario.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallePrivilegioRol
    {
        public int idDetalleP { get; set; }
        public int idRol { get; set; }
        public int idPrivilegio { get; set; }
    
        public virtual Privilegio Privilegio { get; set; }
        public virtual Rol Rol { get; set; }
    }
}