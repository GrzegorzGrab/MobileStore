using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileStore.Domain.Concrete
{
    public class EFSellerRepository: ISellerRepository
    {
        private EFDbContext context = new EFDbContext();

        //implementacja pobierania listy sprzedawców z bazy danych 
        public IQueryable<Seller> Sellers
        {
            get { return context.Sellers; }
        }

        //implementacja metody do zapisu sprzedawcy w bazie
        public void SaveSeller(Seller seller)
        {
            if (seller.SellerID == 0)
            {
                context.Sellers.Add(seller);
            }
            else
            {
                Seller dbEntry = context.Sellers.Find(seller.SellerID);
                if (dbEntry != null)
                {
                    dbEntry.Pesel = seller.Pesel;
                    dbEntry.FirstName = seller.FirstName;
                    dbEntry.LastName = seller.LastName;
                    dbEntry.PhoneNumber = seller.PhoneNumber;
                    dbEntry.Email = seller.Email;
                    dbEntry.IsRemoved = seller.IsRemoved;
                }
            }
            context.SaveChanges();
        }

        //implementacja metody usuwania sprzedawcy z bazy
        public Seller DeleteSeller(int sellerId)
        {
            Seller dbEntry = context.Sellers.Find(sellerId);
            if (dbEntry != null)
            {
                context.Sellers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        } 

        //implementacja metody do wypełnienia listy z sprzedawcami
        public SelectList SelectListSeller(object selectedSeller = null)
        {
            var sellerQuery = from s in context.Sellers
                              orderby s.LastName
                              select s;
            SelectList SellerList = new SelectList(sellerQuery, "SellerID", "GetFullName", selectedSeller);
            return SellerList;
        }
    }
}
