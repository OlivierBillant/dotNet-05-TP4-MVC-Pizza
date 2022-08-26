using DotNet._05.TP4.Pizza.business.Models;
using System.IO;

namespace DotNet._05.TP4.Pizza.business
{

    using Pizza = Models.Pizza;

    public class PizzeriaService
    {
        private static List<Ingredient> listeIngredients = Pizza.IngredientsDisponibles;
        private static List<Pate> listePates = Pizza.PatesDisponibles;
        private static List<Pizza> listePizzas = new();

        public List<Pate> GetListePates()
        {
            return listePates;
        }
        public List<Ingredient> GetListeIngredients()
        {
            return listeIngredients;
        }
        public List<Pizza> GetListePizzas()
        {
            return listePizzas;
        }

        public void EditPate(Pate pate)
        {
            var pateDb = listePates.FirstOrDefault(p => p.Id == pate.Id);
            pateDb.Nom = pate.Nom;
        }
        public void CreatePate(Pate pate)
        {
            listePates.Add(pate);
        }

        public void UpdatePizza(Pizza pizza)
        {
            var pizzaToUpdate = listePizzas.FirstOrDefault(pizza => pizza.Id == pizza.Id);
            if (pizzaToUpdate is not null)
            {
                pizzaToUpdate.Nom = pizza.Nom;
            }
        }

        public void RemovePizza(int id)
        {
            listePizzas.Remove(GetPizzaById(id));
        }

        public void CreatePizza(Pizza pizza)
        {
            if (pizza.Id == 0 && listePizzas.Any())
            {
                pizza.Id = listePizzas.Max(p => p.Id) + 1;
            }
            else
            {
                pizza.Id = 1;
            }

            listePizzas.Add(pizza);
        }

        public Pizza GetPizzaById(int id)
        {
            return listePizzas.Where(p => p.Id == id).FirstOrDefault();
        }
    }

}