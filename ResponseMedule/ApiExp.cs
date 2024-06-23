namespace ApiDemoo.ResponseMedule
{
    public class ApiExp:ApiResponses
    {
        public string Details { get; set; }
        public ApiExp(int statuscode,string message=null,string details=null):base(statuscode,message)
        {
            Details = details;
        }
    }
}
