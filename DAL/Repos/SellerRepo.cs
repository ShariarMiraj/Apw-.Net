using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SellerRepo : Repo, IRepo<Seller, string, Seller>
    {
        public Seller Create(Seller obj)
        {
            db.Sellers.Add(obj);
            if (db.SaveChanges () > 0 )
                return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Sellers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Seller> Read()
        {
            return db.Sellers.ToList();
        }

        public Seller Read(string id)
        {
            return db.Sellers.Find(id);
        }

        public Seller Update(Seller Obj)
        {
            var ex = Read(Obj.Sname);
            db.Entry(ex).CurrentValues.SetValues(Obj);
            if (db.SaveChanges() > 0 )
                return Obj;
            return null;
        }
    }
}
