//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp3
{
    using System;
    using System.Collections.Generic;
    
    public partial class cuentascliente
    {
        public int misc_id { get; set; }
        public Nullable<int> misc_idcliente { get; set; }
        public Nullable<int> misc_idbanco { get; set; }
        public Nullable<int> misc_idtipocuenta { get; set; }
    
        public virtual bancos bancos { get; set; }
        public virtual cliente cliente { get; set; }
        public virtual tipocuenta tipocuenta { get; set; }
    }
}