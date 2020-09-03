using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class CarModel
    {
        public AccountModel accountModel { get; set; } = new AccountModel();
        public ApplicantModel applicantModel { get; set; } = new ApplicantModel();
        public DocumentModel documentModel { get; set; } = new DocumentModel();
        public GurantorModel gurantorModel { get; set; } = new GurantorModel();
        public List<LoanModel> loanModel { get; set; } = new List<LoanModel>();
    }
}
