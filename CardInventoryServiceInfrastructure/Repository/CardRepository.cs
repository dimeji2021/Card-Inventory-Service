﻿using CardInventoryServiceDomain.Model;
using CardInventoryServiceInfrastructure.IRepository;
namespace CardInventoryServiceInfrastructure.Repository
{
    public class CardRepository : ICardRepository 
    {
        private readonly InventoryDbContext _context;

        public CardRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCard(Card model)
        {
            await _context.Cards.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
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
            return _context.Cards
                           .OrderBy(x => x.Id)
                           .Skip(skip)
                           .Take(pageSize)
                           .ToList();
        }
        public int GetUsedCardsCount()
        {
            return _context.Cards.Count();
        }
    }
}
