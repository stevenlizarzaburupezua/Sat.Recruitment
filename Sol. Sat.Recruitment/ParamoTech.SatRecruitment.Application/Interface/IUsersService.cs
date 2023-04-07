using ParamoTech.SatRecruitment.DTO.Global;
using ParamoTech.SatRecruitment.DTO.Users.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoTech.SatRecruitment.Application.Interface
{
    public interface IUsersService
    {
        Task<ResultResponse> CreateUser(RequestCreateUser request);
    }
}
