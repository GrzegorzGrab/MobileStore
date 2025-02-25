﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;

namespace MobileStore.Domain.Concrete
{
    public class EFCommodityRepository: ICommodityRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Commodity> Commodities
        {
            get { return context.Commodities; }
        }
        
        //implementacja metody zapisujacej towar w bazie
        public void SaveCommodity (Commodity commodity)
        {
            if (commodity.CommodityID == 0)
            {
                commodity.IsAvailable = true; //zawsze nowy towar jest dostępny do sprzedazy
                context.Commodities.Add(commodity);
            }
            else
            {
                Commodity dbEntry = context.Commodities.Find(commodity.CommodityID);
                if (dbEntry != null)
                {
                    dbEntry.ProductModelID = commodity.ProductModelID;
                    dbEntry.SellerID = commodity.SellerID;
                    dbEntry.PurchaseDate = commodity.PurchaseDate;
                    dbEntry.Condition = commodity.Condition;
                    dbEntry.Description = commodity.Description;
                    dbEntry.SimLockerID = commodity.SimLockerID;
                }
            }
            context.SaveChanges();
        }

        public void ChangeCommodityAvailability (int commodityId)
        {
            if (commodityId!= 0)
            {
                Commodity updatedCommodity = new Commodity();
                updatedCommodity = context.Commodities.Find(commodityId);
                updatedCommodity.IsAvailable = false;
                context.SaveChanges();
            }
        }
    }
}
