using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileStore.Domain.Abstract
{
    public interface ISimLockerRepository
    {
        //do pobierania listy blokad z bazy
        IQueryable<SimLocker> SimLockers { get; }

        //metoda do zapisywania blokad SimLock do bazy
        void SaveSimLocker(SimLocker simLocker);

        //metoda do usuwania blokady SimLock z bazy
        SimLocker DeleteSimLocker(int simLockerId);

        //metoda do wypełniania listy rozwijalnej z blokadą SIMLOCK
        SelectList SelectListSimLocker(object selectedSimLocker=null);
    }
}
