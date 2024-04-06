using System.Collections;
using System.Net.Http.Json;
using Lazurdit.UI.Models;

namespace Lazurdit.UI.Services;

public class ContactService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7251/api/Contact/";

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<bool> AddContactAsync(Contact contact)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}Create", contact);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<IList<Contact>> GetContactsAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Contact>>($"{BaseUrl}GetAll");
            return response;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<bool> UpdateContactAsync(Contact contact)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}update", contact);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteContact(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}Delete/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IList<Contact>>  GetSorted(string orderBy, string sortBy)
    {
        return await _httpClient.GetFromJsonAsync<IList<Contact>>($"{BaseUrl}get?orderBy={orderBy}&sortOrder={sortBy}");
    }
}