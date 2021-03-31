using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeral.Model;
using System.Data.SqlClient;
using System.Data;
using Funeral.DAL;

namespace Funeral.BAL
{
    public class TombStoneBAL
    {
        public TombStoneBAL()
        { 
        }
        public static List<TombStoneModel> SelectAllTombStoneByParlourId(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = TombStoneDAL.SelectAllTombStoneByParlourId(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<TombStoneModel>(dr);
        }
        public static int TombStoneDelete(int ID, string UserName)
        {
            return TombStoneDAL.TombStoneDelete(ID, UserName);
        }
        public static int SaveTombStone(TombStoneModel model)
        {
            return TombStoneDAL.SaveTombStone(model);
        }
        public static TombStoneModel SelectTombStoneByParlAndPki(int pkiTombstoneID, Guid ParlourId)
        {
            SqlDataReader dr = TombStoneDAL.SelectTombStoneByParlAndPki(pkiTombstoneID, ParlourId);
            return FuneralHelper.DataReaderMapToList<TombStoneModel>(dr).FirstOrDefault();
        }
        public static int UploadTombImage(string ImageName, string ImagePath, int pkiTombstoneID, Guid parlourid)
        {
            return TombStoneDAL.UploadTombImage(ImageName, ImagePath, pkiTombstoneID, parlourid);
        }
        public static TombStoneModel GetInvoiceNumOfTombByParlID(Guid ParlourId) 
        {
            SqlDataReader dr = TombStoneDAL.GetInvoiceNumOfTombByParlID(ParlourId);
            return FuneralHelper.DataReaderMapToList<TombStoneModel>(dr).FirstOrDefault();
        }
        public static List<TombStoneServiceSelectModel> SelectServiceByTombStoneID(int fkiTombstoneID)
        {
            SqlDataReader dr = TombStoneDAL.SelectServiceByTombStoneID(fkiTombstoneID);
            return FuneralHelper.DataReaderMapToList<TombStoneServiceSelectModel>(dr);
        }
        public static int DeleteTombstoneServiceByID(int pkiTombStoneSelectionID)
        {
            return TombStoneDAL.DeleteTombstoneServiceByID(pkiTombStoneSelectionID);
        }
        public static TombStoneServiceSelectModel SelectServiceByTombAndID(int fkiTombstoneID, int pkiTombStoneSelectionID)
        {
            SqlDataReader dr = TombStoneDAL.SelectServiceByTombAndID(fkiTombstoneID, pkiTombStoneSelectionID);
            return FuneralHelper.DataReaderMapToList<TombStoneServiceSelectModel>(dr).FirstOrDefault();
        }
        public static int SaveTombStoneService(TombStoneServiceSelectModel model)
        {
            return TombStoneDAL.SaveTombStoneService(model);
        }
        public static int UpdateAllTombStoneData(int pkiTombstoneID, Decimal DisCount, Decimal Tax, string InvoiceNumber)
        {
            return TombStoneDAL.UpdateAllTombStoneData(pkiTombstoneID, DisCount, Tax, InvoiceNumber);
        }

    }
}
