namespace DesignOfSCS
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStripButtons = new System.Windows.Forms.ToolStrip();
            this.buttonCursor = new System.Windows.Forms.ToolStripButton();
            this.buttonMain = new System.Windows.Forms.ToolStripButton();
            this.buttonNode = new System.Windows.Forms.ToolStripButton();
            this.buttonEdge = new System.Windows.Forms.ToolStripButton();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.labelWeight = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStripButtons.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1204, 28);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            this.menuStripMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripMain_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pictureBox);
            this.splitContainer.Panel1.Controls.Add(this.toolStripButtons);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.button1);
            this.splitContainer.Panel2.Controls.Add(this.groupBoxProperties);
            this.splitContainer.Size = new System.Drawing.Size(1204, 611);
            this.splitContainer.SplitterDistance = 850;
            this.splitContainer.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 27);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(850, 584);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // toolStripButtons
            // 
            this.toolStripButtons.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtons.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCursor,
            this.buttonMain,
            this.buttonNode,
            this.buttonEdge});
            this.toolStripButtons.Location = new System.Drawing.Point(0, 0);
            this.toolStripButtons.Name = "toolStripButtons";
            this.toolStripButtons.Size = new System.Drawing.Size(850, 27);
            this.toolStripButtons.TabIndex = 0;
            this.toolStripButtons.Text = "toolStrip1";
            // 
            // buttonCursor
            // 
            this.buttonCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCursor.Image = global::DesignOfSCS.Properties.Resources.cursor;
            this.buttonCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCursor.Name = "buttonCursor";
            this.buttonCursor.Size = new System.Drawing.Size(29, 24);
            this.buttonCursor.Text = "toolStripButton1";
            this.buttonCursor.Click += new System.EventHandler(this.buttonCursor_Click);
            // 
            // buttonMain
            // 
            this.buttonMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMain.Image = global::DesignOfSCS.Properties.Resources.main;
            this.buttonMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMain.Name = "buttonMain";
            this.buttonMain.Size = new System.Drawing.Size(29, 24);
            this.buttonMain.Text = "toolStripButton1";
            this.buttonMain.Click += new System.EventHandler(this.buttonMain_Click);
            // 
            // buttonNode
            // 
            this.buttonNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNode.Image = global::DesignOfSCS.Properties.Resources.komutator;
            this.buttonNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNode.Name = "buttonNode";
            this.buttonNode.Size = new System.Drawing.Size(29, 24);
            this.buttonNode.Text = "toolStripButton2";
            this.buttonNode.Click += new System.EventHandler(this.buttonNode_Click);
            // 
            // buttonEdge
            // 
            this.buttonEdge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEdge.Image = global::DesignOfSCS.Properties.Resources.edge;
            this.buttonEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEdge.Name = "buttonEdge";
            this.buttonEdge.Size = new System.Drawing.Size(29, 24);
            this.buttonEdge.Text = "toolStripButton3";
            this.buttonEdge.Click += new System.EventHandler(this.buttonEdge_Click);
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Controls.Add(this.textBoxWeight);
            this.groupBoxProperties.Controls.Add(this.labelWeight);
            this.groupBoxProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxProperties.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(350, 105);
            this.groupBoxProperties.TabIndex = 0;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(156, 50);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(121, 22);
            this.textBoxWeight.TabIndex = 1;
            this.textBoxWeight.TextChanged += new System.EventHandler(this.textBoxWeight_TextChanged);
            this.textBoxWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWeight_KeyDown);
            this.textBoxWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWeight_KeyPress);
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(64, 53);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(52, 17);
            this.labelWeight.TabIndex = 0;
            this.labelWeight.Text = "Weight";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "buttonConvert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 639);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStripMain);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Design of SCS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStripButtons.ResumeLayout(false);
            this.toolStripButtons.PerformLayout();
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStrip toolStripButtons;
        private System.Windows.Forms.ToolStripButton buttonCursor;
        private System.Windows.Forms.ToolStripButton buttonNode;
        private System.Windows.Forms.ToolStripButton buttonEdge;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.ToolStripButton buttonMain;
        private System.Windows.Forms.Button button1;
    }
}

