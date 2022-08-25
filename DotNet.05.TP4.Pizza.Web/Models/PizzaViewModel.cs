using DotNet._05.TP4.Pizza.business.Models;

namespace DotNet._05.TP4.Pizza.Web.Models
{
    using Pizza = DotNet._05.TP4.Pizza.business.Models.Pizza;

    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public PateViewModel Pate { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();

        public static PizzaViewModel FromPizza(Pizza pizza)
        {
            return new Models.PizzaViewModel()
            {
                Id = pizza.Id,
                Nom = pizza.Nom,
                Pate = PateViewModel.FromPate(pizza.Pate),
                Ingredients = pizza.Ingredients
                //On passe ici la directement la méthode Fromingredient qui a une signature de lambda au select
                    .Select(IngredientViewModel.FromIngredient)
                    //.Select(ingredient => IngredientViewModel.FromIngredient(ingredient))
                    .ToList()
            };
        }
    }
}
