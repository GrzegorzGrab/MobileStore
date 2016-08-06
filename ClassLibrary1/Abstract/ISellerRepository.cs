using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileStore.Domain.Abstract
{
    public interface ISellerRepository
    {

        IQueryable<Seller> Sellers { get; }

        //metoda do zapisywania sprzedawcy w bazie danych 
        void SaveSeller(Seller seller);

        //metoda do usuwania sprzedawców z bazy
        Seller DeleteSeller(int sellerId);


        //metodat do wypłeniania listy rozwijalnej z sprzedawcą
        SelectList SelectListSeller(object selectedSeller = null);
    }
}
