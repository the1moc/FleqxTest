using System.Collections.Generic;
using System.Web.Mvc;

namespace Fleqx.Data.DatabaseModels
{
	public static class RoleHelper
	{
		public static IEnumerable<SelectListItem> Roles = new List<SelectListItem>
		{
			new SelectListItem
			{
				Value = "1",
				Text = "Admin"
			},
			new SelectListItem
			{
				Value = "2",
				Text = "Standard"
			},
			new SelectListItem
			{
				Value = "3",
				Text = "Guest"
			}
		};

		// Return the correct role.
		public static string GetRole(int roleNumber)
		{
			switch (roleNumber)
			{
				case 1:
					return "Admin";
				case 2:
					return "Standard";
				default:
					return "Guest";
			}
		}
	}
}