using CardInventoryServiceDomain.Core.Utilities;
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.ETO;
using CardInventoryServiceDomain.Model;
using CardInventoryServiceInfrastructure.IRepository;
using Microsoft.Extensions.Caching.Memory;

namespace CardInventoryServiceInfrastructure.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly InventoryDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public CardRepository(InventoryDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        public async Task<Guid> CreateCard(CardRequestDto model)
        {
            var card = new Card()
            {
                Id = Guid.NewGuid(),
                CardUser = model.CardUser,
                CardIssuerRef = model.CardIssuerRef,
                BranchRef = model.BranchRef,
                PrintedAt = DateTime.Now
            };
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            NotificationETO notification = new NotificationETO()
            {
                EmailType = "text",
                ToRecipients = new List<Recipients>
                {
                   new Recipients {ToAddress = "adedimeji88@yahoo.com", ToName = "Dimeji"},
                   new Recipients {ToAddress = "testing@gmail.com", ToName = "test"}

                },
                Subject = "Successful Creation",
                Body = $"Card Successfully Created for {card.CardUser} on the {card.PrintedAt}"

            };
            Publisher publisher = new Publisher();
            publisher.Publish(notification);
            return card.Id;
        }
        public Card GetCardById(Guid Id)
        {
            return _context.Cards.Where(c => c.Id == Id).FirstOrDefault();
        }
        public List<Card> GetCardByIssuerRef(Guid issuerRef)
        {
            return _context.Cards.Where(c => c.CardIssuerRef == issuerRef).ToList();
        }
        public List<Card> GetPrintedCards(int pageSize, int pageNumber)
        {
            int skip = (pageNumber - 1) * pageSize;
            List<Card> cards;
            cards = _memoryCache.Get<List<Card>>(key: "cards");

            if (cards is null)
            {
                cards = _context.Cards
                            .OrderBy(x => x.Id)
                            .Skip(skip)
                            .Take(pageSize)
                            .ToList();
                _memoryCache.Set(key: "cards", cards, TimeSpan.FromMinutes(1));
            }
            return cards;
        }
        public int GetUsedCardsCount()
        {
            return _context.Cards.Count();
        }
    }
}
