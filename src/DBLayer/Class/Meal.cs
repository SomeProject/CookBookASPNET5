using System.Collections.Generic;


namespace DBLayer.Class
{
    public class Meal : MongoObject
    {
        public string name { get; set; }

        public string imgUrl { get; set; }

        public string howToCook { get; set; }

        public virtual Category category { get; set; }

        public virtual ICollection<MealIngredient> ingredients { get; set; }

        public int cookedTimes { get; set; }
    }
}
