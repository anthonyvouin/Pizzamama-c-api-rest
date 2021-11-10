using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Pizza
    {
        [JsonIgnore]
        public int PizzaID { get; set; }
        public string nom { get; set; }
        public float prix { get; set; }

        public bool vegetarienne { get; set; }
        [JsonIgnore]
        public string ingredients { get; set; }

        [NotMapped]
        [JsonPropertyName("ingredients")]

        public string [] listeIngredients
        {
            get
            {
                if((ingredients == null)||(ingredients.Count() == 0))
                {
                    return null;
                }

                return ingredients.Split(", ");
            }
        }



    }
}
