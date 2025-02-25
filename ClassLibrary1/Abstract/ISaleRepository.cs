﻿using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Abstract
{
    public interface ISaleRepository
    {
        IQueryable<Sale> Sales { get; }

        //zapisywanie sprzedaży w bazie
        void SaveSale(Sale sale);   
    }
}
