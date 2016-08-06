using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileStore.Domain.Abstract
{
    public interface IProducerRepository
    {
        IQueryable<Producer> Producers { get; }

        void SaveProducer(Producer producer);

        //metoda do usuwania producenta
        Producer DeleteProducer(int producerId);

        //metoda wykorzystywana do zapełniania list rozwijanych z nazwą producenta
        SelectList SelectListProducer(object selectedProducer = null);
    }
}
