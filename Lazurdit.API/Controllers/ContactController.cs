using FluentValidation;
using Lazurdit.Application.Common.Interfaces;
using Lazurdit.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lazurdit.API.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;
    private readonly IValidator<Contact> _validator;

    public ContactController(IContactRepository contactRepository,IValidator<Contact> validator)
    {
        _contactRepository = contactRepository;
        _validator = validator;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_contactRepository.GetAll());
    }
    [HttpGet]
    public IActionResult GetById(int id)
    {
        return Ok(_contactRepository.GetById(id));
    }
    [HttpPut]
    public IActionResult Update(Contact contact)
    {
       var validation = _validator.Validate(contact);
       if (!validation.IsValid) 
           return BadRequest(validation.Errors);
       _contactRepository.Update(contact);
       return Ok(contact);


    }
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var result = _contactRepository.Delete(id);
        if (result)
        {
            return Ok();
        }
        return BadRequest("Cannot find the contact");

    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        var validate = _validator.Validate(contact);
        if (!validate.IsValid)
        {
            return BadRequest(validate.Errors.Select(failure=>new
            {
                failure.PropertyName,
                failure.ErrorMessage
            }));
        }
        _contactRepository.Add(contact);
        return Ok();
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string orderBy, string sortOrder ="ASC")
    {
        if (string.IsNullOrWhiteSpace(orderBy) || string.IsNullOrWhiteSpace(sortOrder))
            return BadRequest("Sorting Details must be provided");
        IEnumerable<Contact>? sortedContacts;
        switch (orderBy.ToLower())
        {
            case "firstname":
                sortedContacts = _contactRepository.Sort(x => x.FirstName,sortOrder);
                break;
            case "lastname":
                sortedContacts = _contactRepository.Sort(x => x.LastName, sortOrder);
                break;
            case "id" :
                sortedContacts = _contactRepository.Sort(x => x.Id,sortOrder);
                break;
            case "email":
                sortedContacts = _contactRepository.Sort(x => x.Email,sortOrder);
                break;
            case "phonenumber":
                sortedContacts = _contactRepository.Sort(x => x.PhoneNumber,sortOrder);
                break;
            default:
                return BadRequest("Invalid Order By Name");
        }

        return Ok(sortedContacts);
    }
}