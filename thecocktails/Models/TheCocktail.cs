namespace thecocktails.Models
{
    public class TheCocktail
    {

        public int idDrink { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public string strAlcoholic { get; set; }

        public string Instrucciones { get; set; }


        public string Ingredientes { get; set; }

        public string Imagen { get; set; }

        public string busqueda { get; set; }


        public List<object> TheCocktails { get; set; }
    }
}
