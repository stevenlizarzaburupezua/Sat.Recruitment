using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParamoTech.SatRecruitment.Domain.Resources;

namespace ParamoTech.SatRecruitment.Domain.Aggregates.UsersAgg
{
    public static class UsersFactory
    {
        public static Users CreateUserType(string userType, decimal moneyRequest)
        {
            if (userType.Equals(Constants.NormalUser))
                return new NormalUser(moneyRequest);

            if (userType.Equals(Constants.SuperUser))
                return new SuperUser(moneyRequest);

            if (userType.Equals(Constants.PremiumUser))
                return new PremiumUser(moneyRequest);

            return new Users();
        }
    }

}
