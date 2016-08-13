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
    public class EFProducerRepository:IProducerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Producer> Producers
        {
            get { return context.Producers; }
        }

        public void SaveProducer(Producer producer)
        {
            if (producer.ProducerID == 0)
            {
                context.Producers.Add(producer);
            }
            else
            {
                Producer dbEntry = context.Producers.Find(producer.ProducerID);
                if (dbEntry != null)
                {
                    dbEntry.ProducerName = producer.ProducerName;
                    dbEntry.ProducerDescription = producer.ProducerDescription;
                }
            }
            context.SaveChanges();
        }

        //implementacja metody usuwającej producenta
        public Producer DeleteProducer(int producerId)
        {
            Producer dbEntry = context.Producers.Find(producerId);
            if (dbEntry != null)
            {
                context.Producers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //implementacja metoda wykorzystywana do zapełniania list rozwijanych z nazwą producenta
        public SelectList SelectListProducer(object selectedProducer = null)
        {
            var producersQuery = from d in context.Producers
                                 orderby d.ProducerName
                                 select d;
            SelectList ProducerList = new SelectList(producersQuery, "ProducerID", "ProducerName", selectedProducer); 
            return ProducerList;
        }

        //implementacja metody do wyświetlania szczegółów producenta
        public Producer ProducerDetails (int producerId)
        {
            Producer producerDetails = context.Producers.Find(producerId);
            return producerDetails;
        }
    }
}
