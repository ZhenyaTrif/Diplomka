using System.ComponentModel.DataAnnotations;

namespace Common.Entity
{
    public class AuctionLot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LotName { get; set; }

        [Required]
        public string Text { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string StartPrice { get; set; }

        [Required]
        public int LotCategoryId { get; set; }

        public string CreaterId { get; set; }

        public bool Checked { get; set; }

        public bool Opened { get; set; }

        public string WinnerId { get; set; }
    }
}
