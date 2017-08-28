using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dionysus.Models;
using System.Diagnostics;

namespace Dionysus.Controllers
{
    public class AuctionItemsController : Controller
    {
        // GET: AuctionItems
        public ActionResult Index()
        {
            List<AuctionItem> activeAuctionItems = AresAPIClient.AresWebAPIClient.FetchActiveAuctionItems().Result;
            return View(activeAuctionItems);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

    }
}