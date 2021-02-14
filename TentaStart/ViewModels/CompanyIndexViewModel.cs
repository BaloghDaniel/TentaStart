using System.Collections.Generic;

namespace TentaStart.ViewModels
{
    public class CompanyIndexViewModel
    {
        public class Item
        {
            public int Id { get; set; }
            public string Typ { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
        }
        public List<Item> Items { get; set; }
    }
}