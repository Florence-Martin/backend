namespace Api_gestion_bibliotheque.Configurations
{
    public class MongoDbSettings
    {
        public string ConnectionURI { get; set; } 
        public string DatabaseName { get; set; } 
        public string BooksCollectionName { get; set; } 
        public string AuthorsCollectionName { get; set; } 
        public string BorrowersCollectionName { get; set; } 
        public string LoanTransactionCollectionName { get; set; } 
        public string LoanReturnCollectionName { get; set; } 
    }
}
