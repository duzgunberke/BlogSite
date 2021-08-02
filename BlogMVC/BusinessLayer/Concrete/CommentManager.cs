using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager
    {
        Repository<Comment> repoComment = new Repository<Comment>();

        public List<Comment> CommentList()
        {
            return repoComment.List();
        }

        public List<Comment> CommentByBlog(int id)
        {
            return repoComment.List(x => x.BlogID == id).Where(a=>a.CommentStatus==true).ToList();
        }

        public List<Comment> CommentByStatusTrue()
        {
            return repoComment.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return repoComment.List(x => x.CommentStatus == false);
        }

        public int CommentAdd(Comment comment)
        {
            if (comment.CommentText.Length <= 4 || comment.CommentText.Length >= 301 || comment.UserName == "" || comment.Mail == "" || comment.UserName.Length <= 4)
            {
                return -1;
            }
            return repoComment.Insert(comment);
        }

        public int CommentStatusChangeToFalse(int id)
        {
            Comment comment = repoComment.Find(x => x.CommentID == id);
            comment.CommentStatus = false;
            
            return repoComment.Update(comment);
        }

        public int CommentStatusChangeToTrue(int id)
        {
            Comment comment = repoComment.Find(x => x.CommentID == id);
            comment.CommentStatus = true;

            return repoComment.Update(comment);
        }
    }
}
