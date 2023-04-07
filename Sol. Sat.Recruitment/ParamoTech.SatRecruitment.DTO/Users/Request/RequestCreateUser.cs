using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ParamoTechDictionary = ParamoTech.SatRecruitment.Common.DictionaryLog;

namespace ParamoTech.SatRecruitment.DTO.Users.Request
{
    public class RequestCreateUser
    {
        public string Name
        {
            get => Name;
            set => Name = value ??
                throw new ArgumentNullException(nameof(value), ParamoTechDictionary.NameRequired);
        }

        public string Email
        {
            get => Email;
            set => Email = value ??
                throw new ArgumentNullException(nameof(value), ParamoTechDictionary.EmailRequired);
        }

        public string Address
        {
            get => Address;
            set => Address = value ??
                throw new ArgumentNullException(nameof(value), ParamoTechDictionary.AddressRequired);
        }

        public string UserType
        {
            get => UserType;
            set => UserType = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }

        public string Money
        {
            get => Money;
            set => Money = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }
    }
}
