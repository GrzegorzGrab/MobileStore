using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Concrete
{
    public class EFProducerRepository:IProducerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Producer> Producers
        {
            get { return context.Producers; }
        }
    }
}
