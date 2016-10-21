using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    private int[,] gameboard;
    public Board(int coords1, int coords2)
    {
        gameboard = new int[coords1,coords2];
    }
}
