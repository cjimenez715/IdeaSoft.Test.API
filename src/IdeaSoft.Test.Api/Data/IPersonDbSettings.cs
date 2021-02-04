namespace IdeaSoft.Test.Api.Data
{
    public interface IPersonDbSettings
    {
        public string PersonCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
