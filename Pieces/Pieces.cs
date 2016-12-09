using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Windows.Forms;


public class Pieces
{
    private string name;
    private int value;
    private int location;
    private string color;
    private Boolean bomb;
    private Boolean flag;
    public int maxPieceCount;

    public Pieces(int newValue, string color, int location)
    {
        if (newValue == 1)
        {
            name = "Marshall";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 10;
            maxPieceCount = 1;

        }

        if (newValue == 2)
        {
            name = "General";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 9;
            maxPieceCount = 1;


        }

        if (newValue == 3 || newValue == 4)
        {
            name = "Colonel";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 8;
            maxPieceCount = 2;


        }

        if (newValue >= 5 && newValue <= 7)
        {
            name = "Major";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 7;
            maxPieceCount = 3;


        }

        if (newValue >= 8 && newValue <= 11)
        {
            name = "Captain";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 6;
            maxPieceCount = 4;


        }

        if (newValue >= 12 && newValue <= 15)
        {
            name = "Lieutenant";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 5;
            maxPieceCount = 4;


        }

        if (newValue >= 16 && newValue <= 19)
        {
            name = "Sargeant";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 4;
            maxPieceCount = 4;

        }

        if (newValue >= 20 && newValue <= 24)
        {
            name = "Miner";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 3;
            maxPieceCount = 5;

        }

        else if (newValue >= 25 && newValue <= 32)
        {
            name = "Scout";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            value = 2;
            maxPieceCount = 8;


        }

        else if (newValue == 33)
        {
            name = "Spy";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = false;
            maxPieceCount = 1;
        }

        else if (newValue == 34)
        {
            name = "Flag";
            this.color = color;
            this.location = location;
            bomb = false;
            flag = true;
            maxPieceCount = 1;
        }

        else if (newValue >= 35 && newValue <= 40)
        {
            name = "Bomb";
            this.color = color;
            this.location = location;
            bomb = true;
            flag = false;
            maxPieceCount = 6;
        }
    }

public void modifyLocation(int location)
{
    this.location = location;
}

public string getColor()
{
    return color;
}

public int getValue()
{
    return value;
}

public string getName()
{
    return name;
}

public Boolean isBomb()
{
    return bomb;
}

public Boolean isFlag()
{
    return flag;
}

public int getLocation()
{
    return location;
}
}
