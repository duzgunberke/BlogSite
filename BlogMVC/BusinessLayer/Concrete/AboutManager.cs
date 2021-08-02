using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoAbout = new Repository<About>();
        public List<About> GetAll()
        {
            return repoAbout.List();
        }

        public int UpdateAboutBM(About p)
        {
            About about = repoAbout.Find(x => x.AboutID == p.AboutID);
            about.AboutImage1 = p.AboutImage1;
            about.AboutImage2 = p.AboutImage2;
            about.AboutContent1 = p.AboutContent1;
            about.AboutContent2 = p.AboutContent2;
            about.AboutID = p.AboutID;
            return repoAbout.Update(about);
        }
    }
}
