using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class MembersModel
    {
        public MembersModel()
        {

            CreateDate = System.DateTime.Now;
            MemberType = string.Empty;
            Title = string.Empty;
            FullNames = string.Empty;
            Surname = string.Empty;
            Gender = string.Empty;
            IDNumber = string.Empty;
            DateOfBirth = System.DateTime.Now;
            Telephone = string.Empty;
            Cellphone = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            Address3 = string.Empty;
            Address4 = string.Empty;
            PostAddress1 = string.Empty;
            PostAddress2 = string.Empty;
            PostAddress3 = string.Empty;
            PostCode = string.Empty;
            Code = string.Empty;
            MemeberNumber = string.Empty;
            MemberSociety = string.Empty;
            fkiPlanID = 1;
            Active = true;
            InceptionDate = System.DateTime.Now;
            Claimnumber = string.Empty;
            PolicyStatus = string.Empty;
            //   parlourid =Convert.tou string.Empty;
            Agent = string.Empty;
            AccountHolder = string.Empty;
            Bank = string.Empty;
            BranchCode = string.Empty;
            Branch = string.Empty;
            AccountNumber = string.Empty;
            AccountType = string.Empty;
            DebitDate = System.DateTime.Now;
            MemberBranch = string.Empty;
            CoverDate = System.DateTime.Now;
            LastModified = System.DateTime.Now;
            ModifiedUser = string.Empty;
            Email = string.Empty;
            Passport = string.Empty;
            Citizenship = string.Empty;
            EasyPayNo = string.Empty;
            pkiAdditionalMemberInfo = new Guid("00000000-0000-0000-0000-000000000000");
            StartDate = System.DateTime.Now;
            IsUploaded = false;
            TotalVehicle = 0;
           
        }
        public int pkiMemberID { get; set; }
        public DateTime CreateDate { get; set; }
        public string MemberType { get; set; }
        public string Title { get; set; }
        public string FullNames { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Code { get; set; }
        public string PostAddress1 { get; set; }
        public string PostAddress2 { get; set; }
        public string PostAddress3 { get; set; }
        public string PostAddress4 { get; set; }
        public string PostCode { get; set; }
        public string MemeberNumber { get; set; }
        public string MemberSociety { get; set; }
        public int fkiPlanID { get; set; }
        public bool Active { get; set; }
        public DateTime InceptionDate { get; set; }
        public string Claimnumber { get; set; }
        public string PolicyStatus { get; set; }
        public Guid parlourid { get; set; }
        public string Agent { get; set; }
        public string AccountHolder { get; set; }
        public string Bank { get; set; }
        public string BranchCode { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public DateTime DebitDate { get; set; }
        public string MemberBranch { get; set; }
        public DateTime? CoverDate { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }
        public string Email { get; set; }
        public string Citizenship { get; set; }
        public string Passport { get; set; }
        public string EasyPayNo { get; set; }
        public Guid pkiAdditionalMemberInfo { get; set; }
        public DateTime StartDate { get; set; }
        public int CustomId1 { get; set; }
        public int CustomId2 { get; set; }
        public int CustomId3 { get; set; }

        public bool IsUploaded { get; set; }

        public int  TotalVehicle { get;set;}
        public decimal Premium { get; set; }
    }
}
