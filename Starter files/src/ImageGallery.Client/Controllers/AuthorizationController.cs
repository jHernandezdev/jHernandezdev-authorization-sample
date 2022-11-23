using System;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Client.Controllers
{
	public class AuthorizationController: Controller
	{
		public AuthorizationController()
		{
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}

