namespace DotNet._05.TP4.Pizza.Web.Models
{
    using DotNet._05.TP4.Pizza.business.Models;
    public class PateViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public static PateViewModel FromPate(Pate pate)
        {
            return new Models.PateViewModel()
            {
                Id = pate.Id,
                Nom = pate.Nom
            };
        }

        public static Pate ToPate(PateViewModel pateViewModel)
        {
            return new Pate()
            {
                Id = pateViewModel.Id,
                Nom = pateViewModel.Nom
            };
        }

    }
}