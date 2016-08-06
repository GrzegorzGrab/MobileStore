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
    public class EFProductTypeRepository: IProductTypeRepository
    {
        //wygenerowanie obiektu EFDbContext dla połączeń z bazą danych
        private EFDbContext context = new EFDbContext();

        public IQueryable<ProductType> ProductTypes
        {
            get { return context.ProductTypes; }
        }


        //implementacja metody do zapisywania zmian dla typu produktu i dodawania nowego typu produktu
        public void SaveProductType(ProductType productType)
        {
            if (productType.ProductTypeID == 0)
            {
                context.ProductTypes.Add(productType);
            }
            else
            {
                ProductType dbEntry = context.ProductTypes.Find(productType.ProductTypeID);
                if (dbEntry != null)
                {
                    dbEntry.ProductTypeName = productType.ProductTypeName;
                }
            }
            context.SaveChanges();
        }

        //implementacja metody usuwającej typ produktu
        public ProductType DeleteProductType(int productTypeId)
        {
            ProductType dbEntry = context.ProductTypes.Find(productTypeId);
            if (dbEntry != null)
            {
                context.ProductTypes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //implementacja metody do wypełnienia listy rozwijalnej z typem produktu
        public SelectList SelectListProductType(object selectedProductType = null)
        {
            var productTypeQuery = from p in context.ProductTypes
                                   orderby p.ProductTypeName
                                   select p;
            SelectList ProductTypeList = new SelectList(productTypeQuery, "ProductTypeID", "ProductTypeName", selectedProductType);
            return ProductTypeList;
        }
    }
}
