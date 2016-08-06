using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Concrete
{
    public class EFInvoiceRepository:IInvoiceRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Invoice> Invoices
        {
            get { return context.Invoices; }
        }

        //implementacja metody do zapisania faktury w bazie
        public void SaveInvoice (Invoice invoice)
        {
            if (invoice.InvoiceID == 0)
            {
                context.Invoices.Add(invoice);
            }
            else
            {
                Invoice dbEntry = context.Invoices.Find(invoice.InvoiceID);
                if (dbEntry != null)
                {
                    dbEntry.InvoiceNumber = invoice.InvoiceNumber;
                }
            }
            context.SaveChanges();
        }
    }
}
