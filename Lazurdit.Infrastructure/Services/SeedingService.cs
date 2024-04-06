using Lazurdit.Application.Common.Interfaces;
using Lazurdit.Domain.Entities;

namespace Lazurdit.Infrastructure.Services;

public class SeedingService
{
    private readonly IContactRepository _contactRepository;

    public SeedingService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public void Seed()
    {
        _contactRepository.Add(new Contact()
        {
            FirstName = "Ahmed", LastName = "Ali", Email = "Ahmed@gmail.com", PhoneNumber = "0774366757"
        });
        _contactRepository.Add(new Contact()
        {
            FirstName = "Khaled", LastName = "Mohammed", Email = "Khaled@gmail.com", PhoneNumber = "0799937548"
        });
        _contactRepository.Add(new Contact()
        {
            FirstName = "Farah", LastName = "Mousa", Email = "Farah@gmail.com", PhoneNumber = "0779155744"
        });
        _contactRepository.Add(new Contact()
        {
            FirstName = "Abdelhaleem", LastName = "Alfreihat", Email = "abdelhaleem@gmail.com", PhoneNumber = "0778334238"
        });
        _contactRepository.Add(new Contact()
        {
            FirstName = "Saif", LastName = "Omari", Email = "saif@gmail.com", PhoneNumber = "0789611636"
        });
    }
}