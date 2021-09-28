﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DTO
{
    public class UserDTO
    {
        public List<PermissionDetailDTO> Permissions { get; set; }
        public List<UserDetailDTO> Users { get; set; }
    }
}
