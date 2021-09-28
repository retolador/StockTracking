using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;
using StockTracking.DAL.DAO;
using StockTracking.DAL;



namespace StockTracking.BLL
{
    class SalesBLL : IBLL<SalesDetailDTO, SalesDTO>
    {
        SalesDAO salesdao = new SalesDAO();
        ProductDAO productdao = new ProductDAO();
        CategoryDAO categorydao = new CategoryDAO();
        CustomerDAO customerdao = new CustomerDAO();
        public bool Delete(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.ID = entity.SalesID;
            salesdao.Delete(sales);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount + entity.SalesAmount;
            productdao.Update(product);
            return true;
        }

        public bool GetBack(SalesDetailDTO entity)
        {
            salesdao.GetBack(entity.SalesID);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            int temp = entity.StockAmount - entity.SalesAmount;
            product.StockAmount = temp;
            productdao.Update(product);
                
            return true;

        }

        public bool Insert(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.CategoryID = entity.CategoryID;
            sales.ProductID = entity.ProductID;
            sales.CustomerID = entity.CustomerID;
            sales.ProductSalesPrice = entity.Price;
            sales.ProductSalesAmount = entity.SalesAmount;
            sales.SalesDate = entity.SalesDate;
            salesdao.Insert(sales);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            int temp = entity.StockAmount - entity.SalesAmount;
            product.StockAmount = temp;
            productdao.Update(product);
            return true;
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productdao.Select();
            dto.Customers = customerdao.Select();
            dto.Categories = categorydao.Select();
            dto.Sales = salesdao.Select();
            return dto;

        }

        public SalesDTO Select(bool isDeleted)
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productdao.Select(isDeleted);
            dto.Customers = customerdao.Select(isDeleted);
            dto.Categories = categorydao.Select(isDeleted);
            dto.Sales = salesdao.Select(isDeleted);
            return dto;

        }

        public bool Update(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.ID = entity.SalesID;
            sales.ProductSalesAmount = entity.SalesAmount;
            salesdao.Update(sales);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount;
            productdao.Update(product);
            return true;

        }
    }
}
