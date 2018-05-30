namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.比赛结果 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gailv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kaili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peilv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peifulv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peilvchazhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xiangduipeilv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gailvchazhi1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gailvchazhi2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupid,
            this.比赛结果,
            this.color,
            this.id,
            this.gailv,
            this.kaili,
            this.peilv,
            this.peifulv,
            this.peilvchazhi,
            this.xiangduipeilv,
            this.gailvchazhi1,
            this.gailvchazhi2});
            this.dataGridView1.Location = new System.Drawing.Point(1, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(843, 461);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // groupid
            // 
            this.groupid.DataPropertyName = "groupid";
            this.groupid.HeaderText = "小组编号";
            this.groupid.Name = "groupid";
            this.groupid.ReadOnly = true;
            this.groupid.Visible = false;
            // 
            // 比赛结果
            // 
            this.比赛结果.DataPropertyName = "result";
            this.比赛结果.HeaderText = "比赛结果";
            this.比赛结果.Name = "比赛结果";
            this.比赛结果.ReadOnly = true;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "颜色";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // gailv
            // 
            this.gailv.DataPropertyName = "gailv";
            this.gailv.HeaderText = "概率";
            this.gailv.Name = "gailv";
            this.gailv.ReadOnly = true;
            // 
            // kaili
            // 
            this.kaili.DataPropertyName = "kaili";
            this.kaili.HeaderText = "凯利";
            this.kaili.Name = "kaili";
            this.kaili.ReadOnly = true;
            // 
            // peilv
            // 
            this.peilv.DataPropertyName = "peilv";
            this.peilv.HeaderText = "赔率";
            this.peilv.Name = "peilv";
            this.peilv.ReadOnly = true;
            // 
            // peifulv
            // 
            this.peifulv.DataPropertyName = "peifulv";
            this.peifulv.HeaderText = "赔付率";
            this.peifulv.Name = "peifulv";
            this.peifulv.ReadOnly = true;
            // 
            // peilvchazhi
            // 
            this.peilvchazhi.DataPropertyName = "peilvchazhi";
            this.peilvchazhi.HeaderText = "赔率差值";
            this.peilvchazhi.Name = "peilvchazhi";
            this.peilvchazhi.ReadOnly = true;
            // 
            // xiangduipeilv
            // 
            this.xiangduipeilv.DataPropertyName = "xiangduipeilv";
            this.xiangduipeilv.HeaderText = "相对赔付率";
            this.xiangduipeilv.Name = "xiangduipeilv";
            this.xiangduipeilv.ReadOnly = true;
            // 
            // gailvchazhi1
            // 
            this.gailvchazhi1.DataPropertyName = "gailvchazhi1";
            this.gailvchazhi1.HeaderText = "概率差值1";
            this.gailvchazhi1.Name = "gailvchazhi1";
            this.gailvchazhi1.ReadOnly = true;
            // 
            // gailvchazhi2
            // 
            this.gailvchazhi2.DataPropertyName = "gailvchazhi2";
            this.gailvchazhi2.HeaderText = "概率差值2";
            this.gailvchazhi2.Name = "gailvchazhi2";
            this.gailvchazhi2.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加数据ToolStripMenuItem,
            this.批量添加ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.删除数据ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 添加数据ToolStripMenuItem
            // 
            this.添加数据ToolStripMenuItem.Name = "添加数据ToolStripMenuItem";
            this.添加数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加数据ToolStripMenuItem.Text = "添加数据";
            this.添加数据ToolStripMenuItem.Click += new System.EventHandler(this.添加数据ToolStripMenuItem_Click);
            // 
            // 批量添加ToolStripMenuItem
            // 
            this.批量添加ToolStripMenuItem.Name = "批量添加ToolStripMenuItem";
            this.批量添加ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.批量添加ToolStripMenuItem.Text = "批量添加";
            this.批量添加ToolStripMenuItem.Click += new System.EventHandler(this.批量添加ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 删除数据ToolStripMenuItem
            // 
            this.删除数据ToolStripMenuItem.Name = "删除数据ToolStripMenuItem";
            this.删除数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除数据ToolStripMenuItem.Text = "删除数据";
            this.删除数据ToolStripMenuItem.Click += new System.EventHandler(this.删除数据ToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "查找相似";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(190, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "0.05";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(127, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "相似度：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.label1, "选中数据的列和与数据库数据列和的差值");
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "提示";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "刷新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改ToolStripMenuItem.Text = "修改结果";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 516);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "赔率计算工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除数据ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupid;
        private System.Windows.Forms.DataGridViewTextBoxColumn 比赛结果;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gailv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kaili;
        private System.Windows.Forms.DataGridViewTextBoxColumn peilv;
        private System.Windows.Forms.DataGridViewTextBoxColumn peifulv;
        private System.Windows.Forms.DataGridViewTextBoxColumn peilvchazhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn xiangduipeilv;
        private System.Windows.Forms.DataGridViewTextBoxColumn gailvchazhi1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gailvchazhi2;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
    }
}

