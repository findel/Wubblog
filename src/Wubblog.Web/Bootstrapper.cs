
using System;
using Nancy;
using Nancy.Conventions;

namespace Netring.Website
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		
//		byte[] _favIcon;
//
//		protected override byte[] DefaultFavIcon
//		{
//			get
//			{
//				if (_favIcon == null)
//				{
//					//TODO: remember to replace 'AssemblyName' with the prefix of the resource
//					using (var stream = GetType().Assembly.GetManifestResourceStream("Netring.Website.favicon.ico"))
//					{
//						var favIcon = new byte[stream.Length];
//						stream.Read(favIcon, 0, (int)stream.Length);
//						_favIcon = favIcon;
//					}
//				}
//				return _favIcon;
//			}
//		}
		
		protected override void ConfigureConventions(NancyConventions conventions)
		{
			base.ConfigureConventions(conventions);
			
			// Add `Scripts` directory to the list for Static Content.
			conventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("scripts")
			);
		}
	}
}
