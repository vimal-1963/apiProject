namespace Api_Project
{
    public class AWSConfiguration
    {
        public string AccessId { get; set; }    
        public string Password { get; set; }

        public AWSConfiguration(string accessIdArg, string passwordArg)
        {
            AccessId = accessIdArg;
            Password = passwordArg;
        }
    }
}
