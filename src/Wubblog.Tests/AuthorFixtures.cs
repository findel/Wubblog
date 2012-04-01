
using System;
using NUnit.Framework;
using Wubblog.Library;

namespace Wubblog.Tests
{
	[TestFixture]
	public class AuthorFixtures
	{
		[Test]
		public void CreateAuthor()
		{
			var author = new Author("joe", "test1234");
			author.DisplayName = "Joe Bloggs";
			author.Save();
			
			var saved = Author.FindById(author.AuthorId);
			
			Assert.IsNotNull(saved, "Author just saved should not be null");
			Assert.AreEqual(author.AuthorId, saved.AuthorId, "Author ID not saved correctly");
			Assert.AreEqual(author.UserName, saved.UserName, "UserName not saved correctly");
			Assert.AreEqual(author.DisplayName, saved.DisplayName, "DisplayName not saved correctly");
			Assert.AreEqual(author.PasswordHash, saved.PasswordHash, "PasswordHash not saved correctly");
		}
		[Test]
		public void ValidateCorrectPassword()
		{
			var author = new Author("joe", "test1234");
			var passwordHash = author.PasswordHash;
			
			Assert.IsTrue(author.ValidatePassword("test1234"), "Author.ValidatePassword() does not pass a correct password.");
		}
		
		[Test]
		public void ValidateIncorrectPassword()
		{
			var author = new Author("joe", "test1234");
			var passwordHash = author.PasswordHash;
			
			Assert.IsFalse(author.ValidatePassword("test4567"), "Author.ValidatePassword() does not fail an incorrect password");
		}
	}
}
