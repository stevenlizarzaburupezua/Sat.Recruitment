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
        public static Users Crear(string userType)
        {
            if (userType == Constants.NormalUser)
            {
                return new NormalUser();
            }

            if (userType == Constants.SuperUser)
            {
                return new SuperUser();
            }

            if (userType == Constants.PremiumUser)
            {
                return new PremiumUser();
            }

            return new Users();
        }
    }

}
