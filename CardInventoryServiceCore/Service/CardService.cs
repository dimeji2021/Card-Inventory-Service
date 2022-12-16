using AutoMapper;
using CardInventoryServiceCore.IService;
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;
using CardInventoryServiceInfrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceCore.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<bool> CreateCard(CardRequestDto model)
        {
            var card = new Card()
            {
                Id = Guid.NewGuid(),
                CardUser = model.CardUser,
                CardIssuerRef = model.CardIssuerRef,    
                BranchRef = model.BranchRef,
                PrintedAt = DateTime.Now
            };
            return await _cardRepository.CreateCard(card);
        }
        public Card GetCardById(Guid Id)
        {
            return _cardRepository.GetCardById(Id);
        }
        public List<Card> GetCardByIssuerRef(Guid Id)
        {
            return _cardRepository.GetCardByIssuerRef(Id);
        }
        public List<Card> GetPrintedCards(int pageSize, int pageNumber)
        {
            return _cardRepository.GetPrintedCards(pageSize, pageNumber);
        }
        public int GetUsedCardsCount()
        {
            return _cardRepository.GetUsedCardsCount();
        }
    }
}
