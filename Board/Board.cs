using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    //private int[,] gameboard;
    private Pieces[] gameboard; //stores the location and their corresponding pieces
    private Dictionary<int, Pieces> location2piece; //get the piece that is in that location
    int tracker = 1;
    private Boolean redready;
    private Boolean blueready;
    //Pieces[] boardPanels = new Pieces[101];

    public Board()
    {
        //gameboard = new int[10,10];
        gameboard = new Pieces[101];
        location2piece = new Dictionary<int, Pieces>();

    }

    //This method is called upon by the Form1.cs class to create the piece, constructing it in the Pieces class.
    public void makePiece(int location, string color)
    {
        //gameboard[tracker] to gameboard[location]
        gameboard[location] = new Pieces(tracker, color, location);
        location2piece.Add(location, gameboard[location]);
        tracker++;
       // updateLocation2Piece(location,  gameboard[location]);
    }

    public void movePiece(int oldLocation, int newLocation)
    {
        gameboard[newLocation] = gameboard[oldLocation];
        gameboard[newLocation].modifyLocation(newLocation);
        gameboard[oldLocation] = null;
    }

    public int pieceLookup(int oldLocation, int newLocation)
    {
        Pieces attackingPiece;
        Pieces defendingPiece;
    //    Pieces placeholder;
        location2piece.TryGetValue(oldLocation, out attackingPiece);
        location2piece.TryGetValue(newLocation, out defendingPiece);

        if (attackingPiece.getColor().Equals(defendingPiece.getColor())) //same colors No Battle
        {
            return 1;
        }

        else if (defendingPiece.getValue().Equals(0))//game over Flag Captured
        {
            return 2;
        }

        else if (attackingPiece.getValue().Equals(1) && defendingPiece.getValue().Equals(10)) // spy kills marshall
        {
            //update positions for spy killing marshall
            attackingPiece.modifyLocation(defendingPiece.getLocation());
            gameboard[defendingPiece.getLocation()] = attackingPiece;
            gameboard[attackingPiece.getLocation()] = null;
            location2piece.Remove(defendingPiece.getLocation());
            location2piece.Remove(attackingPiece.getLocation());
            location2piece.Add(defendingPiece.getLocation(), attackingPiece);
            return 3;

        }

        else if (attackingPiece.getValue().Equals(3) && defendingPiece.getValue().Equals(11)) // miner disables bomb
        {
            attackingPiece.modifyLocation(defendingPiece.getLocation());
            gameboard[defendingPiece.getLocation()] = attackingPiece;
            gameboard[attackingPiece.getLocation()] = null;
            location2piece.Remove(defendingPiece.getLocation());
            location2piece.Remove(attackingPiece.getLocation());
            location2piece.Add(defendingPiece.getLocation(), attackingPiece);
            return 4;

        }

        else if (attackingPiece.getValue().Equals(defendingPiece.getValue()))// equal values both players removed
        {
            gameboard[defendingPiece.getLocation()] = null;
            gameboard[attackingPiece.getLocation()] = null;
            location2piece.Remove(defendingPiece.getLocation());
            location2piece.Remove(attackingPiece.getLocation());
            return 5;
        }

        else if (attackingPiece.getValue() > defendingPiece.getValue())
            {
                attackingPiece.modifyLocation(defendingPiece.getLocation());
                gameboard[defendingPiece.getLocation()] = attackingPiece;
                gameboard[attackingPiece.getLocation()] = null;
                location2piece.Remove(defendingPiece.getLocation());
                location2piece.Remove(attackingPiece.getLocation());
                location2piece.Add(defendingPiece.getLocation(), attackingPiece);
            //add captured piece here.
            return 6;
            }

        else if (defendingPiece.getValue() > attackingPiece.getValue())
        {
            
            gameboard[attackingPiece.getLocation()] = null;
            location2piece.Remove(attackingPiece.getLocation());
            //add captured piece here.
            return 7;
        }

        return 8;

    }

    //Simple get pliece possition method.
    public Pieces getPieceByPosition(int position)
    {
        Pieces piece = gameboard[position];
        return piece;
    }

    //start game method
    public Boolean startGame(Boolean YesOrNo, Pieces piece, int PieceCount)
    {
        string color = piece.getColor();

        if (color == "Red")
        {
            redready = true;
        }

        if (color == "Blue")
        {
            blueready = true;
        }

        if (PieceCount != 80)
        {
            return false;
        }

        if (blueready == true && redready == true)
        {
            return true;
        }

        return false;
    }



    /*
    public void updateLocation2Piece(int location, Pieces piece)
    {
        location2piece.Add(location, piece);
    }
    */





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
