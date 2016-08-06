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
    public class EFProductModelRepository : IProductModelRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<ProductModel> ProductModels
        {
            get { return context.ProductModels; }
        }

        public void SaveProductModel(ProductModel productModel)
        {
            if (productModel.ProductModelID == 0)
            {
                context.ProductModels.Add(productModel);
            }
            else
            {
                ProductModel dbEntry = context.ProductModels.Find(productModel.ProductModelID);
                if (dbEntry != null)
                {
                    dbEntry.ProductModelName = productModel.ProductModelName;
                    dbEntry.ProducerID = productModel.ProducerID;
                    dbEntry.ProductTypeID = productModel.ProductTypeID;
                    dbEntry.ScreenSize = productModel.ScreenSize;
                    dbEntry.Weight = productModel.Weight;
                    dbEntry.Memory = productModel.Memory;
                    dbEntry.Ram = productModel.Ram;
                    dbEntry.Description = productModel.Description;
                    dbEntry.UrlAddress = productModel.UrlAddress;
                }
            }
            context.SaveChanges();
        }

        //implementacja metody do usuwania modelu produktu
        public ProductModel DeleteProductModel(int productModelId)
        {
            ProductModel dbEntry = context.ProductModels.Find(productModelId);
            if (dbEntry != null)
            {
                context.ProductModels.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //implementacja metody do wypełniania list z produktem modelu,
        public SelectList SelectListProductModel(object selectedProductModel = null)
        {
            var productModelsQuery = (from m in context.ProductModels
                                      join p in context.Producers on m.ProducerID equals p.ProducerID
                                      orderby m.ProductModelName
                                      select new
                                      {
                                          ProductModelID = m.ProductModelID,
                                          ProductModelName = m.ProductModelName + " " + p.ProducerName,
                                          ProducerName = p.ProducerName
                                      }).ToList();
            /*
            List<SelectListItem> listData = new List<SelectListItem>();
            foreach (var item in productModelsQuery)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = Convert.ToString(item.ProductModelID);
                sli.Text = item.ProductModelName;
                listData.Add(sli);
            }
            //http://www.dotnetfunda.com/forums/show/18409/how-to-bind-dropdownlist-from-two-table-in-mvc-using-entity-framework
            //http://www.mikesdotnetting.com/article/265/asp-net-mvc-dropdownlists-multiple-selection-and-enum-support
            */

            SelectList ProductModelList = new SelectList(productModelsQuery, "ProductModelID", "ProductModelName", selectedProductModel);
            return ProductModelList;
        }
    }
}
