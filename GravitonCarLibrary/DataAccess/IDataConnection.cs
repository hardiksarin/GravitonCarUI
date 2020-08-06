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

        //Account
        AccountModel CreateAccount(AccountModel model);
        void UpdateAccount(AccountModel model);
        List<AccountModel> GetAccounts_All();
        //Account

        //Acquaintance
        List<AcquaintanceModel> GetAcquaintance_All();
        AcquaintanceModel CreateAcquaintance(AcquaintanceModel model);
        void UpdateAcquaintance(AcquaintanceModel model);


        //Acquaintance


        //Applicant
        List<ApplicantModel> GetApplicant_All();
        void UpdateApplicant(ApplicantModel model);
        ApplicantModel CreateApplicant(ApplicantModel model);
        //Applicant

        //Caste
        List<CasteModel> GetCaste_All();
        void UpdateCaste(CasteModel model);
        CasteModel CreateCaste(CasteModel model);

        //Caste

        //Category
        List<CategoryModel> GetCategory_All();
        void UpdateCategory(CategoryModel model);
        CategoryModel CreateCategory(CategoryModel model);


        //Category

        //Documents

        List<DocumentModel> GetDocument_All();
        void UpdateDocument(DocumentModel model);
        DocumentModel CreateDocument(DocumentModel model);

        //Documents

        //DocumentsType

        List<DocumentTypeModel> GetDocumentType_All();
        void UpdateDocumentType(DocumentTypeModel model);
        DocumentTypeModel CreateDocumentType(DocumentTypeModel model);



        //DocumentsType

        //Gurantor
        List<GurantorModel> GetGurantor_All();
        void UpdateGurantor(GurantorModel model);
        GurantorModel CreateGurantor(GurantorModel model);




        //Gurantor

        //GurantorType

        List<GurantorTypeModel> GetGurantorType_All();
        void UpdateGurantorType(GurantorTypeModel model);
        GurantorTypeModel CreateGurantorType(GurantorTypeModel model);




        //GurantorType

        //Loan


        List<LoanModel> GetLoan_All();
        void UpdateLoan(LoanModel model);
        LoanModel CreateLoan(LoanModel model);


        //Loan

        //LoanType

        List<LoanTypeModel> GetLoanType_All();
        void UpdateLoanType(LoanTypeModel model);
        LoanTypeModel CreateLoanType(LoanTypeModel model);

        //LoanType
        //Maried Status

        List<MarriedStatusModel> GetMarried_All();

        void UpdateMarriedStatus(MarriedStatusModel model);
        MarriedStatusModel CreateMarriedStatusModel(MarriedStatusModel model);



        //Maried Status

        //Progress

        List<ProgressModel> GetProgress_All();
        void UpdateProgress(ProgressModel model);
        ProgressModel CreateProgress(ProgressModel model);


        //Progress



    }
}
