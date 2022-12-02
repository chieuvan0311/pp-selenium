using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PAYPAL.ChromeDrivers;
using PAYPAL.Controller;
using PAYPAL.Dao;
using PAYPAL.DataConnection;
using PAYPAL.Models;
using PAYPAL.RandomData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAYPAL.Hotmail_Controller
{
    public class Remove_ForwardEmail_Hotmail
    {
        public Session_Result_Model Remove (Account Acc, UndectedChromeDriver receive_driver)
        {
            Session_Result_Model result = new Session_Result_Model();
            UndectedChromeDriver driver = receive_driver;
            result.Status = false;
            try 
            {
                driver.Url = "https://outlook.live.com/mail/0/";
                driver.Navigate();
                Thread.Sleep(RdTimes.T_3000());

                IWebElement confirm_new_password_box_check = null;
                Thread.Sleep(RdTimes.T_700());
                try
                {
                    confirm_new_password_box_check = (IWebElement)driver.FindElement(By.Id("i0118"));
                }
                catch (Exception) { }

                if (confirm_new_password_box_check != null)
                {
                    var confirm_new_password_box = driver.FindElement(By.Id("i0118"));
                    for (int newp = 0; newp < Acc.EmailPassword.Length; newp++)
                    {
                        var letter = Acc.EmailPassword[newp].ToString();
                        confirm_new_password_box.SendKeys(letter);
                        Thread.Sleep(RdTimes.T_10_20());
                    }
                    Thread.Sleep(RdTimes.T_300());
                    var confirm_btn_next = driver.FindElement(By.Id("idSIButton9"));
                    Thread.Sleep(RdTimes.T_500());
                    confirm_btn_next.Click();
                    Thread.Sleep(RdTimes.T_2000());
                }
                Thread.Sleep(RdTimes.T_6000());
                driver.Url = "https://outlook.live.com/mail/0/options/mail/rules";
                driver.Navigate();
                Thread.Sleep(RdTimes.T_11000());

                try
                {
                    var check_old_forward_Elements = driver.FindElements(By.XPath("//div[@role='tabpanel']/div[2]/div[1]/div[1]//div[@draggable='true']/div[1]/div[2]/button[4]"));
                    if(check_old_forward_Elements.Count == 0){ result.Status = true; }
                }
                catch
                {
                    result.Status = true;
                }

                if(result.Status == false)
                {
                    try
                    {
                        var delElement = driver.FindElements(By.XPath("//div[@role='tabpanel']/div[2]/div[1]/div[1]//div[@draggable='true']/div[1]/div[2]/button[4]"));
                        int chieu3111 = delElement.Count;
                        for (int de = delElement.Count - 1; de >= 0; de--)
                        {
                            delElement[de].Click();
                            Thread.Sleep(RdTimes.T_1000());
                            var deleteButton = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@data-is-scrollable='true']/div[1]/div[2]/div[2]/div[1]/span[1]/button"));
                            Thread.Sleep(RdTimes.T_1000());
                            deleteButton.Click();
                            Thread.Sleep(RdTimes.T_1500());
                        }

                        try
                        {
                            var check_old_forward_Elements_01 = driver.FindElements(By.XPath("//div[@role='tabpanel']/div[2]/div[1]/div[1]//div[@draggable='true']/div[1]/div[2]/button[4]"));
                            if (check_old_forward_Elements_01.Count == 0) { result.Status = true; }
                        }
                        catch
                        {
                            result.Status = true;
                        }
                    }
                    catch { }
                }
            }
            catch { }

            if(result.Status == true)
            {
                PaypalDbContext db = new PaypalDbContext();
                var db_account = db.Accounts.Where(x => x.ID == Acc.ID).FirstOrDefault();
                db_account.Set_Deleted_FwEmail = true;
                db_account.Set_Add_New_FwEmail = false;
                db.SaveChanges();
            }
            result.Driver = driver;
            return result;
        }
    }
}
