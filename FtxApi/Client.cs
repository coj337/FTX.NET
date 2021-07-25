namespace FtxApi
{
    public class Client
    {
        public string Subaccount { get; }
        public string ApiKey { get; }
        public string ApiSecret { get; }

        public Client()
        {
            ApiKey = "";
            ApiSecret = "";
            Subaccount = "";
        }

        public Client(string apiKey, string apiSecret, string subaccount)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            Subaccount = subaccount;
        }
    }
}