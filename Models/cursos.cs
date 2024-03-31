using System.ComponentModel.DataAnnotations;

namespace MVC_p08_EsmeraldaGarcia.Models
{
    public class cursos
    {
        [Key]
        public int id_cursos { get; set; }
        public string nombre { get; set; }

    }
}
