using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Concrete
{
    public class EFSaleRepository:ISaleRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Sale> Sales
        {
            get { return context.Sales; }
        }

        //implementacja metody zapisującej sprzedaż w bazie
        public void SaveSale(Sale sale)
        {
            if (sale.SaleID == 0)
            {
                context.Sales.Add(sale);
            }
            else
            {
                Sale dbEntry = context.Sales.Find(sale.SaleID);
                if (dbEntry != null)
                {
                    dbEntry.CommodityID = sale.CommodityID;
                    dbEntry.SalesDate = sale.SalesDate;
                    dbEntry.SalesPrice = sale.SalesPrice;
                    dbEntry.InvoiceID = sale.InvoiceID;
                }
            }
            context.SaveChanges();
        }
    }
}
