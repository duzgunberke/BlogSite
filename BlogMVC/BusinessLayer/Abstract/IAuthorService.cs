using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetList();

        void AuthorAdd(Author author);

        About GetByID(int id);

        void AuthorDelete(Author author);

        void AboutUpdate(Author author);
    }
}
