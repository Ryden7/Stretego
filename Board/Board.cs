using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    //private int[,] gameboard;
    private object[] gameboard;
    int tracker = 1;
    Pieces[] boardPanels = new Pieces[101];

    public Board()
    {
        //gameboard = new int[10,10];
        gameboard = new object[100];
    }

    //This method is called upon by the Form1.cs class to create the piece, constructing it in the Pieces class.
    public void makePiece(int location)
    {
        gameboard[tracker] = new Pieces(tracker, "blue", location);
        tracker++;
    }

    /*
    public int battle(Pieces p1, Pieces p2)//p1 is attacking player 
    {
        if (p1.getColor().Equals(p2.getColor()))//same colors No Battle
        {
            return 0;
        }
        else if (p2.getValue().Equals(0))//game over Flag Captured
        {
            return 4;
        }
        else if (p1.getValue().Equals(1) && p2.getValue().Equals(10)) // spy kills marshall
        {
            return 1;
        }
        else if (p1.getValue().Equals(3) && p2.getValue().Equals(11)) // miner disables bomb
        {
            return 1;
        }
        else if (p1.getValue().Equals(p2.getValue()))// equal values both players removed
        {
            return 0;
        }
        else if (p1.getValue() > p2.getValue())// piece 1 higher value remove p2
        {
            return 1;
        }
        else if (p1.getValue() < p2.getValue())//piece 2 higher value rem
        */
}
