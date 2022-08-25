namespace DotNet._05.TP4.Pizza.Web.Models
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public PateViewModel Pate { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();

        /*public static List<IngredientViewModel> IngredientsDisponibles => new List<IngredientViewModel>
        {
            new IngredientViewModel{Id=1,Nom="Mozzarella"},
            new IngredientViewModel{Id=2,Nom="Jambon"},
            new IngredientViewModel{Id=3,Nom="Tomate"},
            new IngredientViewModel{Id=4,Nom="Oignon"},
            new IngredientViewModel{Id=5,Nom="Cheddar"},
            new IngredientViewModel{Id=6,Nom="Saumon"},
            new IngredientViewModel{Id=7,Nom="Champignon"},
            new IngredientViewModel{Id=8,Nom="Poulet"}
        };

        public static List<PateViewModel> PatesDisponibles => new List<PateViewModel>
        {
            new PateViewModel{ Id=1,Nom="Pate fine, base crême"},
            new PateViewModel{ Id=2,Nom="Pate fine, base tomate"},
            new PateViewModel{ Id=3,Nom="Pate épaisse, base crême"},
            new PateViewModel{ Id=4,Nom="Pate épaisse, base tomate"}
        };*/
    }
}
