using System.ComponentModel.DataAnnotations.Schema;

namespace Cores.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Status { get; set; }
      public string zIPCode { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser appUser { get; set; }
        
    }
}