using AutoMapper;
using CardApp.Server.Api.DTOs;
using CardApp.Server.Bll.Interfaces;
using CardApp.Server.Bll.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardApp.Server.Api.Controllers;

[ApiController]
[Route("[controller]/api")]
public class CardsController : ControllerBase
{
    private readonly ICardInfoService cardInfoService;
    private readonly IMapper mapper;
    
    public CardsController(ICardInfoService cardsService, IMapper mapper)
    {
        this.cardInfoService = cardsService;
        this.mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CardDto>>> GetAllCards()
    {
        try
        {
            var cards = await cardInfoService.GetAllCardsAsync();
        
            return Ok(cards.Select(x => x.ToCardDto()));
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError); 
        }
    }
    
    [HttpGet("{id:Guid}",Name = "GetCardById")]
    public async Task<ActionResult<CardDto>> GetCardById(Guid id)
    {
        try
        {
            var card = await cardInfoService.GetCardByIdAsync(id);
        
            return Ok( card.ToCardDto());
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError); 
        }
    }
    
    [HttpPost(Name = "CreateCard")]
    public async Task<ActionResult> CreateCard(CardDto cardDto)
    {
        try
        {
            await cardInfoService.CreateCardAsync(new Card(cardDto.ProductId, cardDto.Name, cardDto.ImageUrl));
        
            return Ok();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError); 
        }
    }
    
    [HttpPut(Name = "UpdateCard")]
    public async Task<ActionResult> UpdateCard(CardDto cardDto, Guid oldCardId)
    {
        try
        {
            await cardInfoService.UpdateCardAsync(oldCardId, cardDto.FromCardDto());
        
            return Ok();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError); 
        }
        
    }
    
    [HttpDelete(Name = "DeleteCard")]
    public async Task<ActionResult> DeleteCard(Guid cardId)
    {
        try
        {
            await cardInfoService.DeleteCardAsync(cardId);
        
            return Ok();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        // catch (Exception)
        // {
        //     return  StatusCode(StatusCodes.Status500InternalServerError); 
        // }
        
    }
    
    
    
    
    
    
    
    
}