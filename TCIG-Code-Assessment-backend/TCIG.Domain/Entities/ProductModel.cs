using System.ComponentModel.DataAnnotations;
using static TCIG_Code_Assessment_backend.TCIG.Domain.enums.Enums;

namespace TCIG_Code_Assessment_backend.TCIG.Domain.Entities
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public ProductStatus Status { get; set; }

        public string? Image { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
