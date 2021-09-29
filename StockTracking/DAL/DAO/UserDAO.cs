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
            try
            {
                USER user = db.USERs.First(x => x.ID == entity.ID);
                db.USERs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
            try
            {
                List<UserDetailDTO> users = new List<UserDetailDTO>();
                var list = (from p in db.USERs
                            join c in db.PERMISSIONs on p.IDPermiso equals c.ID
                            select new
                            {
                                name = p.Nombre,
                                IDuser = p.ID,
                                password = p.Contraseña,
                                permiso = c.Permission1,
                                IDpermiso = c.ID
                            }).OrderBy(x => x.IDuser).ToList();
                foreach (var item in list)
                {
                    UserDetailDTO dto = new UserDetailDTO();
                    dto.UserName = item.name;
                    dto.ID = item.IDuser;
                    dto.Password = item.password;
                    dto.PermissionID = item.IDpermiso;
                    dto.PermissionName = item.permiso;
                    users.Add(dto);
                }
                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserDetailDTO> Select(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public bool Update(USER entity)
        {
            try
            {
                USER user = db.USERs.First(x => x.ID == entity.ID);
                user.Nombre = entity.Nombre;
                user.Contraseña = entity.Contraseña;
                user.IDPermiso = entity.IDPermiso;
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
