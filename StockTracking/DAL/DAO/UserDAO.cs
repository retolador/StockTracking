using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;
using StockTracking.DAL;

namespace StockTracking.DAL.DAO
{
    public class UserDAO : StockContext, IDAO<USER, UserDetailDTO>
    {
        public bool Delete(USER entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(USER entity)
        {
            try
            {
                db.USERs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserDetailDTO> Select()
        {
            throw new NotImplementedException();
        }

        public List<UserDetailDTO> Select(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public bool Update(USER entity)
        {
            throw new NotImplementedException();
        }
    }
}
