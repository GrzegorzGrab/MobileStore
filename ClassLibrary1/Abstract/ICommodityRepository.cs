using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Abstract
{
    public interface ICommodityRepository
    {
        IQueryable<Commodity> Commodities { get;  }

        //zapisywanie towaru w bazie
        void SaveCommodity(Commodity commodity);

        //sprzedaz towaru - zmiana pola IsAvailale z true na false
        void ChangeCommodityAvailability(int commodityId);
    }
}
