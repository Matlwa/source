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
    public class UnderwriterBAL
    {
        public static List<UnderwriterModel> SelectAllUnderwriterByParlourId(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = UnderwriterDAL.SelectAllUnderwriterByParlourId(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<UnderwriterModel>(dr);
        }
        public static int SaveUnderwriter(UnderwriterModel model)
        {
            return UnderwriterDAL.SaveUnderwriter(model);
        }
        public static UnderwriterModel SelectUnderwriterBypkid(int ID, Guid ParlourId)
        {
            SqlDataReader dr = UnderwriterDAL.SelectUnderwriterBypkid(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<UnderwriterModel>(dr).FirstOrDefault();
        }
        public static int DeleteUnderwriterByID(int PkiUnderwriterId,string UserName)
        {
            return UnderwriterDAL.DeleteUnderwriterByID(PkiUnderwriterId, UserName);
        }
        public static UnderwriterModel SelectUnderwriterByName(string UnderwriterName, Guid ParlourId)
        {
            SqlDataReader dr = UnderwriterDAL.SelectUnderwriterByName(UnderwriterName, ParlourId);
            return FuneralHelper.DataReaderMapToList<UnderwriterModel>(dr).FirstOrDefault();
        }
        public static List<UnderwriterModel> SelectUnderwriterNotDeleted()
        {
            SqlDataReader dr = UnderwriterDAL.SelectUnderwriterNotDeleted();
            return FuneralHelper.DataReaderMapToList<UnderwriterModel>(dr);
        }
    }
}
