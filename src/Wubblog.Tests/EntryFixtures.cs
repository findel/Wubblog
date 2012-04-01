using System;
using NUnit.Framework;
using Wubblog.Library;

namespace Wubblog.Tests
{
	[TestFixture]
	public class EntryFixtures
	{
		[Test]
		public void CreateEntry()
		{
			var entry = new Entry();
			entry.Title = "My Test Entry";
			entry.Description = 
				"This is a test entry that has been created using the `Wubblog.Tests` project. " +
				"A more meaningful explanation can be found in the markdown property.";
			entry.Markdown = 
				"## Ok, I lied ##\r\n\r\n" +
				"It's really not a more meaningful explanation at all, except that this " +
				"field inlcudes a bit more markdown code.\r\n\r\n" + 
				"Which allows us to include `code` inline, and code blocks:\r\n\r\n" + 
				"    var something = \"something else\";" + 
				"And many other things like: \r\n\r\n" + 
				"* Bullet points (see)\r\n" + 
				"* Different level headings\r\n" + 
				"* And so on... (OK, I gave up a bit early there)\r\n";
			entry.Active = true;
			entry.Keywords = "test, entry, with markdown, probably broken";
			entry.Reference = "my-test-entry";
			entry.Save();
		}
	}
}
