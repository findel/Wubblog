using System;
using System.Collections.Generic;
using Wubblog.Library;

namespace Wubblog.Web.Models
{
	public class IndexViewModel
	{
		public IndexViewModel(){}
		
		public IList<Entry> Entries { get; set; }
	}
}
