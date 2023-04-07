using Newtonsoft.Json.Linq;
using ParamoTech.SatRecruitment.Application.Interface;
using ParamoTech.SatRecruitment.DTO.Global;
using ParamoTech.SatRecruitment.DTO.Users.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParamoTechDictionary = ParamoTech.SatRecruitment.Common.DictionaryLog;

namespace ParamoTech.SatRecruitment.Application.Implementation
{
    public class UsersService : IUsersService
    {
        public async Task<ResultResponse> CreateUser(RequestCreateUser request)
        {   
            return new ResultResponse() { IsSuccess = true, Errors = ParamoTechDictionary.DuplicatedUser };
        }

 
    }
}
