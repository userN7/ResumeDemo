using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pluritechDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace pluritechDemo.Controllers
{
	//[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		readonly IWebHostEnvironment appEnvironment;
		readonly string appDataPath;
		
		public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
		{
			_logger = logger;
			this.appEnvironment = appEnvironment;
			appDataPath = appEnvironment.WebRootPath + "\\App_Data";
		}
		
		public IActionResult GetDateFromServer(int isServerTime, int yearSelector, int monthSelector, int daySelector)
		{
			ViewData["App_Data_Path"] = appDataPath;
			if (isServerTime==1)
			{
				return PartialView("DateSelector", DateTime.Now);
			}
			else
			{
				var currDate = new DateTime(yearSelector, monthSelector, daySelector);				
				return PartialView("DateSelector", currDate);
			}

		}	
		
		[Authorize]
		public IActionResult Index()
		{
			ViewData["App_Data_Path"] = appDataPath;
			return View(DateTime.Now);
		}

		[Authorize]
		public FileResult Download(string fileName)
		{
			byte[] fileBytes = System.IO.File.ReadAllBytes(appDataPath + "\\" + fileName);			
			return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
		}
		
				

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		
	}
}
