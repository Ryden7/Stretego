using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    private string username;

    //this is the private constructor
    public Player(string name)
    {
        username = name;
        //String password;  for secure access as of right now 
    }

    public void setUsername(string name)
    {
       username = name;
    }

    public string getUsername()
    {
        return username;
    }
}
