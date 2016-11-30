using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    private int[,] gameboard;
    Pieces[] boardPanels = new Pieces[101];

    public Board()
    {
        gameboard = new int[10,10];
    }

    //This method is called upon by the Form1.cs class to create the piece, constructing it in the Pieces class.
    public void makePiece(int panelValue, int imageValue, string imageColor)
    {
        Pieces newPiece = new Pieces(imageValue, imageColor);
        boardPanels[panelValue] = newPiece;
    }
}
