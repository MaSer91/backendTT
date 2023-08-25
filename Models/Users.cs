using System.ComponentModel.DataAnnotations;

namespace APIAdminUsers.Models
{
    public class Users
    {
        [Key]
        public string Usuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string IdDepartamento { get; set; }
        public string IdCargo { get; set; }

    }
}
