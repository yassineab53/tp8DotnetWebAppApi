using System.ComponentModel.DataAnnotations;

namespace AppWeb1.Models
{
    public class ProduitModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string libelle { get; set; }
        [Required]
        public float prix { get; set; }
    }
}
