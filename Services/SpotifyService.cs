﻿using System.Text;
using System.Text.Json;
using app.Models;

namespace app.Services;

public class SpotifyService : ISpotifyService {
    private readonly ISecureStorageService secureStorageService;
    private string accessToken;

    private HttpClient client;

    public SpotifyService(ISecureStorageService secureStorageService) {
        this.secureStorageService = secureStorageService;
    }

    public async Task<bool> Initialize(string authCode) {

        var bytes = Encoding.UTF8.GetBytes($"{Constants.SpotifyClientId}:{Constants.SpotifyClientSecret}");
        var authHeader = Convert.ToBase64String(bytes);

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);

        var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() {
            new("code", authCode),
            new("redirect_uri", Constants.RedirectUrl),
            new("grant_type", "authorization_code")
        });

        var response = await client.PostAsync("https://accounts.spotify.com/api/token", content);

        var json = await response.Content.ReadAsStringAsync();

        //deserializing token
        var result = JsonSerializer.Deserialize<AuthResult>(json);

        accessToken = result.AccessToken;

        await secureStorageService.Save(nameof(result.AccessToken), result.AccessToken);
        await secureStorageService.Save(nameof(result.RefreshToken), result.RefreshToken);

        return response.IsSuccessStatusCode;
    }

    public async Task<SearchResult> Search(string searchText, string types) {
        var client = await GetClient();
        var response = await client.GetAsync($"search?q={searchText}&type={types}");

        var content = await response.Content.ReadAsStreamAsync();

        //throw exception in case of unsuccessful response
        response.EnsureSuccessStatusCode();

        //deserialize search result, and then return it
        var result = JsonSerializer.Deserialize<SearchResult>(content);

        return result;
    }

    private async Task<HttpClient> GetClient() {
        if (accessToken == null) {
            accessToken = await secureStorageService.Get(nameof(AuthResult.AccessToken));
        }
        if (client == null) {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.spotify.com/v1/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }
        return client;
    }
}
