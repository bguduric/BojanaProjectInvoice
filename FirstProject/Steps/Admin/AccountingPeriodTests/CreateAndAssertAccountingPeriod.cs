using FirstProject.Pages;
using FirstProject.Pages.Admin;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin.AccountingPeriodTests
{
    [Binding]
    class CreateAndAssertAccountingPeriod : BaseSteps
    {
        string month_select = GenerateRandomData.GenerateMonths();
        string month_select2 = GenerateRandomData.GenerateMonths();

        string month_select_rs = GenerateRandomData.GenerateMonthsRS();
        string month_select2_rs = GenerateRandomData.GenerateMonthsRS();

        string year = GenerateRandomData.GenerateRandomYear().ToString();
        string year2 = GenerateRandomData.GenerateRandomYear().ToString();
        string invalid_form = GenerateRandomData.GenerateRandomSpecChar(2);

//Login as admin and navigate on create account period page

        [Given(@"User logs in as admin and navigate on Accouting period create page 2")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");

            Precondition homePage = new Precondition(Driver);
            AccountingPeriods AdminhomePage = new AccountingPeriods(Driver);

            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            AdminhomePage.AccPeriodsButton().Click();
            AdminhomePage.AccPeriodsCreateButton().Click();
            Assert.That(AdminhomePage.IsCreateAccFromListDisplayed(), Is.True, "Create accounting period is not displayed.");
        }

//Admin enters valid values in create accounting period fields and clicks create button. 
//New accounting period should be successfully created and admin should be able to see it in the table.

        [When(@"User enters valid values in create accounting period form 2")]
        public void UserEntersValidValuesInCreateAccountingPeriodForm()
        {
            AccountingPeriods validCreateAcc = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                validCreateAcc.MonthSel().SendKeys(month_select);
                validCreateAcc.CreateClaimIssueData().Clear();
                validCreateAcc.CreateClaimIssueData().SendKeys(validCreateAcc.MonthSel().GetAttribute("value") + "/1/" + year);
                validCreateAcc.CreateClaimPaymentData().Clear();
                validCreateAcc.CreateClaimPaymentData().SendKeys(validCreateAcc.MonthSel().GetAttribute("value") + "/28/" + year);
                validCreateAcc.AccPeriodsCreateYear().Click();
                validCreateAcc.AccPeriodsCreateYear().Clear();
                validCreateAcc.AccPeriodsCreateYear().SendKeys(year);
                //validCreateAcc.ActiveCheckbox().Click();
                validCreateAcc.CreateAccButton().Click();
            }
            else
            {
                validCreateAcc.MonthSel().SendKeys(month_select_rs);
                validCreateAcc.CreateClaimIssueData().Clear();
                validCreateAcc.CreateClaimIssueData().SendKeys("1."+ validCreateAcc.MonthSel().GetAttribute("value") + "." + year + ".");
                validCreateAcc.CreateClaimPaymentData().Clear();
                validCreateAcc.CreateClaimPaymentData().SendKeys("28." + validCreateAcc.MonthSel().GetAttribute("value") + "." + year + ".");
                validCreateAcc.AccPeriodsCreateYear().Click();
                validCreateAcc.AccPeriodsCreateYear().Clear();
                validCreateAcc.AccPeriodsCreateYear().SendKeys(year);
                //validCreateAcc.ActiveCheckbox().Click();
                validCreateAcc.CreateAccButton().Click();
            }

        }

        [Then(@"Accounting period is successfully created")]
        public void AccPeriodIsSuccessfullyCreated()
        {
            AccountingPeriods accPerCreated = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(month_select + " " + year, accPerCreated.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select + " " + year + "')]")).Text);
                InvoiceValidator selectAccPerInvoice = new InvoiceValidator(Driver);
                selectAccPerInvoice.InvoiceButton().Click();
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select + " " + year);
            }
            else
            {
                Assert.AreEqual(month_select_rs + " " + year, accPerCreated.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select_rs + " " + year + "')]")).Text);
                InvoiceValidator selectAccPerInvoice = new InvoiceValidator(Driver);
                selectAccPerInvoice.InvoiceButton().Click();
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select_rs + " " + year);
            }
        }

//Admin navigates on Invoice Validator home page and select accounting period that is created

        [When(@"Admin navigates on Invoice Validator home page")]
        public void AdminNavigatesOnInvoiceValidatorHomePage()
        {
            InvoiceValidator selectAccPerInvoice = new InvoiceValidator(Driver);
            selectAccPerInvoice.InvoiceButton().Click();
        
        }
        [Then(@"Admin should be able to select new accounting period")]
        public void AdminShouldBeAbleToSelectNewAccPeriod()
        {
            InvoiceValidator selectAccPerInvoice = new InvoiceValidator(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select + " " + year);
            }
            else
            {
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select_rs + " " + year);
            }
        }

//Admin logs out, and logs in as a contractor. Contractor select new accounting period from create claims 
//dropdown. If contractor is able to select new period, new accounting period exists.

        [When(@"Admin logs out and logs in as contractor")]
        public void AdminLogsOutAndLogsInAsContractor()
        {
            Precondition homePage = new Precondition(Driver);
            homePage.LogOutAsAdmin().Click();
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
        }
        [Then(@"New accounting period should be in create claim dropdown")]
        public void NewAccPeriodIsInCreateClaimDropdown()
        {
            Claims dropdownCreate = new Claims(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                SelectElement acc_per_created = new SelectElement(dropdownCreate.ConAccPeriod());
                acc_per_created.SelectByText(month_select + " " + year);
                dropdownCreate.LogOutButtonContractor().Click();
            }
            else
            {
                SelectElement acc_per_created = new SelectElement(dropdownCreate.ConAccPeriod());
                acc_per_created.SelectByText(month_select_rs + " " + year);
                dropdownCreate.LogOutButtonContractor().Click();
            }
        }

    }
}
