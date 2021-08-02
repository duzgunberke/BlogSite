﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();

        void ContactAdd(Contact contact);

        Blog GetByID(int id);

        void ContactDelete(Contact contact);

        void ContactUpdate(Contact contact);
    }
}
