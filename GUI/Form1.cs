using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategoBoardBothPlayers
{
    public partial class Stratego : Form
    {
        private Dictionary<string, int> _bluePlayer = new Dictionary<string, int>();
        private const string BluePlayer = "Blue Player";

        Board board = new Board();
        public Stratego()
        {
            InitializeComponent();
            SetupGamePieces();
        }
        //The panelChanger event handlers are what control the drag and drop of the system. 
        //With the way that they are designed, you can assign any of these handlers
        //with the panel image drag-and-drop changes within this program.
        private void panelChanger_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panelChanger = sender as Panel;

            if (panelChanger.BackgroundImage != null)
            {
                panelChanger.DoDragDrop(panelChanger.BackgroundImage, DragDropEffects.Move);
                panelChanger.BackgroundImage = null;
            }
        }

        private void panelChanger_DragEnter(object sender, DragEventArgs e)
        {
            Panel panelChanger = sender as Panel;
            e.Effect = DragDropEffects.Move;
        }

        private void panelChanger_DragDrop(object sender, DragEventArgs e)
        {
            Panel panelChanger = sender as Panel;
            if (panelChanger.BackgroundImage == null)
            {
                panelChanger.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
                Image newImage = panelChanger.BackgroundImage;
                //string text
                //Tab index for position
                int tab = panelChanger.TabIndex;
                //This is calling the getColor method I will be making
                string color = getColor(panelChanger);
                //This calls the getValue method to determine the piece value
                int pieceValue = 0;// = getValue(e, panelChanger);
                //This calls the board (or the logic) to create the pieces on the back end.
                board.makePiece(panelChanger.TabIndex + 1, pieceValue, color);
            }
            else
            {
                throw (new Exception("Can't do that!"));       
            }
        }

        private void generalToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            string text = menuItem.Text;
            Panel panelChanger = new Panel();
            panelChanger.BackgroundImage = menuItem.Image;
            panelChanger.DoDragDrop(panelChanger.BackgroundImage, DragDropEffects.Move);
            panelChanger.BackgroundImage = null;
        }

        

        //private void panelChanger_MouseMove(object sender, MouseEventArgs e)
        //{
        //Panel panelChanger = sender as Panel;
        //Cursor.Current = new Cursor((Image)panelChanger.BackgroundImage);
        //}

        public int getValue(string text)
        {
            int panelValue = 0;

            if(text == "(10) Marshal ")
            {
                panelValue = 10;
            }/*else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego2 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red)
            {
                panelValue = 2;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego31 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego3Red)
            {
                panelValue = 3;
            } else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego4 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego4Red)
            {
                panelValue = 4;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego5 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego5Red)
            {
                panelValue = 5;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego6 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego6Red)
            {
                panelValue = 6;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego7 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego7Red)
            {
                panelValue = 7;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego8
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego8Red)
            {
                panelValue = 8;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego9 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego9Red)
            {
                panelValue = 9;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.StrategoB 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.strategoBRed)
            {
                panelValue = 11;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.StrategoS 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.strategoSpyRed)
            {
                panelValue = 1;
            }else if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.StrategoF 
                || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.strategoFlagRed)
            {
                panelValue = 0;
            }*/
           
            return panelValue;     
        }

        public string getColor(Panel panel)
        {
            string color = "";

            return color;
        }
    }
}
