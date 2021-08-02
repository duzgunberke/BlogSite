using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(300)]
        public string AuthorImage { get; set; }

        [StringLength(500)]
        public string AuthorAbout { get; set; }

        [StringLength(50)]
        public string AuthorTitle { get; set; }

        [StringLength(50)]
        public string AboutShort { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
