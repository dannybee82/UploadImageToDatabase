using System.ComponentModel.DataAnnotations;

namespace UploadImageToDatabase.Model
{

    public class ImageDataValidation
    {
        public int Id { get; set; } = -1;

        [Required, MaxLength(80)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public double Rating { get; set; } = (double) 0.0;

        [Required]
        public byte[] Image { get; set; } = default!;

    }

}
