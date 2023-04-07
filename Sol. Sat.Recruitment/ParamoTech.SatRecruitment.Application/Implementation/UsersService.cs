using Microsoft.Extensions.Logging;
using ParamoTech.SatRecruitment.Application.Interface;
using ParamoTech.SatRecruitment.Domain.Aggregates.UsersAgg;
using ParamoTech.SatRecruitment.DTO.Global;
using ParamoTech.SatRecruitment.DTO.Users.Request;
using ParamoTech.SatRecruitment.DTO.Users.Response;
using ParamoTech.SatRecruitment.Infrastructure;
using ParamoTechDictionary = ParamoTech.SatRecruitment.Common.DictionaryLog;

namespace ParamoTech.SatRecruitment.Application.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly IUsersInfrastructureService _usersInfrastructureService;
        private readonly ILogger<UsersService> _logger;

        public UsersService(IUsersInfrastructureService usersInfrastructureService,
            ILogger<UsersService> logger)
        {
            _usersInfrastructureService = usersInfrastructureService;
            _logger = logger;
        }

        public ResultResponse CreateUser(RequestCreateUser request)
        {
            UsersFactory.CreateUserType(request.UserType, request.Money);

            StreamReader reader = _usersInfrastructureService.ReadUsersFromFile();

            string normalizeEmail = _usersInfrastructureService.GetNormalizeEmail(request.Email);

            var lstUser = new List<ResponseCreateUser>();

            while (reader.Peek() >= 0)
            {
                var user = new ResponseCreateUser();
                var line = reader.ReadLineAsync().Result;
                user.Name = line.Split(',')[0].ToString();
                user.Email = line.Split(',')[1].ToString();
                user.Phone = line.Split(',')[2].ToString();
                user.Address = line.Split(',')[3].ToString();
                user.UserType = line.Split(',')[4].ToString();
                user.Money = decimal.Parse(line.Split(',')[5].ToString());
                ;
                lstUser.Add(user);
            }

            reader.Close();

            return GetResultUsers(lstUser, request, normalizeEmail);
        }

        #region Private Methods

        private ResultResponse GetResultUsers(List<ResponseCreateUser> lstUser, RequestCreateUser request, string normalizeEmail)
        {
            if (lstUser.Exists(x => x.Email.Equals(normalizeEmail) || x.Phone.Equals(request.Phone)))
            {
                _logger.LogInformation(request.Name + " " + ParamoTechDictionary.DuplicatedUser);
                return new ResultResponse() { IsSuccess = false, Errors = ParamoTechDictionary.DuplicatedUser };
            }
               
            if (lstUser.Exists(x => x.Name.Equals(request.Name) && x.Address.Equals(request.Address)))
            {
                _logger.LogInformation(request.Name + " " + ParamoTechDictionary.DuplicatedUser);
                return new ResultResponse() { IsSuccess = false, Errors = ParamoTechDictionary.DuplicatedUser };
            }

            _logger.LogInformation(request.Name + " " + ParamoTechDictionary.UserCreated);
            return new ResultResponse() { IsSuccess = true, Errors = ParamoTechDictionary.UserCreated };
        }

        #endregion
    }
}
