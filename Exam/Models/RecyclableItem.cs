using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecyclingApp.Models
{
    public class RecyclableItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("RecyclableType")]
        public int RecyclableTypeId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Weight { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal ComputedRate { get; set; }

        [StringLength(150)]
        public string ItemDescription { get; set; }

        public virtual RecyclableType RecyclableType { get; set; }

        // Method to compute ComputedRate based on RecyclableType rate and Weight
        public void ComputeRate(decimal recyclableTypeRate)
        {
            // Compute ComputedRate
            ComputedRate = Math.Round(recyclableTypeRate * Weight, 2);
        }
    }
}