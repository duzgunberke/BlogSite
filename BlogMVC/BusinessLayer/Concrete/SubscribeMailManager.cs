using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager
    {
        Repository<SubscribeMail> repoSubscribeMail = new Repository<SubscribeMail>();

        public int BLAdd(SubscribeMail p)
        {
            if (p.Mail.Length <= 10 || p.Mail.Length >= 50)
            {
                return -1;
            }

            return repoSubscribeMail.Insert(p);
        }
    }
}
