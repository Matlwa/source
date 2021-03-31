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
    public class CustomDetailsBAL
    {
        public static int CustomDetailsSave(CustomDetails model)
        {
            return CustomDetailsDAL.CustomDetailsSave(model);
        }

        public static void CustomDetailsUpdate(CustomDetails model)
        {
            CustomDetailsDAL.CustomDetailsUpdate(model);

        }

        public static void CustomDetailsDelete(CustomDetails model)
        {
            CustomDetailsDAL.CustomDetailsDelete(model);
        }

        public static CustomDetails GetCustomDetails(int Id, Guid ParlourId, int CustomType)
        {
            SqlDataReader dr = CustomDetailsDAL.GetCustomDetails(Id, ParlourId, CustomType);
            var model = FuneralHelper.DataReaderMapToList<CustomDetails>(dr).FirstOrDefault();
            model.CustomType = (CustomDetailsEnums.CustomDetailsType)CustomType;
            return model;
        }

        public static List<CustomDetails> GetAllCustomDetailsByParlourId(Guid ParlourId, int CustomType)
        {
            SqlDataReader dr = CustomDetailsDAL.GetAllCustomDetailsByParlourId(ParlourId, CustomType);
            List<CustomDetails> model = FuneralHelper.DataReaderMapToList<CustomDetails>(dr);
            foreach (var item in model)
            {
                item.CustomType = (CustomDetailsEnums.CustomDetailsType)CustomType;
            }
            return model;
        }
    }
}
