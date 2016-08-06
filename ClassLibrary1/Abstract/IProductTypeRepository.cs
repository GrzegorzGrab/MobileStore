using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileStore.Domain.Abstract
{
    public interface IProductTypeRepository
    {
        IQueryable<ProductType> ProductTypes { get; }

        //metora do zapisywana zmian dla typu produktu
        void SaveProductType(ProductType productType);

        //metoda do uswania typu produktu
        ProductType DeleteProductType(int productTypeId);

        //metoda do wypełniania list rozwijalnych z typem produktu
        SelectList SelectListProductType(object selectedProductType = null);
    }
}
