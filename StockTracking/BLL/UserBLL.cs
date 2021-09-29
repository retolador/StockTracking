using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL;
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;

namespace StockTracking.BLL
{
    public class UserBLL : IBLL<UserDetailDTO, UserDTO>
    {
        UserDAO dao = new UserDAO();
        PermissionDAO permissiondao = new PermissionDAO();
        public bool Delete(UserDetailDTO entity)
        {
            USER user = new USER();
            user.ID = entity.ID;
            return dao.Delete(user);
        }

        public bool GetBack(UserDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserDetailDTO entity)
        {
            USER user = new USER();
            user.Nombre = entity.UserName;
            user.Contraseña = entity.Password;
            user.IDPermiso = entity.PermissionID;
            return dao.Insert(user);
        }

        public UserDTO Select()
        {
            UserDTO dto = new UserDTO();
            dto.Users = dao.Select();
            dto.Permissions = permissiondao.Select();
            return dto;
        }
        public UserDTO Select(UserDetailDTO detail)
        {
            UserDTO dto = new UserDTO();
            USER user = new USER();
            user.Nombre = detail.UserName;
            user.Contraseña = detail.Password;
            dto.Users = dao.Select(user);
            return dto;
        }

        public bool Update(UserDetailDTO entity)
        {
            USER user = new USER();
            user.ID = entity.ID;
            user.Nombre = entity.UserName;
            user.Contraseña = entity.Password;
            user.IDPermiso = entity.PermissionID;
            return dao.Update(user);
        }
    }
}
