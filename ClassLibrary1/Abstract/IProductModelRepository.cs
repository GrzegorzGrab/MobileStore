using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileStore.Domain.Abstract
{
    public interface IProductModelRepository
    {
        IQueryable<ProductModel>ProductModels { get; }

        void SaveProductModel(ProductModel productModel);

        //metoda do usuwania modelu produktu
        ProductModel DeleteProductModel(int productModelId);

        //metoda do wypełniana listy rozwijalnej z modelem produktu
        SelectList SelectListProductModel(object selectedProductModel = null);
    }
}
