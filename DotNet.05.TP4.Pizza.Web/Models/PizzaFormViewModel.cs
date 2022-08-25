using DotNet._05.TP4.Pizza.business.Models;

namespace DotNet._05.TP4.Pizza.Web.Models
{
    using Pizza = DotNet._05.TP4.Pizza.business.Models.Pizza;

    public class PizzaFormViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
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
    }
}
