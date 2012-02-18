// User: phil | Date: 15/02/2012 | Time: 14:40
using System;
using System.Web.Mvc;

namespace Wubblog.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Contact()
		{
			return View();
		}
	}
}
