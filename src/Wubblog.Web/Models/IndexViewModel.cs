using System;
using System.Collections.Generic;
using Wubblog.Library;

namespace Wubblog.Web.Models
{
	public class IndexViewModel
	{
		public IndexViewModel(){}
		
		public List<Entry> Entries { get; set; }
	}
}
