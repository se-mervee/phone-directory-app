namespace PersonAPI.Models
{
    public class dbSettings: IPersonSettings
    {
        public string[] PersonCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IPersonSettings
    {
        public string[] PersonCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
