using MvcMovie.Models;

namespace EcommerceSite.Models
{
    public class LignePanier
    {
        public int Id { get; set; }
        public int quantite { get; set; }
        public int ProductId { get; set; }
        public int PanierId { get; set; }
        public Products? Product { get; set; }
        public Panier? Panier { get; set; }

    }
}
