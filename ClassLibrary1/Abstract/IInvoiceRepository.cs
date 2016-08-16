using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Abstract
{
    public interface IInvoiceRepository
    {
        IQueryable<Invoice> Invoices { get; }

        //zapisanie fakury w bazie 
        void SaveInvoice(Invoice invoice);

        //aktualizacja kwoty faktury w przypdku rejestracji sprzedazy towaru
        void EditInvoiceAmount(int invoiceId);
    }
}
