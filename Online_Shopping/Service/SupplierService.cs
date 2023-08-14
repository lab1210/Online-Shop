using Online_Shopping.IService;
using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shopping.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ShoppingContext _context;
        public SupplierService()
        {
            _context = new ShoppingContext();
        }
        public Supplier AddSupplier(Supplier supplier)
        {
            var existing = _context.Suppliers.FirstOrDefault(c => c.Name == supplier.Name);
            if (existing == null)
            {

                _context.Suppliers.Add(supplier);
                _context.SaveChanges();

                return supplier;
            }
            else
            {
                throw new Exception(existing.Name + " supplier already exists");

            }
        }
        public void DeleteSupplier(int code)
        {
            var supplier = _context.Suppliers.FirstOrDefault(c => c.Id == code);
            _context.Suppliers.Remove(supplier);

            _context.SaveChanges();
        }
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }
        public void UpdateSupplier(Supplier Supplier)
        {
            this._context.Entry(Supplier).State = EntityState.Modified;
            this._context.SaveChanges();

        }
        public Supplier GetSupplierByID(int id)
        {
            return _context.Suppliers.Find(id);
        }

    }
}