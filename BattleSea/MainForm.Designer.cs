namespace BattleSea
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvMy = new System.Windows.Forms.DataGridView();
			this.colRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colA = new System.Windows.Forms.DataGridViewImageColumn();
			this.colB = new System.Windows.Forms.DataGridViewImageColumn();
			this.colC = new System.Windows.Forms.DataGridViewImageColumn();
			this.colD = new System.Windows.Forms.DataGridViewImageColumn();
			this.colE = new System.Windows.Forms.DataGridViewImageColumn();
			this.colF = new System.Windows.Forms.DataGridViewImageColumn();
			this.colG = new System.Windows.Forms.DataGridViewImageColumn();
			this.colH = new System.Windows.Forms.DataGridViewImageColumn();
			this.colI = new System.Windows.Forms.DataGridViewImageColumn();
			this.colJ = new System.Windows.Forms.DataGridViewImageColumn();
			this.dgvEnemy = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn8 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn9 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn10 = new System.Windows.Forms.DataGridViewImageColumn();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbPC = new System.Windows.Forms.TabPage();
			this.btnManual = new System.Windows.Forms.Button();
			this.btnRandomize = new System.Windows.Forms.Button();
			this.btnPCStart = new System.Windows.Forms.Button();
			this.tbLAN = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.lblHost = new System.Windows.Forms.Label();
			this.btnJoinGame = new System.Windows.Forms.Button();
			this.tbAddress = new System.Windows.Forms.TextBox();
			this.btnHostGame = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbMessages = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvMy)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvEnemy)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tbPC.SuspendLayout();
			this.tbLAN.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvMy
			// 
			this.dgvMy.AllowUserToAddRows = false;
			this.dgvMy.AllowUserToDeleteRows = false;
			this.dgvMy.AllowUserToResizeColumns = false;
			this.dgvMy.AllowUserToResizeRows = false;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvMy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.dgvMy.ColumnHeadersHeight = 24;
			this.dgvMy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvMy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRows,
            this.colA,
            this.colB,
            this.colC,
            this.colD,
            this.colE,
            this.colF,
            this.colG,
            this.colH,
            this.colI,
            this.colJ});
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvMy.DefaultCellStyle = dataGridViewCellStyle13;
			this.dgvMy.Location = new System.Drawing.Point(12, 12);
			this.dgvMy.MaximumSize = new System.Drawing.Size(266, 266);
			this.dgvMy.MinimumSize = new System.Drawing.Size(266, 266);
			this.dgvMy.MultiSelect = false;
			this.dgvMy.Name = "dgvMy";
			this.dgvMy.ReadOnly = true;
			this.dgvMy.RowHeadersVisible = false;
			this.dgvMy.RowHeadersWidth = 30;
			this.dgvMy.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.dgvMy.RowsDefaultCellStyle = dataGridViewCellStyle14;
			this.dgvMy.RowTemplate.Height = 24;
			this.dgvMy.RowTemplate.ReadOnly = true;
			this.dgvMy.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvMy.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.dgvMy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvMy.ShowCellErrors = false;
			this.dgvMy.ShowCellToolTips = false;
			this.dgvMy.ShowEditingIcon = false;
			this.dgvMy.ShowRowErrors = false;
			this.dgvMy.Size = new System.Drawing.Size(266, 266);
			this.dgvMy.TabIndex = 0;
			this.dgvMy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMy_CellClick);
			this.dgvMy.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMy_CellMouseClick);
			this.dgvMy.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMy_CellMouseClick);
			this.dgvMy.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMy_CellMouseEnter);
			// 
			// colRows
			// 
			this.colRows.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.colRows.FillWeight = 24F;
			this.colRows.Frozen = true;
			this.colRows.HeaderText = "";
			this.colRows.Name = "colRows";
			this.colRows.ReadOnly = true;
			this.colRows.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colRows.Width = 24;
			// 
			// colA
			// 
			this.colA.Frozen = true;
			this.colA.HeaderText = "A";
			this.colA.Name = "colA";
			this.colA.ReadOnly = true;
			this.colA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colA.Width = 24;
			// 
			// colB
			// 
			this.colB.Frozen = true;
			this.colB.HeaderText = "B";
			this.colB.Name = "colB";
			this.colB.ReadOnly = true;
			this.colB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colB.Width = 24;
			// 
			// colC
			// 
			this.colC.Frozen = true;
			this.colC.HeaderText = "C";
			this.colC.Name = "colC";
			this.colC.ReadOnly = true;
			this.colC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colC.Width = 24;
			// 
			// colD
			// 
			this.colD.Frozen = true;
			this.colD.HeaderText = "D";
			this.colD.Name = "colD";
			this.colD.ReadOnly = true;
			this.colD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colD.Width = 24;
			// 
			// colE
			// 
			this.colE.Frozen = true;
			this.colE.HeaderText = "E";
			this.colE.Name = "colE";
			this.colE.ReadOnly = true;
			this.colE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colE.Width = 24;
			// 
			// colF
			// 
			this.colF.Frozen = true;
			this.colF.HeaderText = "F";
			this.colF.Name = "colF";
			this.colF.ReadOnly = true;
			this.colF.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colF.Width = 24;
			// 
			// colG
			// 
			this.colG.Frozen = true;
			this.colG.HeaderText = "G";
			this.colG.Name = "colG";
			this.colG.ReadOnly = true;
			this.colG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colG.Width = 24;
			// 
			// colH
			// 
			this.colH.Frozen = true;
			this.colH.HeaderText = "H";
			this.colH.Name = "colH";
			this.colH.ReadOnly = true;
			this.colH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colH.Width = 24;
			// 
			// colI
			// 
			this.colI.Frozen = true;
			this.colI.HeaderText = "I";
			this.colI.Name = "colI";
			this.colI.ReadOnly = true;
			this.colI.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colI.Width = 24;
			// 
			// colJ
			// 
			this.colJ.Frozen = true;
			this.colJ.HeaderText = "J";
			this.colJ.Name = "colJ";
			this.colJ.ReadOnly = true;
			this.colJ.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colJ.Width = 24;
			// 
			// dgvEnemy
			// 
			this.dgvEnemy.AllowUserToAddRows = false;
			this.dgvEnemy.AllowUserToDeleteRows = false;
			this.dgvEnemy.AllowUserToResizeColumns = false;
			this.dgvEnemy.AllowUserToResizeRows = false;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvEnemy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
			this.dgvEnemy.ColumnHeadersHeight = 24;
			this.dgvEnemy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvEnemy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewImageColumn1,
            this.dataGridViewImageColumn2,
            this.dataGridViewImageColumn3,
            this.dataGridViewImageColumn4,
            this.dataGridViewImageColumn5,
            this.dataGridViewImageColumn6,
            this.dataGridViewImageColumn7,
            this.dataGridViewImageColumn8,
            this.dataGridViewImageColumn9,
            this.dataGridViewImageColumn10});
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvEnemy.DefaultCellStyle = dataGridViewCellStyle21;
			this.dgvEnemy.Location = new System.Drawing.Point(289, 12);
			this.dgvEnemy.MaximumSize = new System.Drawing.Size(266, 266);
			this.dgvEnemy.MinimumSize = new System.Drawing.Size(266, 266);
			this.dgvEnemy.MultiSelect = false;
			this.dgvEnemy.Name = "dgvEnemy";
			this.dgvEnemy.ReadOnly = true;
			this.dgvEnemy.RowHeadersVisible = false;
			this.dgvEnemy.RowHeadersWidth = 30;
			this.dgvEnemy.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.dgvEnemy.RowsDefaultCellStyle = dataGridViewCellStyle22;
			this.dgvEnemy.RowTemplate.Height = 24;
			this.dgvEnemy.RowTemplate.ReadOnly = true;
			this.dgvEnemy.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvEnemy.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.dgvEnemy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvEnemy.ShowCellErrors = false;
			this.dgvEnemy.ShowCellToolTips = false;
			this.dgvEnemy.ShowEditingIcon = false;
			this.dgvEnemy.ShowRowErrors = false;
			this.dgvEnemy.Size = new System.Drawing.Size(266, 266);
			this.dgvEnemy.TabIndex = 1;
			this.dgvEnemy.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvEnemy_CellMouseClick);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn1.FillWeight = 24F;
			this.dataGridViewTextBoxColumn1.Frozen = true;
			this.dataGridViewTextBoxColumn1.HeaderText = "";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Width = 24;
			// 
			// dataGridViewImageColumn1
			// 
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle16.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle16.NullValue")));
			this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewImageColumn1.Frozen = true;
			this.dataGridViewImageColumn1.HeaderText = "A";
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.ReadOnly = true;
			this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn1.Width = 24;
			// 
			// dataGridViewImageColumn2
			// 
			dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle17.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle17.NullValue")));
			this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewImageColumn2.Frozen = true;
			this.dataGridViewImageColumn2.HeaderText = "B";
			this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
			this.dataGridViewImageColumn2.ReadOnly = true;
			this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn2.Width = 24;
			// 
			// dataGridViewImageColumn3
			// 
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			dataGridViewCellStyle18.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle18.NullValue")));
			this.dataGridViewImageColumn3.DefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewImageColumn3.Frozen = true;
			this.dataGridViewImageColumn3.HeaderText = "C";
			this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
			this.dataGridViewImageColumn3.ReadOnly = true;
			this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn3.Width = 24;
			// 
			// dataGridViewImageColumn4
			// 
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			dataGridViewCellStyle19.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle19.NullValue")));
			this.dataGridViewImageColumn4.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridViewImageColumn4.Frozen = true;
			this.dataGridViewImageColumn4.HeaderText = "D";
			this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
			this.dataGridViewImageColumn4.ReadOnly = true;
			this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn4.Width = 24;
			// 
			// dataGridViewImageColumn5
			// 
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			dataGridViewCellStyle20.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle20.NullValue")));
			this.dataGridViewImageColumn5.DefaultCellStyle = dataGridViewCellStyle20;
			this.dataGridViewImageColumn5.Frozen = true;
			this.dataGridViewImageColumn5.HeaderText = "E";
			this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
			this.dataGridViewImageColumn5.ReadOnly = true;
			this.dataGridViewImageColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn5.Width = 24;
			// 
			// dataGridViewImageColumn6
			// 
			this.dataGridViewImageColumn6.Frozen = true;
			this.dataGridViewImageColumn6.HeaderText = "F";
			this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
			this.dataGridViewImageColumn6.ReadOnly = true;
			this.dataGridViewImageColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn6.Width = 24;
			// 
			// dataGridViewImageColumn7
			// 
			this.dataGridViewImageColumn7.Frozen = true;
			this.dataGridViewImageColumn7.HeaderText = "G";
			this.dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
			this.dataGridViewImageColumn7.ReadOnly = true;
			this.dataGridViewImageColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn7.Width = 24;
			// 
			// dataGridViewImageColumn8
			// 
			this.dataGridViewImageColumn8.Frozen = true;
			this.dataGridViewImageColumn8.HeaderText = "H";
			this.dataGridViewImageColumn8.Name = "dataGridViewImageColumn8";
			this.dataGridViewImageColumn8.ReadOnly = true;
			this.dataGridViewImageColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn8.Width = 24;
			// 
			// dataGridViewImageColumn9
			// 
			this.dataGridViewImageColumn9.Frozen = true;
			this.dataGridViewImageColumn9.HeaderText = "I";
			this.dataGridViewImageColumn9.Name = "dataGridViewImageColumn9";
			this.dataGridViewImageColumn9.ReadOnly = true;
			this.dataGridViewImageColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn9.Width = 24;
			// 
			// dataGridViewImageColumn10
			// 
			this.dataGridViewImageColumn10.Frozen = true;
			this.dataGridViewImageColumn10.HeaderText = "J";
			this.dataGridViewImageColumn10.Name = "dataGridViewImageColumn10";
			this.dataGridViewImageColumn10.ReadOnly = true;
			this.dataGridViewImageColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn10.Width = 24;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbPC);
			this.tabControl1.Controls.Add(this.tbLAN);
			this.tabControl1.Location = new System.Drawing.Point(12, 284);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(266, 104);
			this.tabControl1.TabIndex = 2;
			// 
			// tbPC
			// 
			this.tbPC.Controls.Add(this.btnPCStart);
			this.tbPC.Location = new System.Drawing.Point(4, 22);
			this.tbPC.Name = "tbPC";
			this.tbPC.Padding = new System.Windows.Forms.Padding(3);
			this.tbPC.Size = new System.Drawing.Size(258, 84);
			this.tbPC.TabIndex = 0;
			this.tbPC.Text = "Versus PC";
			this.tbPC.UseVisualStyleBackColor = true;
			// 
			// btnManual
			// 
			this.btnManual.Location = new System.Drawing.Point(104, 10);
			this.btnManual.Name = "btnManual";
			this.btnManual.Size = new System.Drawing.Size(75, 23);
			this.btnManual.TabIndex = 1;
			this.btnManual.Text = "Set manual";
			this.btnManual.UseVisualStyleBackColor = true;
			this.btnManual.Click += new System.EventHandler(this.BtnSetManual_Click);
			// 
			// btnRandomize
			// 
			this.btnRandomize.Location = new System.Drawing.Point(185, 10);
			this.btnRandomize.Name = "btnRandomize";
			this.btnRandomize.Size = new System.Drawing.Size(75, 23);
			this.btnRandomize.TabIndex = 1;
			this.btnRandomize.Text = "Randomize";
			this.btnRandomize.UseVisualStyleBackColor = true;
			this.btnRandomize.Click += new System.EventHandler(this.BtnRandomize_Click);
			// 
			// btnPCStart
			// 
			this.btnPCStart.Location = new System.Drawing.Point(177, 6);
			this.btnPCStart.Name = "btnPCStart";
			this.btnPCStart.Size = new System.Drawing.Size(75, 23);
			this.btnPCStart.TabIndex = 0;
			this.btnPCStart.Text = "Start";
			this.btnPCStart.UseVisualStyleBackColor = true;
			this.btnPCStart.Click += new System.EventHandler(this.BtnPCStart_Click);
			// 
			// tbLAN
			// 
			this.tbLAN.Controls.Add(this.label1);
			this.tbLAN.Controls.Add(this.tbPort);
			this.tbLAN.Controls.Add(this.lblHost);
			this.tbLAN.Controls.Add(this.btnJoinGame);
			this.tbLAN.Controls.Add(this.tbAddress);
			this.tbLAN.Controls.Add(this.btnHostGame);
			this.tbLAN.Location = new System.Drawing.Point(4, 22);
			this.tbLAN.Name = "tbLAN";
			this.tbLAN.Padding = new System.Windows.Forms.Padding(3);
			this.tbLAN.Size = new System.Drawing.Size(258, 78);
			this.tbLAN.TabIndex = 1;
			this.tbLAN.Text = "Game on LAN";
			this.tbLAN.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(142, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Port";
			// 
			// tbPort
			// 
			this.tbPort.Location = new System.Drawing.Point(145, 19);
			this.tbPort.Name = "tbPort";
			this.tbPort.Size = new System.Drawing.Size(107, 20);
			this.tbPort.TabIndex = 1;
			this.tbPort.Text = "2604";
			// 
			// lblHost
			// 
			this.lblHost.AutoSize = true;
			this.lblHost.Location = new System.Drawing.Point(6, 3);
			this.lblHost.Name = "lblHost";
			this.lblHost.Size = new System.Drawing.Size(45, 13);
			this.lblHost.TabIndex = 1;
			this.lblHost.Text = "Address";
			// 
			// btnJoinGame
			// 
			this.btnJoinGame.Location = new System.Drawing.Point(177, 45);
			this.btnJoinGame.Name = "btnJoinGame";
			this.btnJoinGame.Size = new System.Drawing.Size(75, 23);
			this.btnJoinGame.TabIndex = 0;
			this.btnJoinGame.Text = "Join";
			this.btnJoinGame.UseVisualStyleBackColor = true;
			this.btnJoinGame.Click += new System.EventHandler(this.BtnJoinGame_Click);
			// 
			// tbAddress
			// 
			this.tbAddress.Location = new System.Drawing.Point(9, 19);
			this.tbAddress.Name = "tbAddress";
			this.tbAddress.Size = new System.Drawing.Size(130, 20);
			this.tbAddress.TabIndex = 1;
			this.tbAddress.Text = "127.0.0.1";
			// 
			// btnHostGame
			// 
			this.btnHostGame.Location = new System.Drawing.Point(93, 45);
			this.btnHostGame.Name = "btnHostGame";
			this.btnHostGame.Size = new System.Drawing.Size(75, 23);
			this.btnHostGame.TabIndex = 0;
			this.btnHostGame.Text = "Host";
			this.btnHostGame.UseVisualStyleBackColor = true;
			this.btnHostGame.Click += new System.EventHandler(this.BtnHostGame_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbMessages);
			this.groupBox1.Location = new System.Drawing.Point(289, 284);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 145);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Messages";
			// 
			// tbMessages
			// 
			this.tbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMessages.Location = new System.Drawing.Point(3, 16);
			this.tbMessages.Multiline = true;
			this.tbMessages.Name = "tbMessages";
			this.tbMessages.Size = new System.Drawing.Size(258, 126);
			this.tbMessages.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnRandomize);
			this.groupBox2.Controls.Add(this.btnManual);
			this.groupBox2.Location = new System.Drawing.Point(12, 390);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(266, 39);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Set ships";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(565, 441);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.dgvEnemy);
			this.Controls.Add(this.dgvMy);
			this.MaximumSize = new System.Drawing.Size(581, 480);
			this.MinimumSize = new System.Drawing.Size(581, 480);
			this.Name = "MainForm";
			this.Text = "BattleSea";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvMy)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvEnemy)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tbPC.ResumeLayout(false);
			this.tbLAN.ResumeLayout(false);
			this.tbLAN.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.DataGridView dgvMy;
		private System.Windows.Forms.DataGridView dgvEnemy;
		private System.Windows.Forms.DataGridViewTextBoxColumn colRows;
		private System.Windows.Forms.DataGridViewImageColumn colA;
		private System.Windows.Forms.DataGridViewImageColumn colB;
		private System.Windows.Forms.DataGridViewImageColumn colC;
		private System.Windows.Forms.DataGridViewImageColumn colD;
		private System.Windows.Forms.DataGridViewImageColumn colE;
		private System.Windows.Forms.DataGridViewImageColumn colF;
		private System.Windows.Forms.DataGridViewImageColumn colG;
		private System.Windows.Forms.DataGridViewImageColumn colH;
		private System.Windows.Forms.DataGridViewImageColumn colI;
		private System.Windows.Forms.DataGridViewImageColumn colJ;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn6;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn7;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn8;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn9;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn10;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbPC;
		private System.Windows.Forms.TabPage tbLAN;
		private System.Windows.Forms.Button btnPCStart;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbMessages;
		private System.Windows.Forms.Button btnRandomize;
		private System.Windows.Forms.Button btnManual;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbPort;
		private System.Windows.Forms.Label lblHost;
		private System.Windows.Forms.Button btnJoinGame;
		private System.Windows.Forms.TextBox tbAddress;
		private System.Windows.Forms.Button btnHostGame;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}

