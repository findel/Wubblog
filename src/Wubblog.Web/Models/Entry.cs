/*
 * Created by SharpDevelop.
 * User: Phil 'Findel' Baines
 * Date: 20/02/2012
 * Time: 23:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace Wubblog.Web.Models
{
	/// <summary>
	/// Description of Entry.
	/// </summary>
	public class Entry
	{
		public Entry(){}
		
		[Key]
		public int Id { get; set; }
		
		public DateTime Created { get; set; }
		public string Title { get; set; }
		public string Markdown { get; set; }
		public string Tags { get; set; }
		
	}
}
