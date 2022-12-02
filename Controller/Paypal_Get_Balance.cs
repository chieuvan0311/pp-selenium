using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PAYPAL.ChromeDrivers;
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

namespace PAYPAL.Controller
{
    public class Paypal_Get_Balance
    {
        public Session_Result_Model Get(Account Acc, UndectedChromeDriver receive_driver)
        {
            Session_Result_Model result = new Session_Result_Model();
            UndectedChromeDriver driver = receive_driver;
            result.Status = false;
            try
            {
                Thread.Sleep(RdTimes.T_500());
                //Lấy số dư
                var balance = driver.FindElement(By.XPath("//div[@id='cwBalance']//div[@data-test-id='available-balance']")).Text;
                Thread.Sleep(RdTimes.T_1500());
                string dTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                new AccountDao().Update_Balance(Acc.ID, balance, dTime);
                result.Status = true;
            }
            catch { }

            result.Driver = driver;
            return result;
        }
    }
}
