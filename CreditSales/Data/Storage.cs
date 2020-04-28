using System.IO;
using CreditSales.Data.Models;

namespace CreditSales.Data
{
    public static class Storage
    {
        public static User CurrentUser { get; set; }

        public static string ConnectionString
        {
            get
            {
                try
                {
                    return File.ReadAllLines("Data\\DBConnect.txt")[0];
                }
                catch
                {
                    return "Data Source=Data\\CreditSales.sdf";//default
                }
            }
        }
        public static Product SelectedProduct { get; set; }
        public static Schedule CreatedSchedulePayment { get; set; }

        public static string AgreementTemplateFile = "Data\\AgreementTemplate.rtf";
        public static string ScheduleTemplateFile = "Data\\ScheduleTemplate.rtf";
        public static string PaymentsTemplateFile = "Data\\PaymentTemplate.rtf";
    }
}