using CsvHelper.Configuration;

namespace ApprovalTestsExcel.Core.ImportFiles
{
    public class SieSalesOpttInstallationRep
    {
        public string SalesStatus { get; set; }
        public int Equipment { get; set; }
        public string SalesForceId { get; set; }
    }

    public sealed class SieSalesOpttInstallationRepMap : ClassMap<SieSalesOpttInstallationRep>
    {
        public SieSalesOpttInstallationRepMap()
        {
            Map(m => m.SalesStatus).Name("Sales Status");
            Map(m => m.Equipment).Name("Installation: Installation Number");
            Map(m => m.SalesForceId).Name("Salesforce ID 18");
        }
            
    }
}