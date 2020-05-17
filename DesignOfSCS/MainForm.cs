using DesignOfSCS.graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesignOfSCS
{
    public partial class MainForm : Form
    {
        private graph.Graph graph;
        private Graphics g;
        private List<GraphObject> objects = new List<GraphObject>();
        private GraphObject currentObj = null;

        private Node from = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void menuStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            graph = new Graph();
            buttonCursor.Checked = true;
            buttonNode.Checked = false;
            buttonEdge.Checked = false;
            g = pictureBox.CreateGraphics();
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Node n = graph.CreateNewNode(e.Location);
                n.Draw(g);
                n.Selected += Node_Selected;
                n.Deselected += Node_Deselected;
                objects.Insert(0, n);
            }
        }

        private void Node_Deselected(object sender)
        {
            currentObj = null;
        }

        private void Node_Selected(object sender)
        {
            Node n = (Node)sender;
            if (buttonCursor.Checked)
            {
            }
            else if (buttonEdge.Checked)
            {
                if (from == null)
                {
                    from = n;
                }
                else
                {
                    if (from == n)
                    {
                        n.Deselect();
                        from = null;
                    }
                    else
                    {
                        Edge edge = graph.CreateNewEdge(from, n);
                        edge.Selected += Edge_Selected;
                        edge.Deselected += Edge_Deselected;
                        objects.Add(edge);
                        from = null;
                        n.Deselect();
                    }
                }
            }
            else if (buttonNode.Checked)
            {

            }
            currentObj = n;
        }

        private void Edge_Selected(object sender)
        {
            Edge e = (Edge)sender;
            currentObj = e;
        }

        private void Edge_Deselected(object sender)
        {
            currentObj = null;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (buttonCursor.Checked || buttonEdge.Checked)
                {
                    foreach (GraphObject obj in objects)
                        obj.Deselect();
                    foreach (GraphObject obj in objects)
                    {
                        if (obj.IsOnHover(e))
                        {
                            obj.OnMouseClick(e);
                            break;
                        }
                    }
                    Repaint();
                }
                else if (buttonNode.Checked)
                {
                    Node n = graph.CreateNewNode(e.Location);
                    n.Draw(g);
                    n.Selected += Node_Selected;
                    n.Deselected += Node_Deselected;
                    objects.Insert(0, n);
                }
            }
        }

        public void Repaint()
        {
            g.Clear(Color.White);
            graph.Draw(g);
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
         //   g = pictureBox.CreateGraphics();
         //   Repaint();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (buttonCursor.Checked)
                {
                    if (currentObj != null)
                        currentObj.Deselect();
                    foreach (GraphObject obj in objects)
                    {
                        if (obj is Node && obj.IsOnHover(e))
                        {
                            obj.Deselect();
                            ((Node)obj).OnMove(e.Location);
                            break;
                        }
                    }
                    Repaint();
                }
                else if (buttonNode.Checked)
                {

                }
                else if (buttonEdge.Checked)
                {
                }
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);
            graph.Draw(g);
        }

        private void buttonCursor_Click(object sender, EventArgs e)
        {
            buttonCursor.Checked = true;
            buttonEdge.Checked = false;
            buttonNode.Checked = false;
        }

        private void buttonNode_Click(object sender, EventArgs e)
        {
            buttonCursor.Checked = false;
            buttonEdge.Checked = false;
            buttonNode.Checked = true;
        }

        private void buttonEdge_Click(object sender, EventArgs e)
        {
            buttonCursor.Checked = false;
            buttonEdge.Checked = true;
            buttonNode.Checked = false;
            from = null;
        }
    }
}
