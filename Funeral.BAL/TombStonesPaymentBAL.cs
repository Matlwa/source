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
    public class TombStonesPaymentBAL
    {
        public static TombStonesPaymentModel TombStonesPaymentSelect(Guid parlourid, int invoiceId)
        {
            SqlDataReader dr = TombStonesPaymentDAL.TombStonesPaymentSelect(parlourid, invoiceId);
            return FuneralHelper.DataReaderMapToList<TombStonesPaymentModel>(dr).FirstOrDefault();
        }

        public static List<TombStonesPaymentModel> TombStonesPaymentSelectByTombstoneID(Guid parlourid, int tombstoneId)
        {
            SqlDataReader dr = TombStonesPaymentDAL.TombStonesPaymentSelectByTombstoneID(parlourid, tombstoneId);
            return FuneralHelper.DataReaderMapToList<TombStonesPaymentModel>(dr);
        }

        public static int AddInvoice(TombStonesPaymentModel model)
        {
            return TombStonesPaymentDAL.AddTombStonesPayment(model);
        }
    }
}
