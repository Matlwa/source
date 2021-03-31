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
    public class RightsBAL
    {
        public static List<RightsModel> tblRightGetAll()
        {
            SqlDataReader dr = RightsDAL.tblRightGetAll();
            return FuneralHelper.DataReaderMapToList<RightsModel>(dr).ToList();
        }
        public static int SavetblRight(RightsModel model)
        {
            return RightsDAL.SavetblRight(model);
        }
        public static RightsModel SelecttblRightById(int ID)
        {
            SqlDataReader dr = RightsDAL.SelecttblRightById(ID);
            return FuneralHelper.DataReaderMapToList<RightsModel>(dr).FirstOrDefault();
        }
        public static List<NewRightsModel> GetRightsByGroupId(Guid ParlourId, int GroupId)
        {
            SqlDataReader dr = RightsDAL.GetRightsByGroupId(ParlourId, GroupId);
            return FuneralHelper.DataReaderMapToList<NewRightsModel>(dr).ToList();
        }
        public static List<tblPageModel> GetAllActiveTblPages()
        {
            SqlDataReader dr = RightsDAL.GetAllActiveTblPages();
            return FuneralHelper.DataReaderMapToList<tblPageModel>(dr).ToList();
        }
        public static int SaveTblRights(NewRightsModel model)
        {
            return RightsDAL.SaveTblRights(model);
        }
        public static List<tblPageModel> LoadSideMenu(Guid ParlourId, int UserId)
        {
            SqlDataReader dr = RightsDAL.LoadSideMenu(ParlourId, UserId);
            return FuneralHelper.DataReaderMapToList<tblPageModel>(dr).ToList();
        }
    }
}
