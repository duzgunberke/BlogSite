using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager:IBlogService
    {
        Repository<Blog> repoBlog = new Repository<Blog>();

        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetAll()
        {
            return repoBlog.List();
        }

       public List<Blog> GetBlogById(int id)
        {
            return repoBlog.List(x => x.BlogID == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoBlog.List(x => x.AuthorID == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return repoBlog.List(x => x.CategoryID == id);
        }
        public int BlogAddBL(Blog p)
        {
            if (p.BlogTitle == "" || p.BlogImage == "" || p.BlogTitle.Length <= 4 || p.BlogContent.Length <= 100)
            {
                return -1;
            }
            return repoBlog.Insert(p);
        }
        public int DeleteBlogBL(int p)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == p);
            return repoBlog.Delete(blog);
        }

        public Blog FindBlog(int id)
        {
            return repoBlog.Find(x => x.BlogID == id);
        }

        public int UpdateBlog(Blog p)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            return repoBlog.Update(blog);
        }

        public List<Blog> GetList()
        {
            throw new NotImplementedException();
        }

        public void BlogAdd(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void BlogDelete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void BlogUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
