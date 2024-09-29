using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecetasMicroservice.Domain.Entities
{
    public class Medicamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Receta")]
        public int IdReceta { get; set; }

        public string Nombre { get; set; }
        public string Dosis { get; set; }
        public string Frecuencia { get; set; }

        // Propiedad de navegación
        public virtual Receta Receta { get; set; }
    }
}