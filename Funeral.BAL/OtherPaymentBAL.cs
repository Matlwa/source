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
    public class OtherPaymentBAL
    {
        public static int OtherPaymentDetailsSave(OtherPaymentModel model)
        {
            return OtherPaymentDAl.OthePaymentDetailsSave(model);
        }

        public static List<OtherPaymentModel> OtherPaymentSelectByMemberId(int MemberId, Guid Parlourid)
        {
            SqlDataReader dr = OtherPaymentDAl.OtherPaymentSelectByMemberId(MemberId, Parlourid);
            return FuneralHelper.DataReaderMapToList<OtherPaymentModel>(dr).ToList();
        }

        public static OtherPaymentModel OtherPaymentSelect(int InvoiceId, Guid Parlourid)
        {
            SqlDataReader dr = OtherPaymentDAl.OtherPaymentSelect(InvoiceId, Parlourid);
            return FuneralHelper.DataReaderMapToList<OtherPaymentModel>(dr)[0];
        }
       
       
    }
}
