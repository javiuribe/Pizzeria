﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructures.UOW
{
    public class UnitOfWork : IDisposable
    {
        private PizzaShopContext context = new PizzaShopContext();
        private GenericRepository<Pizza> _pizzaRepository;
        private GenericRepository<User> _userRepository;
        private bool _disposed = false;

        public GenericRepository<Pizza> PizzaRepository
        {
            get
            {
                if (this._pizzaRepository == null)
                {
                    _pizzaRepository = new GenericRepository<Pizza>(context);
                }
                return _pizzaRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(context);
                }
                return _userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}