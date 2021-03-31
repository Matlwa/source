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
    public class FuneralPackageBAL
    {
        public static List<PackageServicesSelectionModel> SelectPackageService(Guid ParlourId, string PackageName)
        {
            SqlDataReader dr = FuneralPackageDAL.SelectPackageService(ParlourId, PackageName);
            return FuneralHelper.DataReaderMapToList<PackageServicesSelectionModel>(dr);
        }

        public static List<PackageServiceModel> SelectPackage(Guid ParlourId)
        {
            SqlDataReader dr = FuneralPackageDAL.SelectPackage(ParlourId);
            return FuneralHelper.DataReaderMapToList<PackageServiceModel>(dr);
        }

        public static int SavePackage(PackageServiceModel model)
        {
            return FuneralPackageDAL.SavePackage(model);
        }

        public static int SavePackageService(PackageServiceModel model)
        {
            return FuneralPackageDAL.SavePackageService(model);
        }

        public static void DeletePackageService(int Id)
        {
             FuneralPackageDAL.DeletePackageService(Id);
        }

        public static List<PackageServicesSelectionModel> SelectPackageServiceByPackgeId(Guid ParlourId, int PackgeId)
        {
            SqlDataReader dr = FuneralPackageDAL.SelectPackageServiceByPackgeId(ParlourId, PackgeId);
            return FuneralHelper.DataReaderMapToList<PackageServicesSelectionModel>(dr);
        }

        public static void DeletePackage(int Id, Guid parlourId)
        {
            FuneralPackageDAL.DeletePackage(Id, parlourId);
        }
    }
}
