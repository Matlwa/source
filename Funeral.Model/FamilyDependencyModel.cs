using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
  public  class FamilyDependencyModel
    {
        public FamilyDependencyModel()
        {
            FullName = string.Empty;
            Surname = string.Empty;
            IDNumber = string.Empty;
            pkiDependentID = 0;
            DependencyType = string.Empty;
            //parlourid = new Guid("00000000-0000-0000-0000-000000000000");
            Age = 0;
            MemberId = 0;
            RelationshipType = string.Empty;
            Gender = string.Empty;
        }

        //public string DTCode
        //{
        //    get;
        //    set;
        //}
        public string Cellphone { get; set; }

        public int Age
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public string Surname
        {
            get;
            set;
        }
        public string IDNumber
        {
            get;
            set;
        }
        public int pkiDependentID
        {
            get;
            set;
        }
        public string DependencyType
        {
            get;
            set;
        }
        public Guid parlourid
        {
            get;
            set;
        }
        public int MemberId
        {
            get;
            set;
        }
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public int Relationship
        {
            get;
            set;
        }
        public string RelationshipType
        {
            get;
            set;
        }
        public DateTime InceptionDate
        {
            get;
            set;
        }
        public DateTime CoverDate
        {
            get;
            set;
        }
        public decimal Premium
        {
            get;
            set;
        }

        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Cover { get; set; }
    }

}
