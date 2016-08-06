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
    public class EFSimLockerRepository: ISimLockerRepository
    {
        private EFDbContext context = new EFDbContext();
        //do pobierania listy blokad z bazy
        public IQueryable<SimLocker> SimLockers
        {
            get { return context.SimLockers; }
        }

        //implementacja metody do zapisywania block SimLock do bazy
        public void SaveSimLocker(SimLocker simLocker)
        {
            if (simLocker.SimLockerID == 0)
            {
                context.SimLockers.Add(simLocker);
            }
            else
            {
                SimLocker dbEntry = context.SimLockers.Find(simLocker.SimLockerID);
                if (dbEntry != null)
                {
                    dbEntry.Name = simLocker.Name;
                }
            }
            context.SaveChanges();
        }

        //implementacja metody usuwającej blokadę SimLock z bazy
        public SimLocker DeleteSimLocker(int simLockerId)
        {
            SimLocker dbEntry = context.SimLockers.Find(simLockerId);
            if (dbEntry != null)
            {
                context.SimLockers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //implementacja metody do wypełniania listy rozwijalnej z blokadą simlock
        public SelectList SelectListSimLocker(object selectedSimLocker=null)
        {
            var querySimLocker = from s in context.SimLockers
                                 orderby s.Name
                                 select s;
            SelectList SimLockerList = new SelectList(querySimLocker, "SimLockerID", "Name", selectedSimLocker);
            return SimLockerList;
        }
    }
}
