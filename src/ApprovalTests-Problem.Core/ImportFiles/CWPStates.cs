using CsvHelper.Configuration;

namespace ApprovalTestsExcel.Core.ImportFiles
{
    public class CWPStates
    {
        public int Equipment { get; set; }
        public string ObjectType { get; set; }
        public string CWPType { get; set; }

        public override string ToString()
        {
            return $"{Equipment}, Object Type: {ObjectType}, CWP Type: {CWPType}";
        }
    }

    public sealed class CWPStatesMap : ClassMap<CWPStates>
    {
        public CWPStatesMap()
        {
            Map(m => m.Equipment).Name("Objekt");
            Map(m => m.ObjectType).Name("Objekttyp");
            Map(m => m.CWPType).Name("CWP: Typ");
        }
    }
}