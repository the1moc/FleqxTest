using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Fleqx.Helper
{
	public class UserClaims : ClaimsPrincipal
	{
		public UserClaims(ClaimsPrincipal principal)
			: base(principal)
		{
		}

		// Get the name.
		public string Name
		{
			get { return this.FindFirst(ClaimTypes.Name).Value; }
		}
	}
}