using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoTech.SatRecruitment.Infrastructure
{
    public interface IUsersInfrastructureService
    {
        public StreamReader ReadUsersFromFile();

        public string GetNormalizeEmail(string email);
    }
}
