namespace ApiDemoo.ResponseMedule
{
    public class ApiResponses
    {
        public ApiResponses(int statuscode,string message=null)
        {
            StatusCode = statuscode;
            Message = GetDefaultMessageForStatusCode(statuscode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "You Are Not Authorized",
                404 => "Resource Not Found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
