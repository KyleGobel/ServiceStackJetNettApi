namespace Api.JetNett.ServiceStackApi.Facts.Setup
{
    public static class TestConfig
    {
        public static string ConnectionString
        {
            get
            {
                return @"Data Source=(localdb)\Projects;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            }
        }

        public static string DevHostBaseUrl
        {
            get
            {
                return "http://localhost:" + TestServicePort + "/";
            }
        }

        public static int TestServicePort { get { return 16009; }}
    }
}