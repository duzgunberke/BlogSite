using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList();

        void CommentAdd(Comment comment);

        Blog GetByID(int id);

        void CommentDelete(Comment comment);

        void CommentUpdate(Comment comment);
    }
}
