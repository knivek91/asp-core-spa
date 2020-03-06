using System.Data;

namespace DataLayer
{
    // this could be a Object for then create an Collection of SQLParameter to encapsulate this as a DLL
    // this can help https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1?view=netframework-4.8
    public class SQLParameter
    {

        #region Property
        public string Name { get; set; }
        public object Value { get; set; }
        public ParameterDirection Direction { get; set; }
        #endregion

    }
}