using System;

namespace Wubblog.Library
{
	public class Author
	{
		#region Constructors
		
		public Author() {}
		
		public Author(string userName, string password)
		{
			this.UserName = userName;
			this.PasswordHash = PasswordHasher.CreateHash(password);
		}
		
		#endregion
		
		#region Properties
		
		public int AuthorId { get; set; }
		
		public string UserName { get; private set; }
		
		public string DisplayName { get; set; }
		
		public string PasswordHash { get; private set; }
		
		#endregion
		
		#region Methods
		
		public bool ValidatePassword(string password)
		{
			return PasswordHasher.ValidateHash(password, this.PasswordHash);
		}
		
		public void ResetPassword(string password)
		{
			this.PasswordHash = PasswordHasher.CreateHash(password);
		}
		
		public void Save()
		{
			if(this.AuthorId == 0)
			{
				Author saved = DbFactory.Db.Authors.Insert(this);
				this.AuthorId = saved.AuthorId;
			}
			else
				DbFactory.Db.Authors.Update(this);
		}
		
		public void Delete()
		{
			DbFactory.Db.Authors.Delete(this);
		}
		
		#endregion
		
		#region Static
		
		public static Author FindById(int id)
		{
			return DbFactory.Db.Authors.FindByAuthorId(id);
		}
		
		#endregion
	}
}
