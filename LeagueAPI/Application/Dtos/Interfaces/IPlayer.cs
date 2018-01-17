﻿using System;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IPlayer
    {
        Guid PlayerId { get; set; }
        string Username { get; set; }
        int Wins { get; set;  }
        int Losses { get; set; } 
    }
}