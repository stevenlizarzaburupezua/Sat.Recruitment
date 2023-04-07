using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace ParamoTech.SatRecruitment.DTO.Global
{
    public  class ResultResponse
    {
        [SwaggerSchema("Flag que indica que la transacción es correcta.")]
        public bool IsSuccess { get; set; }

        [SwaggerSchema("Mensaje de validación o error.")]
        public string Errors { get; set; }
    }
}
