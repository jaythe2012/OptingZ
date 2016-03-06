﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.DAL
{
    public class UnitOfWork : IDisposable
    {
        private OptingzDbContext context = new OptingzDbContext();
        private ProductRepository productRepository;
        private ProductCategoryRepository productCategoryRepository;


        #region Repos

        public ProductRepository ProductRepository
        {
            get
            {
                if(this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(context);
                }
                return productRepository;
            }
        }

        public ProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (this.productCategoryRepository == null)
                {
                    this.productCategoryRepository = new ProductCategoryRepository(context);
                }
                return productCategoryRepository;
            }
        }

        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}