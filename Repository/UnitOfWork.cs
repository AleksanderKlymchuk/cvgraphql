﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CVContext _cvContext;
        public UnitOfWork(IPersonRepository personRepository, CVContext cvContext)
        {
            Persons = personRepository;
            _cvContext = cvContext;
        }
        public IPersonRepository Persons { get; private set; }
        

        public int Commit()
        {
            return _cvContext.SaveChanges();
        }

        public void Dispose()
        {
            _cvContext.Dispose();
        }
    }
}
