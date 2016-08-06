using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStore.WebUI.Models
{
    public class CommodityListViewModel
    {
        public Commodity Commodity { get; set; }

        public string SellerName { get; set; }

        public CommodityListViewModel(Commodity com , string sellerName) 
        {
            Commodity = com;
            SellerName = sellerName;
        }
   
        /*
        public IQueryable<CommodityListViewModel> CommodityListViewModelList(IQueryable<Commodity> commodityList)
        {
            List<CommodityListViewModel> comListViewModelList =new List<CommodityListViewModel>();
            foreach (Commodity com in commodityList)
            {
                comListViewModelList.Add(new CommodityListViewModel (com,))
            }
        }
        */
    }
}