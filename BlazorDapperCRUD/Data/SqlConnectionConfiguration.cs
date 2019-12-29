namespace BlazorDapperCRUD.Data
{
    // Connection to SQL Server database, used within Data subfolder.
    public class SqlConnectionConfiguration
    {
        public SqlConnectionConfiguration(string value) => Value = value;
        public string Value { get; }
    }

}
