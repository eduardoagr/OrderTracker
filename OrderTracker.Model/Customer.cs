using System.ComponentModel.DataAnnotations;

namespace OrderTracker.Model {
    public class Customer {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        // these are called data annotations. they are a means of providing quick 
        // validation.  Look at the MS docs and see all the annotations you can use
        // on your model properties
        // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
        // Here you can see we are requiring a zip code and we are using regex to ensure it fits a certain format
        [Required(ErrorMessage = "Zip is Required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZIP { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}