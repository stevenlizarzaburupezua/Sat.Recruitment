using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoTech.SatRecruitment.Domain.Aggregates.UsersAgg
{
    public class NormalUser : Users
    {
        public override decimal Percentage { get; }
        public override decimal Gif { get; }
        public override decimal Money { get; }

        public NormalUser(decimal moneyRequest)
        {
            if (moneyRequest > 100)
            {
                Percentage = Convert.ToDecimal(0.12);
                Gif = (moneyRequest * Percentage);
                Money = moneyRequest + Gif;
            }
            if (moneyRequest < 100)
            {
                if (moneyRequest > 10)
                {
                    Percentage = Convert.ToDecimal(0.8);
                    Gif = moneyRequest * Percentage;
                    Money = moneyRequest + Gif;
                }
            }
        }
    }
}
