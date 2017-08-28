using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dionysus.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Dionysus.Controllers
{
    public class OfferController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SubmitOffer()
        {
            return RedirectToAction("Index","AuctionItems");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AuctionItemID,BuyerName,OfferAmount")] Offer offer)
        {
            string submitResult;
            offer.OfferTime = DateTime.Now;
            string offerJson = JsonConvert.SerializeObject(offer);
            HttpResponseMessage result = await AresAPIClient.AresWebAPIClient.SubmitOffer(offerJson);
            if (result.IsSuccessStatusCode)
            {
                submitResult = "success";
            } else if (result.StatusCode.ToString().Equals("901"))
            {
                submitResult = "auctionExpired";
            } else if (result.StatusCode.ToString().Equals("902"))
            {
                submitResult = "auctionInactive";
            }
            else
            {
                submitResult = "unknownError";
            }


            return RedirectToAction(nameof(OfferSubmitResult), new { id = submitResult });
        }

        public IActionResult OfferSubmitResult(string id)
        {
            string submitResult = "";
            switch (id)
            {
                case "success":
                    submitResult = "Congratulations - Your offer has been successfully submitted.";
                    break;
                case "auctionExpired":
                    submitResult = "Submitting the offer has failed as the auction end date has already passed at the time the offer was submitted.";
                    break;
                case "auctionInactive":
                    submitResult = "Submitting the offer has failed as the auction has been made inactive";
                    break;
                case "unknownError":
                    submitResult = "Unknown Error has occurred while trying to submit your offer - please contact Auction Inc.";
                    break;
                default:
                    submitResult = "";
                    break;
            }
            ViewData["SubmitResult"] = submitResult;
            return View();
        }

    }
}