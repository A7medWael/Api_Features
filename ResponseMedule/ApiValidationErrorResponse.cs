namespace ApiDemoo.ResponseMedule
{
    public class ApiValidationErrorResponse:ApiExp
    {
        public ApiValidationErrorResponse():base(400)
        {
            
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
