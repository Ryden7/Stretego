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

    public Pieces(int newValue, string color, int location)
    {
        //blue team
        if (newValue <= 40)
        {
            if (newValue == 1)
            {
                name = "Marshall";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 10;

            }

            if (newValue == 2)
            {
                name = "General";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 9;


            }

            if (newValue == 3 || newValue == 4)
            {
                name = "Colonel";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 8;


            }

            if (newValue >= 5 && newValue <= 7)
            {
                name = "Major";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 7;


            }

            if (newValue >= 8 && newValue <= 11)
            {
                name = "Captain";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 6;


            }

            if (newValue >= 12 && newValue <= 15)
            {
                name = "Lieutenant";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 5;


            }

            if (newValue >= 16 && newValue <= 19)
            {
                name = "Sargeant";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 4;


            }

            if (newValue >= 20 && newValue <= 24)
            {
                name = "Miner";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 3;


            }

            else if (newValue >= 25 && newValue <= 32)
            {
                name = "Scout";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 2;


            }

            else if (newValue == 33)
            {
                name = "Spy";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;

            }

            else if (newValue == 34)
            {
                name = "Flag";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = true;

            }

            else if (newValue >= 35 && newValue <= 40)
            {
                name = "Bomb";
                this.color = color;
                this.location = location;
                bomb = true;
                flag = false;

            }
        }

        //red team
        else if (newValue > 40)
        {
            if (newValue == 41)
            {
                name = "Marshall";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 10;

            }

            if (newValue == 42)
            {
                name = "General";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 9;


            }

            if (newValue == 43 || newValue == 44)
            {
                name = "Colonel";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 8;


            }

            if (newValue >= 45 && newValue <= 47)
            {
                name = "Major";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 7;


            }

            if (newValue >= 48 && newValue <= 51)
            {
                name = "Captain";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 6;


            }

            if (newValue >= 52 && newValue <= 55)
            {
                name = "Lieutenant";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 5;


            }

            if (newValue >= 56 && newValue <= 59)
            {
                name = "Sargeant";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 4;


            }

            if (newValue >= 60 && newValue <= 64)
            {
                name = "Miner";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 3;


            }

            else if (newValue >= 65 && newValue <= 72)
            {
                name = "Scout";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;
                value = 2;


            }

            else if (newValue == 73)
            {
                name = "Spy";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = false;

            }

            else if (newValue == 74)
            {
                name = "Flag";
                this.color = color;
                this.location = location;
                bomb = false;
                flag = true;

            }

            else if (newValue >= 75 && newValue <= 80)
            {
                name = "Bomb";
                this.color = color;
                this.location = location;
                bomb = true;
                flag = false;

            }
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
