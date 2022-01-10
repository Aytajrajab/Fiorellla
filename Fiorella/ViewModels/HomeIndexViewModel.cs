using Fiorella.Models;
using System.Collections.Generic;

namespace Fiorella.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
    }
}
