using DotNet._05.TP4.Pizza.business.Models;

namespace DotNet._05.TP4.Pizza.Web.Models
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public static IngredientViewModel FromIngredient(Ingredient ingredient)
        {
            return new Models.IngredientViewModel()
            {
                Id = ingredient.Id,
                Nom = ingredient.Nom
            };
        }

    }
}