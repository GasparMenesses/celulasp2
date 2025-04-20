using System;
using System.Collections.Generic;
using System.Linq;

namespace Program  
{
    public class cell
    {
        public bool IsAlive;
        public readonly List<cell> neighbor = new List<cell>();
        private bool IsAliveNext;

        public void DetermineNextLiveState()
        {
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