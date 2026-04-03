using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoAppFormations.Models
{
    public class Categorie
    {
        public Categorie()
        {
        }
        public Categorie(string title, string description, string image, int count)
        {
            Title = title;
            Description = description;
            ImageUrl = image;
            FormationCount = count;

        }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int FormationCount { get; set; }

    }
}

