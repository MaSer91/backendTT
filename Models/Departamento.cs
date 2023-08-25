using System.ComponentModel.DataAnnotations;

namespace APIAdminUsers.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set;}
        public string Nombre { get; set;}
        public Boolean activo { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
