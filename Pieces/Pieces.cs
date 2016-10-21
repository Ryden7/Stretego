using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pieces
{
    private string name;
    private int rank;
    //image
    private Boolean bomb;
    private Boolean flag;

    public Pieces(int num)
    {
        if(num == 1)
        {
            name = "Marshall";
            rank = 1;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 2)
        {
            name = "General";
            rank = 2;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 3)
        {
            name = "Colonels";
            rank = 3;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 4)
        {
            name = "Majors";
            rank = 4;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 5)
        {
            name = "Captains";
            rank = 5;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 6)
        {
            name = "Lieutenants";
            rank = 6;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 7)
        {
            name = "Sargeant";
            rank = 7;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 8)
        {
            name = "Miners";
            rank = 8;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 9)
        {
            name = "Scout";
            rank = 9;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 10)
        {
            name = "Spy";
            rank = 10;
            //image = newImage;
            bomb = false;
            flag = false;
        }

        if (num == 11)
        {
            name = "Bomb";
            rank = 11;
            //image = newImage;
            bomb = true;
            flag = false;
        }

        if (num == 12)
        {
            name = "Flag";
            rank = 12;
            //image = newImage;
            bomb = false;
            flag = true;
        }
    }
}
