using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fleqx.Data.DatabaseModels
{
	public class Announcement
	{
		// The announcement ID (PK).
		public int AnnouncementID { get; set; }

		// The announcement title.
		[DataType(DataType.Text)]
		public string AnnouncementTitle { get; set; }

		// The announcement content.
		[DataType(DataType.MultilineText)]
		public string AnnouncementContent { get; set; }

		// The announcement importance.
		public int AnnouncementImportance { get; set; }

		// The user that posted the announcement.
		public User User { get; set; }
	}
}