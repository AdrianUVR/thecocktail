using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace thecocktails.Controllers
{
    public class TheCocktailController : Controller
    {
        public ActionResult Drinks()
        {
            Models.TheCocktail thecocktail = new Models.TheCocktail();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
                var resdponsetask = client.GetAsync("search.php?s=");
                resdponsetask.Wait();
                var result = resdponsetask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                    readTask.Wait();
                    thecocktail.TheCocktails = new List<object>();
                    foreach (var resultitem in resultJSON.drinks)
                    {
                        Models.TheCocktail cocktailitem = new Models.TheCocktail();
                        cocktailitem.idDrink = resultitem.idDrink;
                        cocktailitem.Instrucciones = resultitem.strInstructionsDE;
                        cocktailitem.Nombre = resultitem.strDrink;
                        cocktailitem.Imagen = resultitem.strDrinkThumb;
                        thecocktail.TheCocktails.Add(cocktailitem);
                    }

                }

            }
            return View(thecocktail);
        }
        [HttpPost]
        public ActionResult Drinks(Models.TheCocktail thecocktail)
        {
         
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
                var resdponsetask = client.GetAsync("search.php?s="+ thecocktail.busqueda);
                resdponsetask.Wait();
                var result = resdponsetask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                    readTask.Wait();
                    thecocktail.TheCocktails = new List<object>();
                    foreach (var resultitem in resultJSON.drinks)
                    {
                        Models.TheCocktail cocktailitem = new Models.TheCocktail();
                        cocktailitem.idDrink = resultitem.idDrink;
                        cocktailitem.Instrucciones = resultitem.strInstructionsDE;
                        cocktailitem.Nombre = resultitem.strDrink;
                        cocktailitem.Imagen = resultitem.strDrinkThumb;
                        thecocktail.TheCocktails.Add(cocktailitem);
                    }

                }

            }
            return View(thecocktail);
        }
    }
}
