using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pieces
{
    private string name;
    private int value;
    private int location;
    private string color;
    private Boolean bomb;
    private Boolean flag;

    public Pieces(int newValue, string newColor)
    {

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
