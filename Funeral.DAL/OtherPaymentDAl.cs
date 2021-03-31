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
    /// <summary>
    /// Other Payment Class Details
    /// </summary>
    public class OtherPaymentDAl
    {
        public static int OthePaymentDetailsSave(OtherPaymentModel model)
        {try
        { 
            DbParameter[] ObjParam = new DbParameter[16];
            ObjParam[0] = new DbParameter("@pkiInvoiceID", DbParameter.DbType.Int, 0, model.pkiInvoiceID);
            ObjParam[1] = new DbParameter("@MemberID", DbParameter.DbType.Int, 0, model.MemberID);
            ObjParam[2] = new DbParameter("@DatePaid", DbParameter.DbType.DateTime, 0, model.DatePaid);
            ObjParam[3] = new DbParameter("@AmountPaid", DbParameter.DbType.Money, 0, model.AmountPaid);
            ObjParam[4] = new DbParameter("@RecievedBy", DbParameter.DbType.NVarChar, 0, model.RecievedBy);
            ObjParam[5] = new DbParameter("@PaidBy", DbParameter.DbType.NVarChar, 0, model.PaidBy);
            ObjParam[6] = new DbParameter("@Notes", DbParameter.DbType.NVarChar, 0, model.Notes);
            ObjParam[7] = new DbParameter("@Parlourid", DbParameter.DbType.UniqueIdentifier, 0, model.Parlourid);
            ObjParam[8] = new DbParameter("@PaymentBranch", DbParameter.DbType.VarChar, 0, model.PaymentBranch);
            ObjParam[9] = new DbParameter("@LastModified", DbParameter.DbType.DateTime, 0,DateTime.Now);
            ObjParam[10] = new DbParameter("@ModifiedUser", DbParameter.DbType.VarChar, 0, model.ModifiedUser);            
            ObjParam[11] = new DbParameter("@InvNumber", DbParameter.DbType.Int, 0, model.InvNumber);
            ObjParam[12] = new DbParameter("@DeviceCollectionID", DbParameter.DbType.UniqueIdentifier, 0, model.DeviceCollectionID);
            ObjParam[13] = new DbParameter("@MethodOfPayment", DbParameter.DbType.NVarChar, 0, model.MethodOfPayment);
            ObjParam[14] = new DbParameter("@Discount", DbParameter.DbType.NVarChar, 0, model.Discount);
            ObjParam[15] = new DbParameter("@PaymentTypeId", DbParameter.DbType.NVarChar, 0, model.PaymentTypeId);
            
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, "OtherPaymentDetailsSave", ObjParam));
        }
            catch(Exception ex)
            {
                throw ex;
            
            }
        }
    
        public static SqlDataReader OtherPaymentSelectByMemberId(int MemberId, Guid Parlourid)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@Parlourid", DbParameter.DbType.UniqueIdentifier, 0, Parlourid);
            ObjParam[1] = new DbParameter("@MemberID", DbParameter.DbType.Int, 0, MemberId);            
            return DbConnection.GetDataReader(CommandType.StoredProcedure, "OtherInvoiceSelectByMemberId", ObjParam);
        }

        /// <summary>
        /// Select OtherPayment by id
        /// </summary>
        /// <param name="InvoiceId"></param>
        /// <param name="Parlourid"></param>
        /// <returns></returns>
        public static SqlDataReader OtherPaymentSelect(int InvoiceId, Guid Parlourid)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@Parlourid", DbParameter.DbType.UniqueIdentifier, 0, Parlourid);
            ObjParam[1] = new DbParameter("@InvoiceId", DbParameter.DbType.Int, 0, InvoiceId);
            return DbConnection.GetDataReader(CommandType.StoredProcedure, "OtherInvoiceSelect", ObjParam);
        }
        //public static SqlDataReader OtherPaymentGetBypkInvoiceId(int pkiInvoiceID, Guid Parlourid)
        //{
        //    DbParameter[] ObjParam = new DbParameter[2];
        //    ObjParam[0] = new DbParameter("@Parlourid", DbParameter.DbType.UniqueIdentifier, 0, Parlourid);
        //    ObjParam[1] = new DbParameter("@pkiInvoiceID", DbParameter.DbType.Int, 0, pkiInvoiceID);
        //    return DbConnection.GetDataReader(CommandType.StoredProcedure, "OtherInvoiceSelect", ObjParam);
        //}
        public static SqlDataReader OtherPaymentDetailGetId(int Id)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@Id", DbParameter.DbType.Int, 0, Id);

            return DbConnection.GetDataReader(CommandType.StoredProcedure, "SelectPaymentType", ObjParam);
        }        

    }
}
           

            
           

           
