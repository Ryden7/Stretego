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
        private Dictionary<string, int> _redPlayer = new Dictionary<string, int>();
        private Dictionary<string, int> _bluePlayer = new Dictionary<string, int>();
        private List<Pieces> piecesLeftToPlaceRed = new List<Pieces>();
        private List<Pieces> piecesLeftToPlaceBlue = new List<Pieces>();
        private const string RedPlayer = "Red Player";
        private const string BluePlayer = "Blue Player";



        int counter;
        Board gameboard = new Board();
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

            if (counter < 80)
            {
                // if (!DoPiecesExist(player, gamePiece)) throw new Exception(String.Format("Out of {0}", gamePiece));

                if (panelChanger.BackgroundImage == null)
                {
                    panelChanger.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
                    gameboard.makePiece(panelChanger.TabIndex + 1);
                    counter++;
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
                    //update position
                }

                //else fight
                else
                {

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

        public int getValue(Panel panel)
        {
            int panelValue = 0;
            if (panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.Stratego10 || panel.BackgroundImage == global::StrategoBoardBothPlayers.Properties.Resources.stratego10Red)
            {
                return 10;
            }

            return panelValue;
        }


        private string GetGamePiece(string itemName)
        {
            string gamePiece = String.Empty;
            switch (itemName)
            {
                case "general9ToolStripMenuItem":
                    gamePiece = "General";
                    break;
                case "marshalToolStripMenuItem":
                    gamePiece = "Marshal";
                    break;

            }

            return gamePiece;

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


        private void button2_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  richTextBox2.Text = (textBox1.Text);
        }


    }


}


