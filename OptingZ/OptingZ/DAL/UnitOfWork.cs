using OptingZ.DAL.Repository;
using System;
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
        private UserFileRepository userFileRepository;
        private UserRepository userRepository;
        private UserDetailRepository userDetailRepository;
        private CategoryRepository categoryRepository;


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

        public UserFileRepository UserFileRepository
        {
            get
            {
                if (this.userFileRepository == null)
                {
                    this.userFileRepository = new UserFileRepository(context);
                }
                return userFileRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public UserDetailRepository UserDetailRepository
        {
            get
            {
                if (this.userDetailRepository == null)
                {
                    this.userDetailRepository = new UserDetailRepository(context);
                }
                return userDetailRepository;
            }
        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
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