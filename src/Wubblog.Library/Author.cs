using System;

namespace Wubblog.Library
{
	public class Author
	{
		#region Constructors
		
		public Author() {}
		
		#endregion
		
		#region Properties
		
		public int Id { get; set; }
		
		public string UserName { get; set; }
		
		public string DisplayName { get; set; }
		
		// public string Password { get; set; }
		
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
