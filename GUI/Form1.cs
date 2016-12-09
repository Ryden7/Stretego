using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategoBoardBothPlayers
{
    public partial class Stratego : Form
    {
        //Lisa's Code
        private Dictionary<string, int> _redPlayer = new Dictionary<string, int>();
        private Dictionary<string, int> _bluePlayer = new Dictionary<string, int>();
        private List<Pieces> piecesLeftToPlaceRed = new List<Pieces>();
        private List<Pieces> piecesLeftToPlaceBlue = new List<Pieces>();
        private const string RedPlayer = "Red Player";
        private const string BluePlayer = "Blue Player";

        //Not Lisa's
        int counter = 1;
        Board gameboard = new Board();
        private int oldLocation;
        private int NewLocation;

        //Read write file
        //FileStream fileStream;

        //trying to get to the point where we only need one variable to determine which player is currently playing
        String player;
        Pieces currentplayer;

        //writing
        //System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\Users\\colli\\Source\\Repos\\Stretego3\\GUI\\TextFile1.txt");

        private Boolean gamehastarted;
        Panel[] redpanels = new Panel[50];
        Panel[] bluepanels = new Panel[50];

        public Stratego()
        {
            InitializeComponent();

            //Setup the local storage for count of game pieces
            SetupGamePieces();
            makePanelArray();
            TestSetUp();

            bluepanels[2].AllowDrop = false;
            bluepanels[3].AllowDrop = false;
            bluepanels[6].AllowDrop = false;
            bluepanels[7].AllowDrop = false;

            redpanels[42].AllowDrop = false;
            redpanels[43].AllowDrop = false;
            redpanels[46].AllowDrop = false;
            redpanels[47].AllowDrop = false;

            player = "Blue";

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
                String newoldlocation = oldLocation.ToString();
                System.IO.File.WriteAllText(@"C:\\Users\\colli\\Source\\Repos\\Stretego3\\GUI\\TextFile1.txt", newoldlocation);
                //modifyLocation(oldLocation, NewLocation);
            }/*else
            {
                oldLocation = panelChanger.TabIndex + 1;
                panelChanger_DragDrop(panelChanger, et);
            }*/
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

                if (!gamehastarted && panelChanger.BackgroundImage == null)
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
                /* else
                 {
                     throw (new Exception("Can't do that!"));

                 }*/
            }
            else
            {
                if (panelChanger.BackgroundImage == null)
                {
                    panelChanger.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
                    NewLocation = panelChanger.TabIndex + 1;
                    //String newoldlocation = File.ReadAllText(@"C:\\Users\\colli\\Source\\Repos\\Stretego3\\GUI\\TextFile1.txt");
                    //oldLocation = Int32.Parse(newoldlocation);
                   // File.Delete(@"C:\\Users\\colli\\Source\\Repos\\Stretego3\\GUI\\TextFile1.txt");

                    //update position
                    modifyLocation(oldLocation, NewLocation);
                }

                //else fight
                else
                {
                    //This is what is the battle logic for the GUI side.
                    NewLocation = panelChanger.TabIndex + 1;
                    String newoldlocation = File.ReadAllText(@"C:\\Users\\colli\\Source\\Repos\\Stretego3\\GUI\\TextFile1.txt");
                    oldLocation = Int32.Parse(newoldlocation);
                    currentplayer = gameboard.getPieceByPosition(oldLocation);
                    Pieces otherplayer = gameboard.getPieceByPosition(NewLocation);

                    File.WriteAllText(@"C:\\Users\\colli\\Source\\Repos\\Stretego3\\GUI\\TextFile1.txt","");
                   if (otherplayer.getColor() != currentplayer.getColor())
                    {
                        int battletype = gameboard.pieceLookup(oldLocation, NewLocation);

                        switch (battletype)
                        {
                            case 1:
                                panelChanger.AllowDrop = false;
                                break;
                            case 2:
                                panelChanger.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
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


            if (menuItem.Equals(marshalToolStripMenuItem1))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(0).maxPieceCount--;
            }

            if (menuItem.Equals(generalToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(1).maxPieceCount--;
            }

            if (menuItem.Equals(cononel2Of2ToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(2).maxPieceCount--;
            }

            if (menuItem.Equals(major3Of3ToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(3).maxPieceCount--;
            }

            if (menuItem.Equals(captain4Of4ToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(4).maxPieceCount--;
            }

            if (menuItem.Equals(lieutenant4Of4ToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(5).maxPieceCount--;
            }

            if (menuItem.Equals(sergent4Of4ToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(6).maxPieceCount--;
            }

            if (menuItem.Equals(miner5Of5ToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(7).maxPieceCount--;
            }

            if (menuItem.Equals(scout8Of8ToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(8).maxPieceCount--;
            }

            if (menuItem.Equals(spyToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(9).maxPieceCount--;
            }

            if (menuItem.Equals(flagToolStripMenuItem))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(10).maxPieceCount--;
            }

            if (menuItem.Equals(bombToolStripMenuItem1))
            {

                piecesLeftToPlaceRed.ElementAt<Pieces>(11).maxPieceCount--;
            }

            if (menuItem.Equals(marshalToolStripMenuItem))
            {
                piecesLeftToPlaceBlue.ElementAt(0).maxPieceCount--;
            }
            if (menuItem.Equals(general9ToolStripMenuItem))
            {
                piecesLeftToPlaceBlue.ElementAt<Pieces>(1).maxPieceCount--;
            }

            if (menuItem.Equals(cToolStripMenuItem))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(2).maxPieceCount--;
            }

            if (menuItem.Equals(major7ToolStripMenuItem))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(3).maxPieceCount--;
            }

            if (menuItem.Equals(captain6ToolStripMenuItem))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(4).maxPieceCount--;
            }

            if (menuItem.Equals(lieutenant5ToolStripMenuItem))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(5).maxPieceCount--;
            }

            if (menuItem.Equals(sergeant4ToolStripMenuItem))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(6).maxPieceCount--;
            }

            if (menuItem.Equals(miner3ToolStripMenuItem))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(7).maxPieceCount--;
            }

            if (menuItem.Equals(miner3ToolStripMenuItem1))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(8).maxPieceCount--;
            }

            if (menuItem.Equals(miner3ToolStripMenuItem2))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(9).maxPieceCount--;
            }

            if (menuItem.Equals(miner3ToolStripMenuItem3))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(10).maxPieceCount--;
            }

            if (menuItem.Equals(bombToolStripMenuItem))
            {

                piecesLeftToPlaceBlue.ElementAt<Pieces>(11).maxPieceCount--;
            }




            if (piecesLeftToPlaceRed.ElementAt<Pieces>(0).maxPieceCount < 1)
            {
                marshalToolStripMenuItem1.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(1).maxPieceCount < 1)
            {
                generalToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(2).maxPieceCount < 1)
            {
                cononel2Of2ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }

            if (piecesLeftToPlaceRed.ElementAt<Pieces>(3).maxPieceCount < 1)
            {
                major3Of3ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }

            if (piecesLeftToPlaceRed.ElementAt<Pieces>(4).maxPieceCount < 1)
            {
                captain4Of4ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(5).maxPieceCount < 1)
            {
                lieutenant4Of4ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(6).maxPieceCount < 1)
            {
                sergent4Of4ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(7).maxPieceCount < 1)
            {
                miner5Of5ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(8).maxPieceCount < 1)
            {
                scout8Of8ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(9).maxPieceCount < 1)
            {
                spyToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(10).maxPieceCount < 1)
            {
                flagToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceRed.ElementAt<Pieces>(11).maxPieceCount < 1)
            {
                bombToolStripMenuItem1.Enabled = false;
                this.Refresh();
            }
            /////
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(0).maxPieceCount < 1)
            {
                marshalToolStripMenuItem.Enabled = false;
                this.Refresh();
            }

            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(1).maxPieceCount < 1)
            {
                general9ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(2).maxPieceCount < 1)
            {
                cToolStripMenuItem.Enabled = false;
                this.Refresh();
            }

            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(3).maxPieceCount < 1)
            {
                major7ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }

            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(4).maxPieceCount < 1)
            {
                captain6ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(5).maxPieceCount < 1)
            {
                lieutenant5ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(6).maxPieceCount < 1)
            {
                sergeant4ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(7).maxPieceCount < 1)
            {
                miner3ToolStripMenuItem.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(8).maxPieceCount < 1)
            {
                miner3ToolStripMenuItem1.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(9).maxPieceCount < 1)
            {
                miner3ToolStripMenuItem2.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(10).maxPieceCount < 1)
            {
                miner3ToolStripMenuItem3.Enabled = false;
                this.Refresh();
            }
            if (piecesLeftToPlaceBlue.ElementAt<Pieces>(11).maxPieceCount < 1)
            {
                bombToolStripMenuItem.Enabled = false;
                this.Refresh();
            }

        }


        //private void panelChanger_MouseMove(object sender, MouseEventArgs e)
        //{
        //Panel panelChanger = sender as Panel;
        //Cursor.Current = new Cursor((Image)panelChanger.BackgroundImage);
        //}

        public void modifyLocation(int oldLocation, int newLocation)
        {
            gameboard.movePiece(oldLocation, NewLocation);
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

        private void AdjustGamePieces(string player, string gamePiece, ToolStripItem item)
        {
            int count = 0;
            if (player.Equals(RedPlayer))
            {
                var currVal = _redPlayer[gamePiece];
                count = currVal - 1;
                _redPlayer[gamePiece] = count;

            }
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
            _redPlayer.Add("Red", 9);
            piecesLeftToPlaceRed.Add(new Pieces(1, "Red", 0));//Marshell
            piecesLeftToPlaceRed.Add(new Pieces(2, "Red", 0));//General
            piecesLeftToPlaceRed.Add(new Pieces(3, "Red", 0));//Conel
            piecesLeftToPlaceRed.Add(new Pieces(5, "Red", 0));//Major
            piecesLeftToPlaceRed.Add(new Pieces(8, "Red", 0));//Captain
            piecesLeftToPlaceRed.Add(new Pieces(12, "Red", 0));//Lutenant
            piecesLeftToPlaceRed.Add(new Pieces(16, "Red", 0));//Sargent
            piecesLeftToPlaceRed.Add(new Pieces(20, "Red", 0));//Miner
            piecesLeftToPlaceRed.Add(new Pieces(25, "Red", 0));//Scout
            piecesLeftToPlaceRed.Add(new Pieces(33, "Red", 0));//Spy
            piecesLeftToPlaceRed.Add(new Pieces(34, "Red", 0));//Flag
            piecesLeftToPlaceRed.Add(new Pieces(35, "Red", 0));//Bomb

            _bluePlayer.Add("Blue", 9);
            piecesLeftToPlaceBlue.Add(new Pieces(1, "Blue", 0));//Marshell
            piecesLeftToPlaceBlue.Add(new Pieces(2, "Blue", 0));//General
            piecesLeftToPlaceBlue.Add(new Pieces(3, "Blue", 0));//Conel
            piecesLeftToPlaceBlue.Add(new Pieces(5, "Blue", 0));//Major
            piecesLeftToPlaceBlue.Add(new Pieces(8, "Blue", 0));//Captain
            piecesLeftToPlaceBlue.Add(new Pieces(12, "Blue", 0));//Lutenant
            piecesLeftToPlaceBlue.Add(new Pieces(16, "Blue", 0));//Sargent
            piecesLeftToPlaceBlue.Add(new Pieces(20, "Blue", 0));//Miner
            piecesLeftToPlaceBlue.Add(new Pieces(25, "Blue", 0));//Scout
            piecesLeftToPlaceBlue.Add(new Pieces(33, "Blue", 0));//Spy
            piecesLeftToPlaceBlue.Add(new Pieces(34, "Blue", 0));//Flag
            piecesLeftToPlaceBlue.Add(new Pieces(35, "Blue", 0));//Bomb

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

        public void TestSetUp()
        {
            counter = 80;
            gamehastarted = true;

            for (int i = 100; i > 60; i--)
            {
                gameboard.makePiece(i, "blue");
            }

            for (int i = 40; i > 0; i--)
            {
                gameboard.makePiece(i, "red");
            }

            panel100.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego10;
            panel99.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego9;
            panel98.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego8;
            panel97.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego8;
            panel96.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego7;
            panel95.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego7;
            panel94.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego7;
            panel93.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego6;
            panel92.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego6;
            panel91.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego6;
            panel90.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego6;
            panel89.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego5;
            panel88.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego5;
            panel87.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego5;
            panel86.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego5;
            panel85.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego4;
            panel84.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego4;
            panel83.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego4;
            panel82.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego4;
            panel81.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3;
            panel80.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3;
            panel79.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3;
            panel78.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3;
            panel77.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3;
            panel76.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel75.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel74.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel73.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel72.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel71.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel70.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel69.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2;
            panel68.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoS;
            panel67.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoF;
            panel66.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoB;
            panel65.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoB;
            panel64.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoB;
            panel63.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoB;
            panel62.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoB;
            panel61.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.StrategoB;


            panel40.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego10Red;
            panel39.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego9Red;
            panel38.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego8Red;
            panel37.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego8Red;
            panel36.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego7Red;
            panel35.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego7Red;
            panel34.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego7Red;
            panel33.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego6Red;
            panel32.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego6Red;
            panel31.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego6Red;
            panel30.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego6Red;
            panel29.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego5Red;
            panel28.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego5Red;
            panel27.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego5Red;
            panel26.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego5Red;
            panel25.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego4Red;
            panel24.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego4Red;
            panel23.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego4Red;
            panel22.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.stratego4Red;
            panel21.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3Red;
            panel20.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3Red;
            panel19.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3Red;
            panel18.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3Red;
            panel17.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego3Red;
            panel16.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel15.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel14.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel13.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel12.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel11.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel10.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel9.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.Stratego2Red;
            panel8.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoSpyRed;
            panel7.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoFlagRed;
            panel6.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoBRed;
            panel5.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoBRed;
            panel4.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoBRed;
            panel3.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoBRed;
            panel2.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoBRed;
            panel1.BackgroundImage = global::StrategoBoardBothPlayers.Properties.Resources.strategoBRed;


        }

        private void ChangePlayer_MouseClick(object sender, MouseEventArgs e)
        {
            if(player == "Blue")
            {
                foreach (Panel panel in bluepanels)
                {
                    if (panel.BackgroundImage != null)
                    {
                        panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                }

                foreach (Panel panel in redpanels)
                {
                    if(panel.BackgroundImage != null)
                    {
                        panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    }
                }

                player = "Red";

            }
            else
            {
                foreach (Panel panel in redpanels)
                {
                    if (panel.BackgroundImage != null)
                    {
                        panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                }

                foreach (Panel panel in bluepanels)
                {
                    if (panel.BackgroundImage != null)
                    {
                        panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    }
                }

                player = "Blue";
            }
        }
    }


}

