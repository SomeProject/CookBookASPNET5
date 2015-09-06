namespace DBLayer.Class
{
    public class MealIngredient : MongoObject
    {
        public int count { get; set; }

        public virtual Unit unit { get; set; }

        public virtual Meal meal { get; set; }

        public virtual Ingredient ingredient { get; set; }

    }
}
