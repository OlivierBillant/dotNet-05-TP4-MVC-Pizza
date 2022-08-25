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
        public string IngredientsDisplay => string.Join(", ", this.Ingredients.Select(i => i.Nom));
        public PizzaViewModel(int id, string nom, PateViewModel pate, List<IngredientViewModel> ingredients)
        {
            Id = id;
            Nom = nom;
            Pate = pate;
            Ingredients = ingredients;
        }

        public PizzaViewModel()
        {
        }

        public static PizzaViewModel FromPizza(Pizza pizza)
        {
            return new Models.PizzaViewModel()
            {
                Id = pizza.Id,
                Nom = pizza.Nom,
                Pate = PateViewModel.FromPate(pizza.Pate),
                Ingredients = pizza.Ingredients
                    .Select(IngredientViewModel.FromIngredient)
                    .ToList()
            };
        }
        public static Pizza ToPizza(PizzaViewModel pizzaViewModel)
        {
            return new Pizza()
            {
                Id = pizzaViewModel.Id,
                Nom = pizzaViewModel.Nom,
                Pate = PateViewModel.ToPate(pizzaViewModel.Pate),
                Ingredients = pizzaViewModel.Ingredients
                    .Select(IngredientViewModel.ToIngredient)
                    .ToList()
            };
        }

    }
}
