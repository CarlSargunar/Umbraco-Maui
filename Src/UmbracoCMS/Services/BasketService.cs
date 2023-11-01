using UmbracoCMS.Models;

namespace UmbracoCMS.Services
{
    public interface IBasketService
    {
        void AddToBasket(BasketItem basketItem);
        List<BasketItem> GetBasketItems();
        bool UpdateItem(BasketItem basketItem);
    }

    public class BasketService : IBasketService
    {
        private readonly List<BasketItem> _basketItems;

        public BasketService()
        {
            // Initialize with some dummy data
            _basketItems = new List<BasketItem>
            {
                new BasketItem { Id = 1, Quantity = 2 },
                new BasketItem { Id = 2, Quantity = 3 }
            };
        }

        public void AddToBasket(BasketItem basketItem)
        {
            var existingItem = _basketItems.FirstOrDefault(item => item.Id == basketItem.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += basketItem.Quantity;
            }
            else
            {
                _basketItems.Add(basketItem);
            }
        }

        public List<BasketItem> GetBasketItems()
        {
            return _basketItems;
        }

        public bool UpdateItem(BasketItem basketItem)
        {
            var existingItem = _basketItems.FirstOrDefault(item => item.Id == basketItem.Id);
            if (existingItem != null)
            {
                existingItem.Quantity = basketItem.Quantity;
                return true;
            }
            return false;
        }
    }
}
