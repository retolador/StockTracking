using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;
using StockTracking.DAL;

namespace StockTracking.DAL.DAO
{
    class SalesDAO : StockContext, IDAO<SALE, SalesDetailDTO>
    {
        public bool Delete(SALE entity)
        {
            try
            {
                if(entity.ID != 0)
                {
                    SALE sales = db.SALES.First(x => x.ID == entity.ID);
                    sales.isDeleted = true;
                    sales.DeletedDate = DateTime.Today;
                    db.SaveChanges();
                }
                else if(entity.ProductID!=0)
                {
                    List<SALE> sales = db.SALES.Where(x => x.ProductID == entity.ProductID).ToList();
                    foreach (var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Today;
                    }
                    db.SaveChanges();
                }
                else if(entity.CustomerID!=0)
                {
                    List<SALE> sales = db.SALES.Where(x => x.CustomerID == entity.CustomerID).ToList();
                    foreach (var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Today;
                    }
                    db.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            try
            {
                SALE sales = db.SALES.First(x => x.ID == ID);
                sales.isDeleted = false;
                sales.DeletedDate = null;
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(SALE entity)
        {
            try
            {
                db.SALES.Add(entity);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
            

        public List<SalesDetailDTO> Select()
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALES.Where(x => x.isDeleted == false)
                            join p in db.PRODUCTs on s.ProductID equals p.ID
                            join c in db.CUSTOMERs on s.CustomerID equals c.ID
                            join category in db.CATEGORies on s.CategoryID equals category.ID
                            select new
                            {
                                productName = p.ProductName,
                                customerName = c.CustomerName,
                                categoryName = category.CategoryName,
                                productD = s.ProductID,
                                customerID = c.ID,
                                salesID = s.ID,
                                categoryID = s.CategoryID,
                                salesamount = s.ProductSalesAmount,
                                salesprice = s.ProductSalesPrice,
                                salesdate = s.SalesDate

                            }).OrderBy(x => x.salesdate).ToList();
                foreach (var item in list)
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CustomerName = item.customerName;
                    dto.CategoryName = item.categoryName;
                    dto.ProductID = item.productD;
                    dto.CustomerID = item.customerID;
                    dto.CategoryID = item.categoryID;
                    dto.SalesID = item.salesID;
                    dto.Price = item.salesprice;
                    dto.SalesAmount = item.salesamount;
                    dto.SalesDate = item.salesdate;
                    sales.Add(dto);

                }
                return sales;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SalesDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALES.Where(x => x.isDeleted == isDeleted)
                            join p in db.PRODUCTs on s.ProductID equals p.ID
                            join c in db.CUSTOMERs on s.CustomerID equals c.ID
                            join category in db.CATEGORies on s.CategoryID equals category.ID
                            select new
                            {
                                productName = p.ProductName,
                                customerName = c.CustomerName,
                                categoryName = category.CategoryName,
                                productD = s.ProductID,
                                customerID = c.ID,
                                salesID = s.ID,
                                categoryID = s.CategoryID,
                                salesamount = s.ProductSalesAmount,
                                salesprice = s.ProductSalesPrice,
                                salesdate = s.SalesDate,
                                categorydeleted = category.isDeleted,
                                customerdeleted = c.isDeleted,
                                productdeleted = p.isDeleted

                            }).OrderBy(x => x.salesdate).ToList();
                foreach (var item in list)
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CustomerName = item.customerName;
                    dto.CategoryName = item.categoryName;
                    dto.ProductID = item.productD;
                    dto.CustomerID = item.customerID;
                    dto.CategoryID = item.categoryID;
                    dto.SalesID = item.salesID;
                    dto.Price = item.salesprice;
                    dto.SalesAmount = item.salesamount;
                    dto.SalesDate = item.salesdate;
                    dto.IsCategoryDeleted = item.categorydeleted;
                    dto.IsCustomerDeleted = item.customerdeleted;
                    dto.IsProductDeleted = item.productdeleted;
                    sales.Add(dto);

                }
                return sales;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(SALE entity)
        {
            try
            {
                SALE sales = db.SALES.First(x => x.ID == entity.ID);
                sales.ProductSalesAmount = entity.ProductSalesAmount;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
