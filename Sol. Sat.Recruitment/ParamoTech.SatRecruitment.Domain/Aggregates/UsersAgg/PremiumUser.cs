using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoTech.SatRecruitment.Domain.Aggregates.UsersAgg
{
    public class PremiumUser : Users
    {
        public override decimal Percentage { get; }
        public override decimal Gif { get; }
        public override decimal Money { get; }

        public PremiumUser(decimal moneyRequest)
        {
            if (moneyRequest > 100)
            {
                Gif = moneyRequest * 2;
                Money = moneyRequest + Gif;
            }
        }
    }
}
