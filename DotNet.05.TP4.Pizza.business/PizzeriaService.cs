using DotNet._05.TP4.Pizza.business.Models;

namespace DotNet._05.TP4.Pizza.business
{

    using Pizza = Models.Pizza;

    public class PizzeriaService
    {
        private static List<Ingredient> listeIngredients = Pizza.IngredientsDisponibles;
        private static List<Pate> listePates = Pizza.PatesDisponibles;
        private static List<Pizza> listePizzas = new();

        public List<Pate> getListePates()
        {
            return listePates;
        }
        public List<Ingredient> getListeIngredients()
        {
            return listeIngredients;
        }
        public List<Pizza> getListePizzas()
        {
            return listePizzas;
        }
    }
}