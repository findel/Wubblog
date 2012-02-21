using System;

namespace Wubblog.Library
{
	/// <summary>
	/// Description of Entry.
	/// </summary>
	public class Entry
	{
		#region Constructors
		
		public Entry() {}
		
		#endregion
		
		#region Properties
		
		public int Id { get; set; }
		
		public string Title { get; set; }
		
		public string Markdown { get; set; }
		
		public string Html
		{ 
			get
			{
				return this.Markdown; // Do something to this. Using MarkdownSharp.
			}
		}
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime PublishDate { get; set; }
		
		#endregion
		
		#region Methods
		
		public void Save()
		{
			throw new NotImplementedException();
		}
		
		public void Delete()
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
	}
}
