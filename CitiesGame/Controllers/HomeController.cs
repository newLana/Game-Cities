using CitiesGame.Models;
using System.Web.Mvc;

namespace CitiesGame.Controllers
{
    public class HomeController : Controller
    {        
        [HttpGet]
        public ActionResult Index()
        {
            GameViewModel viewModel = new GameViewModel
            {
                Items = Game.Items
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(GameViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Game.AddItem(new GameItem
                {
                    Author = viewModel.Author,
                    City = viewModel.City

                });
            }
            viewModel.Items = Game.Items;
            return View(viewModel);
        }
    }
}