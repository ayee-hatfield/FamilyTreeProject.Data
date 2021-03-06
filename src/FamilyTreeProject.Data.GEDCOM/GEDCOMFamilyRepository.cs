﻿//******************************************
//  Copyright (C) 2014-2015 Charles Nurse  *
//                                         *
//  Licensed under MIT License             *
//  (see included LICENSE)                 *
//                                         *
// *****************************************

using System;
using System.Collections.Generic;
using System.Linq;
using FamilyTreeProject.Collections;
using FamilyTreeProject.Contracts;

namespace FamilyTreeProject.Data.GEDCOM
{
    public class GEDCOMFamilyRepository : IRepository<Family>
    {
        private readonly IGEDCOMStore _database;

        public GEDCOMFamilyRepository(IGEDCOMStore database)
        {
            Requires.NotNull(database);

            _database = database;
        }

        public void Add(Family item)
        {
            Requires.NotNull(item);

            _database.AddFamily(item);
        }

        public void Delete(Family item)
        {
            Requires.NotNull(item);

            _database.DeleteFamily(item);
        }

        public IEnumerable<Family> Find(string sqlCondition, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Family> Find(int pageIndex, int pageSize, string sqlCondition, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Family> Find(Func<Family, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IPagedList<Family> Find(int pageIndex, int pageSize, Func<Family, bool> predicate)
        {
            return GetAll().Where(predicate).InPagesOf(pageSize).GetPage(pageIndex);
        }

        public IEnumerable<Family> Get<TScopeType>(TScopeType scopeValue)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Family> IRepository<Family>.GetAll()
        {
            return GetAll();
        }

        public Family GetById<TProperty>(TProperty id)
        {
            throw new NotImplementedException();
        }

        public Family GetById<TProperty, TScopeType>(TProperty id, TScopeType scopeValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Family> GetAll()
        {
            return _database.Families;
        }

        public IPagedList<Family> GetPage(int pageIndex, int pageSize)
        {
            return GetAll().InPagesOf(pageSize).GetPage(pageIndex);
        }

        public IPagedList<Family> GetPage<TScopeType>(TScopeType scopeValue, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(Family item)
        {
            Requires.NotNull(item);

            _database.UpdateFamily(item);
        }

        public IEnumerable<Family> GetByProperty<TProperty>(string propertyName, TProperty propertyValue)
        {
            throw new NotImplementedException();
        }
    }
}
