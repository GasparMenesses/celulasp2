using System;
using System.Collections.Generic;
using System.Linq;

namespace Ucu.Poo.GameOfLife
{
    public class Cell
    {
        public bool IsAlive;
        public readonly List<Cell> Neighbors = new List<Cell>();
        private bool IsAliveNext;

        public void DetermineNextLiveState()
        {
            int liveNeighbors = Neighbors.Count(x => x.IsAlive);

            IsAliveNext = IsAlive
                ? (liveNeighbors == 2 || liveNeighbors == 3)
                : (liveNeighbors == 3);
        }

        public void Advance()
        {
            IsAlive = IsAliveNext;
        }
    }

}