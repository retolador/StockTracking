using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;

namespace StockTracking.DAL.DAO
{
    public class PermissionDAO : StockContext, IDAO<PERMISSION, PermissionDetailDTO>
    {
        public bool Delete(PERMISSION entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PERMISSION entity)
        {
            throw new NotImplementedException();
        }

        public List<PermissionDetailDTO> Select()
        {
            try
            {
                List<PermissionDetailDTO> permissions = new List<PermissionDetailDTO>();
                var list = db.PERMISSIONs.ToList();
                foreach (var item in list)
                {
                    PermissionDetailDTO dto = new PermissionDetailDTO();
                    dto.ID = item.ID;
                    dto.PermissionName = item.Permission1;
                    Console.WriteLine("Permiso: " + dto.PermissionName);
                    permissions.Add(dto);
                }
                return permissions;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PermissionDetailDTO> Select(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public bool Update(PERMISSION entity)
        {
            throw new NotImplementedException();
        }
    }
}
