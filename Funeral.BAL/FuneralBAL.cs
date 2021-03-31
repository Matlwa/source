using Funeral.DAL;
using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.BAL
{
    public class FuneralBAL
    {
        public FuneralBAL()
        {
        }

        public static List<FuneralModel> SelectAllFuneralByParlourId(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = FuneralDAL.SelectAllFuneralByParlourId(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<FuneralModel>(dr);
        }
        public static int FuneralDelete(int ID, string UserName)
        {
            return FuneralDAL.FuneralDelete(ID, UserName);
        }

        public static int SaveFuneral(FuneralModel model)
        {
            return FuneralDAL.SaveFuneral(model);
        }
        public static FuneralModel SelectFuneralBypkid(int ID, Guid ParlourId)
        {
            SqlDataReader dr = FuneralDAL.SelectFuneralBypkid(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<FuneralModel>(dr).FirstOrDefault();
        }
        public static FuneralModel SelectFuneralByMemberNo(string MemberNo)
        {
            SqlDataReader dr = FuneralDAL.SelectFuneralByMemberNo(MemberNo);
            return FuneralHelper.DataReaderMapToList<FuneralModel>(dr).FirstOrDefault();
        }
        #region service
        public static int SaveFuneralService(FuneralServiceSelectModel model)
        {
            return FuneralDAL.SaveFuneralService(model);
        }
        public static List<FuneralServiceSelectModel> SelectServiceByFuneralID(int fkiFuneralID)
        {
            SqlDataReader dr = FuneralDAL.SelectServiceByFuneralID(fkiFuneralID);
            return FuneralHelper.DataReaderMapToList<FuneralServiceSelectModel>(dr);
        }
        public static FuneralServiceSelectModel SelectServiceByFunAndID(int fkiFuneralID, int pkiFuneralServiceSelectionID)
        {
            SqlDataReader dr = FuneralDAL.SelectServiceByFunAndID(fkiFuneralID, pkiFuneralServiceSelectionID);
            return FuneralHelper.DataReaderMapToList<FuneralServiceSelectModel>(dr).FirstOrDefault();
        }
        public static int DeleteFuneralServiceByID(int pkiFuneralServiceSelectionID)
        {
            return FuneralDAL.DeleteFuneralServiceByID(pkiFuneralServiceSelectionID);
        }
        public static FuneralModel GetInvoiceNumberByID(Guid ParlourId)
        {
            SqlDataReader dr = FuneralDAL.GetInvoiceNumberByID(ParlourId);
            return FuneralHelper.DataReaderMapToList<FuneralModel>(dr).FirstOrDefault();
        }
        public static int UpdateAllFuneralData(int pkiFuneralID, string Notes, Decimal DisCount, Decimal Tax)
        {
            return FuneralDAL.UpdateAllFuneralData(pkiFuneralID, Notes, DisCount,Tax);
        }
        public static int SaveFuneralSupportedDocument(FuneralDocumentModel model)
        {
            return FuneralDAL.SaveFuneralSupportedDocument(model);
        }
        public static List<FuneralDocumentModel> SelectFuneralDocumentsByMemberId(int fkiFuneralID)
        {
            SqlDataReader dr = FuneralDAL.SelectFuneralDocumentsByMemberId(fkiFuneralID);
            return FuneralHelper.DataReaderMapToList<FuneralDocumentModel>(dr);
        }
        public static int DeleteFuneraldocumentById(int pkiFuneralPictureID)
        {
            return FuneralDAL.DeleteFuneraldocumentById(pkiFuneralPictureID);
        }
        public static FuneralDocumentModel SelectFuneralDocumentsByPKId(int DocumentId)
        {
            return FuneralHelper.DataReaderMapToList<FuneralDocumentModel>(FuneralDAL.SelectFuneralDocumentsByPKId(DocumentId)).FirstOrDefault();
        }
        #endregion
    }
}
