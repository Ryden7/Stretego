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

        //trying to get to the point where we only need one variable to determine which player is currently playing
        Player player;
        Pieces currentplayer;

        private Boolean gamehastarted;
        Panel[] redpanels = new Panel[50];
        Panel[] bluepanels = new Panel[50];

        public Stratego()
        {
            InitializeComponent();

            //Setup the local storage for count of game pieces
            SetupGamePieces();
            makePanelArray();

            bluepanels[2].AllowDrop = false;
            bluepanels[3].AllowDrop = false;
            bluepanels[6].AllowDrop = false;
            bluepanels[7].AllowDrop = false;

            redpanels[42].AllowDrop = false;
            redpanels[43].AllowDrop = false;
            redpanels[46].AllowDrop = false;
            redpanels[47].AllowDrop = false;

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


            if (!gamehastarted && counter < 40)
            {
                foreach (Panel panel in redpanels)
                {
                    panel.AllowDrop = false;
                }

                //lake panels changing AllowDrop to false
                bluepanels[2].AllowDrop = false;
                bluepanels[3].AllowDrop = false;
                bluepanels[6].AllowDrop = false;
                bluepanels[7].AllowDrop = false;
            }

            if (!gamehastarted && counter >= 40)
            {
                foreach (Panel panel in redpanels)
                {
                    panel.AllowDrop = true;
                }

                foreach (Panel panel in bluepanels)
                {
                    panel.AllowDrop = false;
                }

                //lake panels changing AllowDrop to false
                redpanels[42].AllowDrop = false;
                redpanels[43].AllowDrop = false;
                redpanels[46].AllowDrop = false;
                redpanels[47].AllowDrop = false;
            }

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
                    //This is what is the battle logic for the GUI side.
                    currentplayer = gameboard.getPieceByPosition(oldLocation);
                    Pieces otherplayer = gameboard.getPieceByPosition(NewLocation); // +  2

                    if (otherplayer.getColor() != currentplayer.getColor())
                    {
                        int battletype = gameboard.pieceLookup(oldLocation, NewLocation);

                        switch (battletype)
                        {
                            case 1:
                                panelChanger.AllowDrop = false;
                                break;
                            case 2:
                                break;
                            case 3:
                            case 4:
                            case 6:
                                panelChanger.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
                                
                                //NewLocation = panelChanger.TabIndex + 1;
                                //update position
                                //modifyLocation(oldLocation, NewLocation);
                                break;
                            case 5:
                                panelChanger.BackgroundImage = null;
                                break;
                            case 7:
                            default:
                                break;
                        }

                        panelChanger.AllowDrop = true;
                    }
                  
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
            if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego10 || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego10Red)
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

        private void StartGame_MouseClick(object sender, MouseEventArgs e)
        {
            /*the 40 being sent to the gameboard is hardcoded for testing
             *we want to put a counter based on player for this.
             */
            //gamehastarted = gameboard.startGame(true, "Blue", 80); //these values are for testing only.
            gamehastarted = true;
            if (gamehastarted)
            {
                foreach (Panel panel in redpanels)
                {
                    panel.AllowDrop = true;
                }

                foreach (Panel panel in bluepanels)
                {
                    panel.AllowDrop = true;
                }

                bluepanels[2].AllowDrop = false;
                bluepanels[3].AllowDrop = false;
                bluepanels[6].AllowDrop = false;
                bluepanels[7].AllowDrop = false;

                redpanels[42].AllowDrop = false;
                redpanels[43].AllowDrop = false;
                redpanels[46].AllowDrop = false;
                redpanels[47].AllowDrop = false;
            }
        }

        public void makePanelArray()
        {
            redpanels[0] = panel1;
            redpanels[1] = panel2;
            redpanels[2] = panel3;
            redpanels[3] = panel4;
            redpanels[4] = panel5;
            redpanels[5] = panel6;
            redpanels[6] = panel7;
            redpanels[7] = panel8;
            redpanels[8] = panel9;
            redpanels[9] = panel10;
            redpanels[10] = panel11;
            redpanels[11] = panel12;
            redpanels[12] = panel13;
            redpanels[13] = panel14;
            redpanels[14] = panel15;
            redpanels[15] = panel16;
            redpanels[16] = panel17;
            redpanels[17] = panel18;
            redpanels[18] = panel19;
            redpanels[19] = panel20;
            redpanels[20] = panel21;
            redpanels[21] = panel22;
            redpanels[22] = panel23;
            redpanels[23] = panel24;
            redpanels[24] = panel25;
            redpanels[25] = panel26;
            redpanels[26] = panel27;
            redpanels[27] = panel28;
            redpanels[28] = panel29;
            redpanels[29] = panel30;
            redpanels[30] = panel31;
            redpanels[31] = panel32;
            redpanels[32] = panel33;
            redpanels[33] = panel34;
            redpanels[34] = panel35;
            redpanels[35] = panel36;
            redpanels[36] = panel37;
            redpanels[37] = panel38;
            redpanels[38] = panel39;
            redpanels[39] = panel40;
            redpanels[40] = panel41;
            redpanels[41] = panel42;
            redpanels[42] = panel43;
            redpanels[43] = panel44;
            redpanels[44] = panel45;
            redpanels[45] = panel46;
            redpanels[46] = panel47;
            redpanels[47] = panel48;
            redpanels[48] = panel49;
            redpanels[49] = panel50;

            bluepanels[0] = panel51;
            bluepanels[1] = panel52;
            bluepanels[2] = panel53;
            bluepanels[3] = panel54;
            bluepanels[4] = panel55;
            bluepanels[5] = panel56;
            bluepanels[6] = panel57;
            bluepanels[7] = panel58;
            bluepanels[8] = panel59;
            bluepanels[9] = panel60;
            bluepanels[10] = panel61;
            bluepanels[11] = panel62;
            bluepanels[12] = panel63;
            bluepanels[13] = panel64;
            bluepanels[14] = panel65;
            bluepanels[15] = panel66;
            bluepanels[16] = panel67;
            bluepanels[17] = panel68;
            bluepanels[18] = panel69;
            bluepanels[19] = panel70;
            bluepanels[20] = panel71;
            bluepanels[21] = panel72;
            bluepanels[22] = panel73;
            bluepanels[23] = panel74;
            bluepanels[24] = panel75;
            bluepanels[25] = panel76;
            bluepanels[26] = panel77;
            bluepanels[27] = panel78;
            bluepanels[28] = panel79;
            bluepanels[29] = panel80;
            bluepanels[30] = panel81;
            bluepanels[31] = panel82;
            bluepanels[32] = panel83;
            bluepanels[33] = panel84;
            bluepanels[34] = panel85;
            bluepanels[35] = panel86;
            bluepanels[36] = panel87;
            bluepanels[37] = panel88;
            bluepanels[38] = panel89;
            bluepanels[39] = panel90;
            bluepanels[40] = panel91;
            bluepanels[41] = panel92;
            bluepanels[42] = panel93;
            bluepanels[43] = panel94;
            bluepanels[44] = panel95;
            bluepanels[45] = panel96;
            bluepanels[46] = panel97;
            bluepanels[47] = panel98;
            bluepanels[48] = panel99;
            bluepanels[49] = panel100;
        }

    }


}

