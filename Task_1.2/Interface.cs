using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
     public interface IPlayer
{
    int Age { get; }
    string FirstName { get; }
    string LastName { get; }
    PlayerRank Rank { get; }
}
public enum PlayerRank
{
    Private = 2,
    Lieutenant = 21,
    Captain = 25,
    Major = 29,
    Colonel = 33,
    General = 39
}

}
