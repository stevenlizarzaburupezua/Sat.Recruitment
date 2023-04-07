using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoTech.SatRecruitment.Domain.Aggregates.UsersAgg
{
    public class SuperUser : Users
    {
        public override decimal Percentage { get; }
        public override decimal Gif { get; }
        public override decimal Money { get; }

        public SuperUser(decimal moneyRequest)
        {
            if (moneyRequest > 100)
            {
                Percentage = Convert.ToDecimal(0.20);
                Gif = moneyRequest * Percentage;
                Money = moneyRequest + Gif;
            }
        }
    }
}
