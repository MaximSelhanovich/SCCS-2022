namespace WEB_053502_Selhanovich.Entities
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();

        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => decimal.Parse(item.Value.Quantity.ToString()) *
                item.Value.Dish.Price);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="dish">добавляемый объект</param>
        public virtual void AddToCart(Dish dish)
        {
            foreach (var item in Items)
            {
                if (item.Key == dish.Id)
                {
                    item.Value.Quantity += 1;
                    return;
                }
            }
            Items[dish.Id] = new CartItem
            {
                Dish = dish,
                Quantity = 1
            };
        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
}
