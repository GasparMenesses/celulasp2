using System;
using System.Collections.Generic;
using System.Linq;

namespace Program  
{
    public class Cell
    {
        public bool IsAlive;        // Indica si la célula está viva actualmente
        public readonly List<Cell> Neighbors = new List<Cell>(); 
        
        // Indica si la célula estará viva en la próxima generación
        private bool IsAliveNext;

        public void DetermineNextLiveState()
        {
            int liveNeighbors = Neighbors.Count(x => x.IsAlive);

            IsAliveNext = IsAlive
                ? (liveNeighbors == 2 || liveNeighbors == 3)
                : (liveNeighbors == 3);                         //  Si la célula está viva, permanece viva si tiene 2 o 3 vecinas vivas
                                                                //  Si está muerta, revive solo si tiene exactamente 3 vecinas vivas
        }

        public void Advance()   // Avanza al siguiente estado (actualiza IsAlive según IsAliveNext)
        {
            IsAlive = IsAliveNext;
        }
    }
}