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
    public class FuneralPackageDAL
    {
        private FuneralPackageDAL() { }

        public static SqlDataReader SelectPackageService(Guid ParlourId, string PackageName)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@PackageName", DbParameter.DbType.VarChar, 0, PackageName);
            ObjParam[1] = new DbParameter("@ParlourId", DbParameter.DbType.UniqueIdentifier, 0, ParlourId);
            return (DbConnection.GetDataReader(CommandType.StoredProcedure, "PackageServicesSelectionByPackage", ObjParam));
        }

        public static SqlDataReader SelectPackageServiceByPackgeId(Guid ParlourId, int PackgeId)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@fkiPackageId", DbParameter.DbType.VarChar, 0, PackgeId);
            ObjParam[1] = new DbParameter("@ParlourId", DbParameter.DbType.UniqueIdentifier, 0, ParlourId);
            return (DbConnection.GetDataReader(CommandType.StoredProcedure, "PackageServicesSelectByPackgeId", ObjParam));
        }

        public static SqlDataReader SelectPackage(Guid ParlourId)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@parlourid", DbParameter.DbType.UniqueIdentifier, 0, ParlourId);
            return (DbConnection.GetDataReader(CommandType.StoredProcedure, "PackagesSelectAllByParlourId", ObjParam));
        }

        public static int SavePackage(PackageServiceModel model)
        {
            DbParameter[] ObjParam = new DbParameter[3];
            ObjParam[0] = new DbParameter("@ParlourId", DbParameter.DbType.UniqueIdentifier, 0, model.ParlourId);
            ObjParam[1] = new DbParameter("@PackageName", DbParameter.DbType.VarChar, 0, model.PackageName);
            ObjParam[2] = new DbParameter("@ModifiedUser", DbParameter.DbType.VarChar, 0, model.ModifiedUser);
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, "PackagesSave", ObjParam));
        }

        public static int SavePackageService(PackageServiceModel model)
        {
            DbParameter[] ObjParam = new DbParameter[4];
            ObjParam[0] = new DbParameter("@fkiServiceID", DbParameter.DbType.Int, 0, model.fkiServiceID);
            ObjParam[1] = new DbParameter("@PackageName", DbParameter.DbType.VarChar, 0, model.PackageName);
            ObjParam[2] = new DbParameter("@ModifiedUser", DbParameter.DbType.VarChar, 0, model.ModifiedUser);
            ObjParam[3] = new DbParameter("@fkiPackageID", DbParameter.DbType.Int, 0, model.fkiPackageID);

            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.Text, "INSERT INTO [dbo].[PackageServicesSelection] ([packagename],[fkiServiceID],[LastModified],[ModifiedUser],[fkiPackageID]) Values(@packagename,@fkiServiceID,getdate(),@ModifiedUser,@fkiPackageID) Select SCOPE_IDENTITY() AS ID", ObjParam));
        }

        public static void DeletePackageService(int Id)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@pkiPackageID", DbParameter.DbType.Int, 0, Id);
            
            DbConnection.ExecuteNonQuery(CommandType.Text, "DELETE FROM [dbo].[PackageServicesSelection] WHERE pkiPackageID=@pkiPackageID", ObjParam);
        }

        public static void DeletePackage(int Id, Guid parlourId)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@parlourid", DbParameter.DbType.UniqueIdentifier, 0, parlourId);
            ObjParam[1] = new DbParameter("@PackageId", DbParameter.DbType.Int, 0, Id);

            DbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "PackagesDelete", ObjParam);
        }
    }
}
