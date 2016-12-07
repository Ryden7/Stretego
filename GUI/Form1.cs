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
        //local storage for count of game pieces
        private Dictionary<string, int> _bluePlayer = new Dictionary<string, int>();
        private const string BluePlayer = "Blue Player";

        int counter = 1;
        Board gameboard = new Board();
        int oldLocation;
        int NewLocation;

        public Stratego()
        {
            InitializeComponent();

            //Setup the local storage for count of game pieces
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
                oldLocation = panelChanger.TabIndex + 1;
                modifyLocation(oldLocation, NewLocation);
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


         //   SelectedMenuItem item = (SelectedMenuItem)e.Data.GetData(typeof(SelectedMenuItem));
           // var player = GetPlayerColor(item.SelectedItem);
            //var gamePiece = GetGamePiece(item.SelectedItem.Name);


            if (counter < 80)
            {
               // if (!DoPiecesExist(player, gamePiece)) throw new Exception(String.Format("Out of {0}", gamePiece));

                if (panelChanger.BackgroundImage == null)
                {
                    panelChanger.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
                    
                    if (counter <= 40)
                    {
                        gameboard.makePiece(panelChanger.TabIndex + 1, "blue");
                        
                    }
                    else
                    {
                        gameboard.makePiece(panelChanger.TabIndex + 1, "red");

                    }

                    counter++;
                    NewLocation = panelChanger.TabIndex + 1;
                }
                else
                {
                    throw (new Exception("Can't do that!"));

                }
            }

            else
            {
                if (panelChanger.BackgroundImage == null)
                {
                    panelChanger.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
                    NewLocation = panelChanger.TabIndex + 1;

                    //update position
                    modifyLocation(oldLocation, NewLocation);
                    
                }

                //else fight
                else
                {
                    gameboard.pieceLookup(oldLocation, NewLocation);
                }

            }

           }


        private void generalToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
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

        public int getValue(Panel panel)
        {
            int panelValue = 0;
            if(panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego10 || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego10Red)
            {
                return 10;
            }

            return panelValue;     
        }

        public void modifyLocation(int oldLocation, int newLocation)
        {
            gameboard.movePiece(oldLocation, NewLocation);
        }



        //Lisa's code
        private string GetPlayerColor(ToolStripItem item)
        {
            if (item.OwnerItem.Text.Equals(BluePlayer)) return BluePlayer;

            return null;
        }


        private bool DoPiecesExist(string player, string gamePiece)
        {
            if (player.Equals(BluePlayer) && _bluePlayer[gamePiece] > 0) return true;

            return false;
        }


        private string GetGamePiece(string itemName)
        {
            string gamePiece = String.Empty;
            switch (itemName)
            {
                case "general9ToolStripMenuItem":
                    gamePiece = "General";
                    break;


            }

            return gamePiece;

        }

        private void AdjustGamePieces(string player, string gamePiece, ToolStripItem item)
        {
            int count = 0;
            if (player.Equals(BluePlayer))
            {
                var currVal = _bluePlayer[gamePiece];
                count = currVal - 1;
                _bluePlayer[gamePiece] = count;

            }

            item.Text = String.Format("({0}) {1}", count, gamePiece);
        }

        private void SetupGamePieces()
        {
            _bluePlayer.Add("General", 9);
        }
    }


}

