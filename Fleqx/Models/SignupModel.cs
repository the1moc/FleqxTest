using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fleqx.Models
{
	public class SignupModel
	{
		// The username field.
		[Required]
		[DataType(DataType.Text)]
		public string UserName { get; set; }

		// The password field.
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string LastName { get; set; }

		[Required]
		public int Role { get; set; } 
	}
}