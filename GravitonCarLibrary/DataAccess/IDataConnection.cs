using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.DataAccess
{
    public interface IDataConnection
    {
        //Applicant
        ApplicantModel CreateApplicant(ApplicantModel model);

        //Marrital Status

        List<MarriedStatusModel> GetMarried_All();
        List<AcquaintanceModel> GetAcquaintance_All();
        List<CasteModel> GetCaste_All();
        List<CategoryModel> GetCategory_All();



    }
}
