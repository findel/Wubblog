
using System;
using NUnit.Framework;
using Wubblog.Library;

namespace Wubblog.Tests
{
	[TestFixture]
	public class AuthorFixtures
	{
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
