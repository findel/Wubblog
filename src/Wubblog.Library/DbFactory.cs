
using System;
using Simple.Data;

namespace Wubblog.Library
{
	public static class DbFactory
	{
		
		#region Fields
		
		private static dynamic _Db = NewDb();
		
		#endregion
		
		#region Properties
		
		public static dynamic Db { get{ return _Db; } }
		
		#endregion
		
		#region Methods
		
		private static dynamic NewDb()
		{
			// TODO Put connection string into web.config
			return Database.OpenConnection("server=localhost;port=3307;database=wubbleyew;uid=root;pwd=");
		}
		
		#endregion
		
	}
}
