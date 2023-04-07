using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParamoTech.SatRecruitment.Domain.Resources;

namespace ParamoTech.SatRecruitment.Domain.Aggregates.UsersAgg
{
    public class Users
    {
        public virtual decimal Percentage { get; }
        public virtual decimal Gif{ get; }
        public virtual decimal Money { get; }
    }
}
