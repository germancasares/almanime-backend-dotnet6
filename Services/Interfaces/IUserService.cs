﻿namespace Almanime.Services.Interfaces;

public interface IUserService
{
    void Create(string auth0Id, string name);
}