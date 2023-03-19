using System;
namespace app.Services;

public interface ISpotifyService {

    Task<bool> Initialize(string authCode);

}

