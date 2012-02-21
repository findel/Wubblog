using System;

namespace Wubblog.Library
{
	public class Comment
	{
		#region Constructors
		
		public Comment() {}
		
		#endregion
		
		#region Properties
		
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Email { get; set; } // For Gravatar.
		
		public string Website { get; set; } // Link to this.
		
		public string Markdown { get; set; }
		
		public string Html
		{
			get
			{
				return this.Markdown; // Do something with this. Using MarkdownSharp.
			}
		}
		
		public DateTime CreatedDate { get; set; }
		
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
