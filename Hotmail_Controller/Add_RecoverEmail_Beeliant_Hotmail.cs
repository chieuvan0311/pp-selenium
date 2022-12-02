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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PAYPAL.Hotmail_Controller
{
    public class Add_RecoverEmail_Beeliant_Hotmail
    {
        public Session_Result_Model Add (Account Acc, UndectedChromeDriver receive_driver)
        {
            Session_Result_Model result = new Session_Result_Model();
            UndectedChromeDriver driver = receive_driver;
            result.Status = false;
            try
            {
                driver.Url = "https://account.live.com/proofs/Add?";
                driver.Navigate();
                Thread.Sleep(RdTimes.T_2000());

                IWebElement check_confirm_pass = null;
                Thread.Sleep(RdTimes.T_700());
                try
                {
                    check_confirm_pass = (IWebElement)driver.FindElement(By.Id("i0118"));
                }
                catch (Exception) { }
                //

                if(check_confirm_pass != null) 
                {
                    check_confirm_pass.SendKeys(Acc.EmailPassword);
                    var signIn_BTN = driver.FindElement(By.Id("idSIButton9"));
                    Thread.Sleep(RdTimes.T_400());
                    signIn_BTN.Click();

                    Thread.Sleep(RdTimes.T_1000());
                    IWebElement confirm_EmailBox = null;
                    Thread.Sleep(RdTimes.T_700());
                    try
                    {
                        confirm_EmailBox = (IWebElement)driver.FindElement(By.Id("EmailAddress"));
                    }
                    catch (Exception) { }

                    if (confirm_EmailBox != null)
                    {
                        var recoveryEmail_box = driver.FindElement(By.Id("EmailAddress"));
                        Thread.Sleep(RdTimes.T_200());
                        var recoveryEmail = Acc.Email.Split('@')[0] + "@beeliant.com";


                        recoveryEmail_box.SendKeys(recoveryEmail);
                        Thread.Sleep(RdTimes.T_300());

                        var btn_next = driver.FindElement(By.Id("iNext"));
                        Thread.Sleep(RdTimes.T_500());
                        btn_next.Click();
                        Thread.Sleep(RdTimes.T_1000());
                        driver.Manage().Window.Minimize();

                        var result_code = new Get_Code_From_Beeliant().Get_Code(recoveryEmail);
                        if (result_code.Status == true)
                        {
                            driver.Manage().Window.Maximize();
                            Thread.Sleep(RdTimes.T_1000());
                            var codeBox = driver.FindElement(By.Id("iOttText"));
                            var codeBeeliant = result_code.Value_01;
                            codeBox.SendKeys(codeBeeliant);
  
                            var code_nextBTN = driver.FindElement(By.Id("iNext"));
                            code_nextBTN.Click();

                            PaypalDbContext db = new PaypalDbContext();
                            var account = db.Accounts.Where(x => x.ID == Acc.ID).FirstOrDefault();
                            account.RecoveryEmail = recoveryEmail;
                            account.Set_Add_RecoveryEmail = true;
                            db.SaveChanges();
                            result.Value_01 = recoveryEmail;
                            result.Status = true;
                        }
                    }
                }
                else 
                {
                    IWebElement confirm_EmailBox = null;
                    try
                    {
                        confirm_EmailBox = (IWebElement)driver.FindElement(By.Id("EmailAddress"));
                    }
                    catch (Exception) { }

                    if (confirm_EmailBox != null)
                    {
                        var recoveryEmail_box = driver.FindElement(By.Id("EmailAddress"));
                        Thread.Sleep(RdTimes.T_200());
                        var recoveryEmail = Acc.Email.Split('@')[0] + "@beeliant.com";


                        recoveryEmail_box.SendKeys(recoveryEmail);
                        Thread.Sleep(RdTimes.T_300());

                        var btn_next = driver.FindElement(By.Id("iNext"));
                        Thread.Sleep(RdTimes.T_500());
                        btn_next.Click();
                        Thread.Sleep(RdTimes.T_1000());
                        driver.Manage().Window.Minimize();


                        var result_code = new Get_Code_From_Beeliant().Get_Code(recoveryEmail);
                        if (result_code.Status == true)
                        {
                            driver.Manage().Window.Maximize();
                            Thread.Sleep(RdTimes.T_1000());
                            var codeBox = driver.FindElement(By.Id("iOttText"));
                            var codeBeeliant = result_code.Value_01;
                            codeBox.SendKeys(codeBeeliant);

                            var code_nextBTN = driver.FindElement(By.Id("iNext"));
                            code_nextBTN.Click();

                            PaypalDbContext db = new PaypalDbContext();
                            var account = db.Accounts.Where(x => x.ID == Acc.ID).FirstOrDefault();
                            account.RecoveryEmail = recoveryEmail;
                            account.Set_Add_RecoveryEmail = true;
                            db.SaveChanges();
                            result.Value_01 = recoveryEmail;
                            result.Status = true;
                        }
                    }
                } 
            }
            catch { }

            result.Driver = driver;
            return result;
        }
    }
}
