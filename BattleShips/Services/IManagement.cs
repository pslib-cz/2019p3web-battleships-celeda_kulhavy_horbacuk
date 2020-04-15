﻿using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IManagement
    {
        //vytvoreni novy hry, prihlasovani, vypis, odhlasovani, hlavni stranka 
        //Kulhavý
        List<User> GetUsers(string userId);
        List<Game> GetGames(Guid? gameId);
        List<Game> GetGameDetails(Guid gameId);
        bool RemoveGame(Guid Id);
        bool AddGame(Game Game);
        bool AddUser(User user);
        bool RemoveUserFromGame(string userId);
        bool CreateNewGame(string userId, Guid gameId, int boardSize);
        UserGame UserCreateGame(string userId, Guid gameId);
        User CreateNewUser(string userId, string Name);
    }
}
