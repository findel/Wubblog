using System;
using System.Collections.Generic;
using Wubblog.Library;

namespace Wubblog.Web.Models
{
	public class EntriesViewModel
	{
		public EntriesViewModel(){}
		
		public IList<Entry> Entries { get; set; }
	}
}
