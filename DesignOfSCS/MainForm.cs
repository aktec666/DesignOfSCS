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
        private bool mainServerState = false;
        private graph.Graph graph;
        private Graphics g;
        private List<GraphObject> objects = new List<GraphObject>();
        private GraphObject currentObj = null;

        private Node from = null;

        public MainForm()
        {
            graph = new Graph();
            InitializeComponent();
        }

        private void menuStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonCursor.Checked = true;
            buttonNode.Checked = false;
            buttonEdge.Checked = false;
            textBoxWeight.Enabled = false;
            g = pictureBox.CreateGraphics();
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Node n = graph.CreateNewNode(e.Location, false);
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
                        bool p = true;
                        foreach(var x in  graph.Edges)
                        {
                            if(x.From == from && x.To == n || x.From == n && x.To == from)
                            {
                                p = false;
                                break;
                            }
                        }
                        if (p)
                        {
                            Edge edge = graph.CreateNewEdge(from, n);
                            edge.Selected += Edge_Selected;
                            edge.Deselected += Edge_Deselected;
                            objects.Add(edge);
                        }
                        from = null;
                        n.Deselect();
                    }
                }
            }
            else if (buttonNode.Checked)
            {

            }
            textBoxWeight.Text = "";
            textBoxWeight.Enabled = false;
            currentObj = n;
        }

        private void Edge_Selected(object sender)
        {
            Edge e = (Edge)sender;
            textBoxWeight.Enabled = true;
            textBoxWeight.Text = e.Weight.ToString();
            currentObj = e;
        }

        private void Edge_Deselected(object sender)
        {
            textBoxWeight.Text = "";
            textBoxWeight.Enabled = false;
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
                    Node n = graph.CreateNewNode(e.Location, false);
                    n.Draw(g);
                    n.Selected += Node_Selected;
                    n.Deselected += Node_Deselected;
                    objects.Insert(0, n);
                }
                else if (buttonMain.Checked)
                {
                    if (mainServerState == true)
                    {
                        MessageBox.Show("Error! Only one master server may be present");
                    }
                    else
                    {
                        mainServerState = true;
                        Node n = graph.CreateNewNode(e.Location, true);
                        n.Draw(g);
                        n.Selected += Node_Selected;
                        n.Deselected += Node_Deselected;
                        objects.Insert(0, n);
                    }
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
            g = pictureBox.CreateGraphics();
            Repaint();
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
            buttonMain.Checked = false;
        }

        private void buttonNode_Click(object sender, EventArgs e)
        {
            buttonCursor.Checked = false;
            buttonEdge.Checked = false;
            buttonNode.Checked = true;
            buttonMain.Checked = false;
        }

        private void buttonEdge_Click(object sender, EventArgs e)
        {
            buttonCursor.Checked = false;
            buttonEdge.Checked = true;
            buttonNode.Checked = false;
            buttonMain.Checked = false;
            from = null;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (currentObj != null)
                {
                    if (currentObj is Node)
                    {
                        if((currentObj as Node).IsServer)
                            mainServerState = false;
                        graph.DeleteNode((Node)currentObj);
                    }
                    else
                        graph.DeleteEdge((Edge)currentObj);
                    objects.Remove(currentObj);
                    Repaint();
                }
                Console.WriteLine("Delete");
            }
        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {
            if (currentObj != null && currentObj is Edge)
            {
                int w;
                if (int.TryParse(textBoxWeight.Text, out w))
                {
                    ((Edge)currentObj).Weight = w;
                    Repaint();
                }
            }
        }

        private void textBoxWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxWeight_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            buttonCursor.Checked = false;
            buttonEdge.Checked = false;
            buttonNode.Checked = false;
            buttonMain.Checked = true;
        }
    }
}
