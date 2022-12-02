using PAYPAL.Controller;
using PAYPAL.DataConnection;
using PAYPAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYPAL.Dao
{
    public class Set_New_Accounts_Dao
    {
        PaypalDbContext db = null;
        public Set_New_Accounts_Dao()
        {
            db = new PaypalDbContext();
        }

        public void Update_Balance_Notifications_Status_Name_Adress_DateTime (int id, string balance, string note, string acctype, string name, string address, string datetime)
        {
            var acc = db.Accounts.Where(x => x.ID == id).FirstOrDefault();
            if (!string.IsNullOrEmpty(balance)) { acc.Balance = balance; }
            if (!string.IsNullOrEmpty(note)) { acc.Notification = note; }
            if (!string.IsNullOrEmpty(acctype)) { acc.AccType = acctype; }
            if (!string.IsNullOrEmpty(name)) { acc.AccName = name; }
            if (!string.IsNullOrEmpty(address)) { acc.Address = address; }
            if (!string.IsNullOrEmpty(datetime)) { acc.UpdatedDateTime = datetime; }
            db.SaveChanges();           
        }
        public void Past_Paypal_Password_Save (ID_String_Model md) 
        {
            var account = db.Accounts.Where(x => x.ID == md.ID).FirstOrDefault();
            account.AccPassword_Old = account.AccPassword;
            account.AccPassword = md.Str_Value;
            db.SaveChanges();
        }
        public void Past_Paypal_2FA_Save(ID_String_Model md)
        {
            var account = db.Accounts.Where(x => x.ID == md.ID).FirstOrDefault();
            account.Acc_2FA_Old = account.TwoFA;
            account.TwoFA = md.Str_Value;
            db.SaveChanges();
        }
        public void Past_Email_Password_Save(ID_String_Model md)
        {
            var account = db.Accounts.Where(x => x.ID == md.ID).FirstOrDefault();
            account.EmailPassword_Old = account.EmailPassword;
            account.EmailPassword = md.Str_Value;
            db.SaveChanges();
        }
        public void Past_ForwardEmail(ID_String_Model md)
        {
            var account = db.Accounts.Where(x => x.ID == md.ID).FirstOrDefault();
            account.ForwordToEmail = md.Str_Value;
            db.SaveChanges();
        }
    }
}
