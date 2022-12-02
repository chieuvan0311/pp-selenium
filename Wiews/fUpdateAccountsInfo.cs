using PAYPAL.Controller;
using PAYPAL.DataConnection;
using PAYPAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PAYPAL.Wiews
{
    public partial class fUpdateAccountsInfo : Form
    {
        PaypalDbContext db = null;
        public fUpdateAccountsInfo()
        {
            InitializeComponent();
            this.CenterToScreen();
            db = new PaypalDbContext();
            grvUpdate_Account_Info.DataSource = new List<Update_Accounts_Info_Model>();
            grvUpdate_Account_Info.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grvUpdate_Account_Info.Columns[0].Width = 50;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grvUpdate_Account_Info.DataSource = new List<Update_Accounts_Info_Model>();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            grvUpdate_Account_Info.DataSource = Update_Accounts_Info_GoogleSheet();
        }

        public List<Update_Accounts_Info_Model> Update_Accounts_Info_GoogleSheet()
        {
            var google_sheet = new Google_Sheet_Controller().Get_Update_Info_Accounts_List();
            List<Update_Accounts_Info_Model> list_table_acc = new List<Update_Accounts_Info_Model>();
            if (google_sheet.Count > 0)
            {
                List<Account> data_accounts_list = db.Accounts.ToList();
                int stt = 1;
                for (int i = 0; i < google_sheet.Count; i++)
                {
                    //check trùng với Acc cũ
                    Update_Accounts_Info_Model table_acc = new Update_Accounts_Info_Model();
                    Account add_database_acc = new Account();

                    string check_email = "";
                    try { check_email = google_sheet[i][0].ToString(); } catch { }

                    if (string.IsNullOrEmpty(check_email)) { continue; }

                    if (data_accounts_list.Count > 0)
                    {
                        string accPassword = "";
                        string twoFA = "";
                        string emailPassword = "";
                        string email_2FA = "";
                        string recoveryEmail = "";
                        string forwordToEmail = "";
                        string proxy = "";
                        string accType = "";
                        string set_ChangedPassPP = "";
                        string set_ChangedPassEmail = "";
                        string set_Add_RecoveryEmail = "";
                        string set_Deleted_FwEmail = "";
                        string set_Add_New_FwEmail = "";

                        bool checking = false;
                        foreach (var old_account in data_accounts_list)
                        {
                            if (google_sheet[i][0].ToString() == old_account.Email)
                            {
                                checking = true;
                                break;
                            }
                        }

                        if(checking == true)
                        {
                            var data_account = db.Accounts.Where(x => x.Email == check_email).FirstOrDefault();

                            try { accPassword = google_sheet[i][1].ToString(); } catch { }
                            try { twoFA = google_sheet[i][2].ToString(); } catch { }
                            try { emailPassword = google_sheet[i][3].ToString(); } catch { }
                            try { email_2FA = google_sheet[i][4].ToString(); } catch { }
                            try { recoveryEmail = google_sheet[i][5].ToString(); } catch { }
                            try { forwordToEmail = google_sheet[i][6].ToString(); } catch { }
                            try { proxy = google_sheet[i][7].ToString(); } catch { }
                            try { accType = google_sheet[i][8].ToString(); } catch { }
                            try { set_ChangedPassPP = google_sheet[i][9].ToString(); } catch { }
                            try { set_ChangedPassEmail = google_sheet[i][10].ToString(); } catch { }
                            try { set_Add_RecoveryEmail = google_sheet[i][11].ToString(); } catch { }
                            try { set_Deleted_FwEmail = google_sheet[i][12].ToString(); } catch { }
                            try { set_Add_New_FwEmail = google_sheet[i][13].ToString(); } catch { }

                            if (!string.IsNullOrEmpty(accPassword)) { data_account.AccPassword = accPassword; }
                            if (!string.IsNullOrEmpty(twoFA)) { data_account.TwoFA = twoFA; }
                            if (!string.IsNullOrEmpty(emailPassword)) { data_account.EmailPassword = emailPassword; }
                            if (!string.IsNullOrEmpty(email_2FA)) { data_account.Email_2FA = email_2FA; }
                            if (!string.IsNullOrEmpty(recoveryEmail)) { data_account.RecoveryEmail = recoveryEmail; }
                            if (!string.IsNullOrEmpty(forwordToEmail)) { data_account.ForwordToEmail = forwordToEmail; }
                            if (!string.IsNullOrEmpty(proxy)) { data_account.Proxy = proxy; }
                            if (!string.IsNullOrEmpty(accType)) { data_account.AccType = accType; }

                            if (!string.IsNullOrEmpty(set_ChangedPassPP))
                            {
                                if (set_ChangedPassPP == "YES") { data_account.Set_ChangedPassPP = false; } else { data_account.Set_ChangedPassPP = true; }
                            }

                            if (!string.IsNullOrEmpty(set_ChangedPassEmail))
                            {
                                if (set_ChangedPassEmail == "YES") { data_account.Set_ChangedPassEmail = false; } else { data_account.Set_ChangedPassEmail = true; }
                            }

                            if (!string.IsNullOrEmpty(set_Add_RecoveryEmail))
                            {
                                if (set_Add_RecoveryEmail == "YES") { data_account.Set_Add_RecoveryEmail = false; } else { data_account.Set_Add_RecoveryEmail = true; }
                            }

                            if (!string.IsNullOrEmpty(set_Deleted_FwEmail))
                            {
                                if (set_Deleted_FwEmail == "YES") { data_account.Set_Deleted_FwEmail = false; } else { data_account.Set_Deleted_FwEmail = true; }
                            }

                            if (!string.IsNullOrEmpty(set_Add_New_FwEmail))
                            {
                                if (set_Add_New_FwEmail == "YES") { data_account.Set_Add_New_FwEmail = false; } else { data_account.Set_Add_New_FwEmail = true; }
                            }

                            db.SaveChanges();


                            // Cập nhật table
                            table_acc.STT = stt;
                            table_acc.Email = google_sheet[i][0].ToString();
                            try { table_acc.AccPassword = google_sheet[i][1].ToString(); } catch { }
                            try { table_acc.TwoFA = google_sheet[i][2].ToString(); } catch { }
                            try { table_acc.EmailPassword = google_sheet[i][3].ToString(); } catch { }
                            try { table_acc.Email_2FA = google_sheet[i][4].ToString(); } catch { }
                            try { table_acc.RecoveryEmail = google_sheet[i][5].ToString(); } catch { }
                            try { table_acc.ForwordToEmail = google_sheet[i][6].ToString(); } catch { }
                            try { table_acc.Proxy = google_sheet[i][7].ToString(); } catch { }
                            try { table_acc.AccType = google_sheet[i][8].ToString(); } catch { }
                            try { table_acc.Set_ChangedPassPP = google_sheet[i][9].ToString(); } catch { }
                            try { table_acc.Set_ChangedPassEmail = google_sheet[i][10].ToString(); } catch { }
                            try { table_acc.Set_Add_RecoveryEmail = google_sheet[i][11].ToString(); } catch { }
                            try { table_acc.Set_Deleted_FwEmail = google_sheet[i][12].ToString(); } catch { }
                            try { table_acc.Set_Add_New_FwEmail = google_sheet[i][13].ToString(); } catch { }

                            table_acc.Status = "Đã cập nhật";
                            list_table_acc.Add(table_acc);

                            stt = stt + 1;
                        }

                        if (checking == false)
                        {
                            table_acc.STT = stt;
                            table_acc.Email = google_sheet[i][0].ToString();
                            try { table_acc.AccPassword = google_sheet[i][1].ToString(); } catch { }
                            try { table_acc.TwoFA = google_sheet[i][2].ToString(); } catch { }
                            try { table_acc.EmailPassword = google_sheet[i][3].ToString(); } catch { }
                            try { table_acc.Email_2FA = google_sheet[i][4].ToString(); } catch { }
                            try { table_acc.RecoveryEmail = google_sheet[i][5].ToString(); } catch { }
                            try { table_acc.ForwordToEmail = google_sheet[i][6].ToString(); } catch { }
                            try { table_acc.Proxy = google_sheet[i][7].ToString(); } catch { }
                            try { table_acc.AccType = google_sheet[i][8].ToString(); } catch { }
                            try { table_acc.Set_ChangedPassPP = google_sheet[i][9].ToString(); } catch { }
                            try { table_acc.Set_ChangedPassEmail = google_sheet[i][10].ToString(); } catch { }
                            try { table_acc.Set_Add_RecoveryEmail = google_sheet[i][11].ToString(); } catch { }
                            try { table_acc.Set_Deleted_FwEmail = google_sheet[i][12].ToString(); } catch { }
                            try { table_acc.Set_Add_New_FwEmail = google_sheet[i][13].ToString(); } catch { }
                            table_acc.Status = "Email sai hoặc chưa nhập Tool";
                            list_table_acc.Add(table_acc);

                            stt = stt + 1;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Goole sheet không có dữ liệu", "Thông báo");
            }

            return list_table_acc;
        }     
    }
}
