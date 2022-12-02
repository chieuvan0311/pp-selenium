using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
    public class Add_ForwardEmail_Hotmail
    {
        public Session_Result_Model Add (Account Acc, UndectedChromeDriver receive_driver, bool hold_on = false)
        {
            Session_Result_Model result = new Session_Result_Model();
            UndectedChromeDriver driver = receive_driver;
            driver.Manage().Window.Maximize();
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
                    driver.Url = "https://outlook.live.com/mail/0/";
                    driver.Navigate();
                    Thread.Sleep(RdTimes.T_2000());
                }
                Thread.Sleep(RdTimes.T_6000());
                driver.Url = "https://outlook.live.com/mail/0/options/mail/rules";
                driver.Navigate();
                Thread.Sleep(RdTimes.T_10000());

                var addRulesButton = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[2]/div[1]/div[1]//button"));
                Thread.Sleep(RdTimes.T_400());
                addRulesButton.Click();
                var rule_name_Box = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@class='ms-TextField-wrapper']//input"));
                Thread.Sleep(RdTimes.T_600());
                string first_word = new Upper_First_Letter_Words_96().Get_96_First_Words_List()[new Random().Next(0, 95)];
                string number_01 = new Random().Next(0, 99).ToString();
                string number_02 = new Random().Next(0, 99).ToString();
                string ruleName = first_word + number_01 + number_02;
                Thread.Sleep(RdTimes.T_400());
                rule_name_Box.SendKeys(ruleName);
                var iconClick = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]"));
                Thread.Sleep(RdTimes.T_200());
                iconClick.Click();
                Thread.Sleep(RdTimes.T_700());

                var condition_Dropdown_BTN = driver.FindElements(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[2]/div[1]/div[1]//div[@role='combobox']"))[0];
                Thread.Sleep(RdTimes.T_400());
                condition_Dropdown_BTN.Click();

                Thread.Sleep(RdTimes.T_1000());
                var subjectBTN = driver.FindElements(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='group']//button[@data-index='11']"))[0];
                Thread.Sleep(RdTimes.T_500());
                subjectBTN.Click();
                Thread.Sleep(RdTimes.T_700());
                var subjectBox = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/input[1]"));
                Thread.Sleep(RdTimes.T_400());
                string keyword = "paypal";
                for (int ke = 0; ke < keyword.Length; ke++)
                {
                    subjectBox.SendKeys(keyword[ke].ToString());
                    Thread.Sleep(RdTimes.T_5_13());
                }
                Thread.Sleep(RdTimes.T_300());

                var iconClick_02 = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]"));
                iconClick_02.Click();
                Thread.Sleep(RdTimes.T_300());
                var action_DropdownBTN = driver.FindElements(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[2]/div[1]/div[1]//div[@role='combobox']"))[1];
                Thread.Sleep(RdTimes.T_500());
                action_DropdownBTN.Click();
                Thread.Sleep(RdTimes.T_300());



                var forwardTo_BTN = driver.FindElements(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='group']//button[@data-index='11']"));
                Thread.Sleep(RdTimes.T_500());
                forwardTo_BTN[0].Click();
                Thread.Sleep(RdTimes.T_500());
                var forward_Box = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[2]/div[1]/div[1]//div[@role='textbox']"));
                Thread.Sleep(RdTimes.T_600());
                forward_Box.Click();
                Thread.Sleep(RdTimes.T_500());
                Clipboard.SetText(Acc.ForwordToEmail.ToString());
                new Actions(driver).KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control).Perform();
                Thread.Sleep(RdTimes.T_1000());
                var save_BTN = driver.FindElement(By.XPath("//div[@id='fluent-default-layer-host']//div[@role='tabpanel']/div[3]/button[1]"));
                Thread.Sleep(RdTimes.T_1500());
                var check_saveBTN = save_BTN.GetAttribute("data-is-focusable");              
                if (check_saveBTN == "true")
                {
                    save_BTN.Click();
                    Thread.Sleep(RdTimes.T_1500());
                    //Update database
                    PaypalDbContext db = new PaypalDbContext();
                    var db_account = db.Accounts.Where(x => x.ID == Acc.ID).FirstOrDefault();
                    db_account.Set_Add_New_FwEmail = true;
                    db.SaveChanges();
                    //return
                    result.Status = true; 
                }          
            }
            catch { }

            result.Driver = driver;
            return result;
        }
    }
}
