using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        //fetch all authors list
        Repository<Author> repoAuthor = new Repository<Author>();
        public List<Author> GetAll()
        {
            return repoAuthor.List();
        }

        //Add a new author
        public int AddAuthorBL(Author author)
        {
            //control of the values sent from the parameter
            if (author.AuthorName == "" || author.AboutShort == "" || author.AuthorTitle == "" || author.AuthorImage == "")
            {
                return -1;
            }
            return repoAuthor.Insert(author);
        }

        //move author to edit page by id
        public Author FindAuthor(int id)
        {
            return repoAuthor.Find(x => x.AuthorID == id);
        }

        public int EditAuthor(Author p)
        {
            Author author = repoAuthor.Find(x => x.AuthorID == p.AuthorID);
            author.AboutShort = p.AboutShort;
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repoAuthor.Update(author);

        }
    }
}
