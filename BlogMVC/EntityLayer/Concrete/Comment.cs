using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [StringLength(60)]
        public string UserName { get; set; }

        [StringLength(60)]
        public string Mail { get; set; }

        [StringLength(300)]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        [DefaultValue("0")]
        public bool CommentStatus { get; set; }

        public int BlogRating { get; set; }

        public int BlogID { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
