using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.DAL
{
    public sealed class FuneralDAL
    {
        private FuneralDAL() { }

        public static SqlDataReader SelectAllFuneralByParlourId(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            DbParameter[] ObjParam = new DbParameter[6];
            ObjParam[0] = new DbParameter("@pagesize", DbParameter.DbType.Int, 0, PageSize);
            ObjParam[1] = new DbParameter("@pagenum", DbParameter.DbType.Int, 0, PageNum);
            ObjParam[2] = new DbParameter("@Keyword", DbParameter.DbType.NVarChar, 0, Keyword);
            ObjParam[3] = new DbParameter("@field", DbParameter.DbType.NVarChar, 0, SortBy);
            ObjParam[4] = new DbParameter("@orderby", DbParameter.DbType.NVarChar, 0, SortOrder);
            ObjParam[5] = new DbParameter("@ParlourId", DbParameter.DbType.UniqueIdentifier, 0, ParlourId);
            return (DbConnection.GetDataReader(CommandType.StoredProcedure, "SelectAllFuneralByParlourId", ObjParam));
        }
        public static int FuneralDelete(int ID, string UserName)
        {
            string query = "update Funerals set IsDeleted = 1, DeletedDate=@DateTime, DeletedBy=@UserName where pkiFuneralID=@pkiFuneralID";
            DbParameter[] ObjParam = new DbParameter[3];
            ObjParam[0] = new DbParameter("@pkiFuneralID", DbParameter.DbType.Int, 0, ID);
            ObjParam[1] = new DbParameter("@UserName", DbParameter.DbType.NVarChar, 0, UserName);
            ObjParam[2] = new DbParameter("@DateTime", DbParameter.DbType.DateTime, 0, System.DateTime.Now);
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.Text, query, ObjParam));
        }
        public static int SaveFuneral(FuneralModel model)
        {
            string query = "SaveFuneral";
            DbParameter[] ObjParam = new DbParameter[24];

            ObjParam[0] = new DbParameter("@pkiFuneralID", DbParameter.DbType.Int, 0, model.pkiFuneralID);
            ObjParam[1] = new DbParameter("@FullNames", DbParameter.DbType.NVarChar, 0, model.FullNames);
            ObjParam[2] = new DbParameter("@Surname", DbParameter.DbType.NVarChar, 0, model.Surname);
            ObjParam[3] = new DbParameter("@Gender", DbParameter.DbType.NVarChar, 0, model.Gender);
            ObjParam[4] = new DbParameter("@IDNumber", DbParameter.DbType.NVarChar, 0, model.IDNumber);
            ObjParam[5] = new DbParameter("@DateOfBirth", DbParameter.DbType.DateTime, 0, model.DateOfBirth);
            ObjParam[6] = new DbParameter("@DateOfDeath", DbParameter.DbType.DateTime, 0, model.DateOfDeath);
            ObjParam[7] = new DbParameter("@DateOfFuneral", DbParameter.DbType.DateTime, 0, model.DateOfFuneral);
            ObjParam[8] = new DbParameter("@TimeOfFuneral", DbParameter.DbType.DateTime, 0, model.TimeOfFuneral);
            ObjParam[9] = new DbParameter("@FuneralCemetery", DbParameter.DbType.NVarChar, 0, model.FuneralCemetery);
            ObjParam[10] = new DbParameter("@Address1", DbParameter.DbType.NVarChar, 0,model.Address1);
            ObjParam[11] = new DbParameter("@Address2", DbParameter.DbType.NVarChar, 0, model.Address2);
            ObjParam[12] = new DbParameter("@Address3", DbParameter.DbType.NVarChar, 0, model.Address3);
            ObjParam[13] = new DbParameter("@Code", DbParameter.DbType.NVarChar, 0, model.Code);
            ObjParam[14] = new DbParameter("@BodyCollectedFrom", DbParameter.DbType.NVarChar, 0, model.BodyCollectedFrom);
            ObjParam[15] = new DbParameter("@CourseOfDearth", DbParameter.DbType.NVarChar, 0, model.CourseOfDearth);
            ObjParam[16] = new DbParameter("@BI1663", DbParameter.DbType.NVarChar, 0, model.BI1663);
            ObjParam[17] = new DbParameter("@DriverAndCars", DbParameter.DbType.NVarChar, 0, model.DriverAndCars);
            ObjParam[18] = new DbParameter("@GraveNo", DbParameter.DbType.NVarChar, 0, model.GraveNo);
            ObjParam[19] = new DbParameter("@parlourid", DbParameter.DbType.UniqueIdentifier, 0, model.parlourid);
            ObjParam[20] = new DbParameter("@LastModified", DbParameter.DbType.DateTime, 0, model.LastModified);
            ObjParam[21] = new DbParameter("@ModifiedUser", DbParameter.DbType.NVarChar, 0, model.ModifiedUser);

            ObjParam[22] = new DbParameter("@ContactPerson", DbParameter.DbType.NVarChar, 0, model.ContactPerson);
            ObjParam[23] = new DbParameter("@ContactPersonNumber", DbParameter.DbType.NVarChar, 0, model.ContactPersonNumber);
           // ObjParam[22] = new DbParameter("@InvoiceNumber", DbParameter.DbType.NVarChar, 0, model.InvoiceNumber);


            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
        }
        public static SqlDataReader SelectFuneralBypkid(int ID, Guid ParlourId)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@pkiFuneralID", DbParameter.DbType.Int, 0, ID);
            ObjParam[1] = new DbParameter("@parlourid", DbParameter.DbType.UniqueIdentifier, 0, ParlourId);

            return DbConnection.GetDataReader(CommandType.StoredProcedure, "SelectFuneralBypkid", ObjParam);
        }
        public static int SaveFuneralService(FuneralServiceSelectModel model)
        {
            string query = "SaveFuneralService";
            DbParameter[] ObjParam = new DbParameter[7];

            ObjParam[0] = new DbParameter("@fkiFuneralID", DbParameter.DbType.Int, 0, model.fkiFuneralID);
            ObjParam[1] = new DbParameter("@fkiServiceID", DbParameter.DbType.Int, 0, model.fkiServiceID);
            ObjParam[2] = new DbParameter("@Quantity", DbParameter.DbType.Int, 0, model.Quantity);
            ObjParam[3] = new DbParameter("@LastModified", DbParameter.DbType.DateTime, 0, model.lastModified);
            ObjParam[4] = new DbParameter("@ModifiedUser", DbParameter.DbType.VarChar, 0, model.modifiedUser);
            ObjParam[5] = new DbParameter("@ServiceRate", DbParameter.DbType.Money, 0, model.ServiceRate);
            ObjParam[6] = new DbParameter("@pkiFuneralServiceSelectionID", DbParameter.DbType.Int, 0, model.pkiFuneralServiceSelectionID);

            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
        }
        public static SqlDataReader SelectServiceByFuneralID(int fkiFuneralID)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@fkiFuneralID", DbParameter.DbType.Int, 0, fkiFuneralID);
            return (DbConnection.GetDataReader(CommandType.StoredProcedure, "SelectServiceByFuneralID", ObjParam));
        }
        public static SqlDataReader SelectServiceByFunAndID(int fkiFuneralID, int pkiFuneralServiceSelectionID)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@fkiFuneralID", DbParameter.DbType.Int, 0, fkiFuneralID);
            ObjParam[1] = new DbParameter("@pkiFuneralServiceSelectionID", DbParameter.DbType.Int, 0, pkiFuneralServiceSelectionID);
             	
            return DbConnection.GetDataReader(CommandType.StoredProcedure, "SelectServiceByFunAndID ", ObjParam);
        }
        public static int DeleteFuneralServiceByID(int pkiFuneralServiceSelectionID)
        {
            string query = "Delete from FuneralServicesSelection where  pkiFuneralServiceSelectionID= @pkiFuneralServiceSelectionID";
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@pkiFuneralServiceSelectionID", DbParameter.DbType.Int, 0, pkiFuneralServiceSelectionID);
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.Text, query, ObjParam));
        }
        public static SqlDataReader GetInvoiceNumberByID(Guid ParlourId)
        {
            string query = "select (Max(InvoiceNumber)) as InvoiceNumber2 from Funerals where InvoiceNumber IS not NULL and parlourid=@parlourid";
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@parlourid", DbParameter.DbType.UniqueIdentifier, 0, ParlourId);
            return DbConnection.GetDataReader(CommandType.Text, query, ObjParam);
        }
        public static int UpdateAllFuneralData(int pkiFuneralID, string Notes, Decimal DisCount, Decimal Tax)
        {
            string query = " update Funerals set Notes=@Notes,DisCount=@DisCount,Tax=@Tax where pkiFuneralID=@pkiFuneralID";
            DbParameter[] ObjParam = new DbParameter[4];
            ObjParam[0] = new DbParameter("@pkiFuneralID", DbParameter.DbType.Int, 0, pkiFuneralID);
            ObjParam[1] = new DbParameter("@Notes", DbParameter.DbType.NVarChar, 0, Notes);
            ObjParam[2] = new DbParameter("@DisCount", DbParameter.DbType.Decimal, 0, DisCount);
            ObjParam[3] = new DbParameter("@Tax", DbParameter.DbType.Money, 0, Tax);
           

            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.Text, query, ObjParam));
        }
        public static int SaveFuneralSupportedDocument(FuneralDocumentModel model)
        {
            string query = "SaveFuneralSupportedDocument";
            DbParameter[] ObjParam = new DbParameter[9];

            ObjParam[0] = new DbParameter("@ImageName", DbParameter.DbType.NVarChar, 0, model.ImageName);
            ObjParam[1] = new DbParameter("@ImageFile", DbParameter.DbType.Image, 0, model.ImageFile);
            ObjParam[2] = new DbParameter("@fkiFuneralID", DbParameter.DbType.Int, 0, model.fkiFuneralID);
            ObjParam[3] = new DbParameter("@CreateDate", DbParameter.DbType.DateTime, 0, model.CreateDate);
            ObjParam[4] = new DbParameter("@Parlourid", DbParameter.DbType.UniqueIdentifier, 0, model.Parlourid);
            ObjParam[5] = new DbParameter("@LastModified", DbParameter.DbType.DateTime, 0, model.LastModified);
            ObjParam[6] = new DbParameter("@ModifiedUser", DbParameter.DbType.NVarChar , 0, model.ModifiedUser);
            ObjParam[7] = new DbParameter("@DocContentType", DbParameter.DbType.VarChar, 0, model.DocContentType);
            ObjParam[8] = new DbParameter("@DocType", DbParameter.DbType.Int, 0, model.DocType);

            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
        }
        public static SqlDataReader SelectFuneralDocumentsByMemberId(int fkiFuneralID)
        {
            string query = "SelectFuneralDocumentsByMemberId";
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@fkiFuneralID", DbParameter.DbType.Int, 0, fkiFuneralID);          

            return DbConnection.GetDataReader(CommandType.StoredProcedure,query, ObjParam);
        }
        public static int DeleteFuneraldocumentById(int pkiFuneralPictureID)
        {
            string query = "Delete from FuneralDocuments Where pkiFuneralPictureID=@pkiFuneralPictureID";
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@pkiFuneralPictureID", DbParameter.DbType.Int, 0, pkiFuneralPictureID);
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.Text, query, ObjParam));
            
        }
        public static SqlDataReader SelectFuneralDocumentsByPKId(int DocumentId)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@pkiFuneralPictureID", DbParameter.DbType.Int, 0, DocumentId);
            return (DbConnection.GetDataReader(CommandType.StoredProcedure, "SelectFuneralDocumentsByPKId", ObjParam));
        }
        public static SqlDataReader SelectFuneralByMemberNo(string MemberNo)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@MemberNumber", DbParameter.DbType.VarChar, 100, MemberNo);
            return (DbConnection.GetDataReader(CommandType.StoredProcedure, "SelectFuneralByMemberNo", ObjParam));
        }
    }
}
