using DotNet._05.TP4.Pizza.business.Models;
using System.ComponentModel.DataAnnotations;

namespace DotNet._05.TP4.Pizza.Web.Models
{
    using Pizza = DotNet._05.TP4.Pizza.business.Models.Pizza;

    public class PizzaFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le nom de la pizza doit comprendre entre 5 et 20 caractères")]
        public string Nom { get; set; }
        [Required]
        public int PateId { get; set; }

        public List<int> IngredientsId { get; set; } = new List<int>();

        public PizzaFormViewModel(int id, string nom, int pateId, List<int> ingredientsId)
        {
            Id = id;
            Nom = nom;
            PateId = pateId;
            IngredientsId = ingredientsId;
        }

        public PizzaFormViewModel()
        {
        }

        public static PizzaFormViewModel FromPizza(Pizza pizza)
        {
            return new Models.PizzaFormViewModel()
            {
                Id = pizza.Id,
                Nom = pizza.Nom,
                PateId = pizza.Pate.Id,
                IngredientsId = pizza.Ingredients
                    .Select(ingredient => ingredient.Id).ToList()
            };
        }
    }
}
