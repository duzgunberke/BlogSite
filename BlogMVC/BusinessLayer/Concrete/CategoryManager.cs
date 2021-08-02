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
    public class CategoryManager/*:ICategoryService*/
    {
        Repository<Category> repoCategory = new Repository<Category>();

        //ICategoryDal _categoryDal;

        //public CategoryManager(ICategoryDal categoryDal)
        //{
        //    _categoryDal = categoryDal;
        //}

        public List<Category> GetAll()
        {
            return repoCategory.List();
        }

        public int CategoryAddBL(Category p)
        {
            if (p.CategoryName == "" || p.CategoryDescription == "")
            {
                return -1;
            }
            return repoCategory.Insert(p);
        }

        public Category FindCategory(int id)
        {
            return repoCategory.Find(x => x.CategoryID == id);
        }

        public int EditCategory(Category p)
        {
            Category category = repoCategory.Find(x => x.CategoryID == p.CategoryID);
            category.CategoryName = p.CategoryName;
            category.CategoryDescription = p.CategoryDescription;
            return repoCategory.Update(category);

        }

        public int DeleteCategoryBL(int id )
        {
            Category category = repoCategory.Find(x => x.CategoryID == id);
            if (category.CategoryStatus == true)
            {
                category.CategoryStatus = false;
            }
            else
            {
                category.CategoryStatus = true;
            }
            return repoCategory.Update(category);

        }

        //public List<Category> GetList()
        //{
        //    return _categoryDal.List();
        //}

        //public void CategoryAdd(Category category)
        //{
        //    _categoryDal.Insert(category);
        //}

        //public void CategoryDelete(Category category)
        //{
        //    _categoryDal.Delete(category);
        //}

        //public void CategoryUpdate(Category category)
        //{
        //    _categoryDal.Update(category);
        //}

        //public Category GetByID(int id)
        //{
        //    return _categoryDal.GetById(id);
        //}
    }
}
