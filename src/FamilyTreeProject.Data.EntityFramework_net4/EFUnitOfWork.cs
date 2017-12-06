﻿//******************************************
//  Copyright (C) 2014-2015 Charles Nurse  *
//                                         *
//  Licensed under MIT License             *
//  (see included LICENSE)                 *
//                                         *
// *****************************************

using System;
using FamilyTreeProject.Contracts;

namespace FamilyTreeProject.Data.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private FamilyTreeContext _db;

        public EFUnitOfWork(string nameOrConnectionString)
        {
            Initialize(new FamilyTreeContext(nameOrConnectionString));
        }

        public EFUnitOfWork(FamilyTreeContext db)
        {
            Requires.NotNull(db);

            Initialize(db);
        }

        private void Initialize(FamilyTreeContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_db);
        }
    }
}
