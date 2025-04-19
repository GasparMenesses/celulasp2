using System;
using System.Collections.Generic;
using System.Linq;

namespace Ucu.Poo.GameOfLife
{
    public class Cell
    {
        private bool IsAlive;
        public readonly List<Cell> neighbor = new List<Cell>();
        private bool IsAliveNext;

        public void DetermineNextLiveState()
        {
            // Las células vivas con menos de dos vecinos vivos mueren 
            // Las células vivas con más de tres vecinos vivos mueren 
            // Las células muertas con tres vecinos vivos vuelven a la vida 
            int liveNeighbors = neighbor.Where(x => x.IsAlive).Count();

            if (IsAlive)
                IsAliveNext = liveNeighbors == 2 || liveNeighbors == 3;
            else
            {
                IsAliveNext = liveNeighbors == 3;
            }
            
        }

        public void Advance()
        { 
            IsAlive=IsAliveNext;  
        }
    }
}