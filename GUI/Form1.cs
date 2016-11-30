﻿using System;
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
        Board board = new Board();
        public Stratego()
        {
            InitializeComponent();
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
                //This is calling the getColor method I will be making
                string color = getColor(panelChanger);
                //This calls the getValue method to determine the piece value
                int pieceValue = getValue(panelChanger);
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
    }
}
