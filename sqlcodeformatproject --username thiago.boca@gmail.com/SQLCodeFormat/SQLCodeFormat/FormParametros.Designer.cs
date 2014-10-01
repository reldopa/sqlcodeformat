namespace SQLCodeFormat
{
    partial class FormParametros
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grp_Options = new System.Windows.Forms.GroupBox();
            this.chk_BreakJoinOnSections = new System.Windows.Forms.CheckBox();
            this.chk_ExpandInLists = new System.Windows.Forms.CheckBox();
            this.chk_EnableKeywordStandardization = new System.Windows.Forms.CheckBox();
            this.txt_ClauseBreaks = new System.Windows.Forms.TextBox();
            this.lbl_ClauseBreaks = new System.Windows.Forms.Label();
            this.txt_StatementBreaks = new System.Windows.Forms.TextBox();
            this.lbl_StatementBreaks = new System.Windows.Forms.Label();
            this.txt_MaxWidth = new System.Windows.Forms.TextBox();
            this.lbl_MaxWidth = new System.Windows.Forms.Label();
            this.txt_IndentWidth = new System.Windows.Forms.TextBox();
            this.lbl_IndentWidth = new System.Windows.Forms.Label();
            this.chk_ExpandBetweenConditions = new System.Windows.Forms.CheckBox();
            this.chk_SpaceAfterComma = new System.Windows.Forms.CheckBox();
            this.chk_Coloring = new System.Windows.Forms.CheckBox();
            this.chk_UppercaseKeywords = new System.Windows.Forms.CheckBox();
            this.chk_ExpandCaseStatements = new System.Windows.Forms.CheckBox();
            this.chk_ExpandBooleanExpressions = new System.Windows.Forms.CheckBox();
            this.chk_TrailingCommas = new System.Windows.Forms.CheckBox();
            this.chk_ExpandCommaLists = new System.Windows.Forms.CheckBox();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grp_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(482, 435);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Formatting Options";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grp_Options, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 413);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // grp_Options
            // 
            this.grp_Options.Controls.Add(this.chk_BreakJoinOnSections);
            this.grp_Options.Controls.Add(this.chk_ExpandInLists);
            this.grp_Options.Controls.Add(this.chk_EnableKeywordStandardization);
            this.grp_Options.Controls.Add(this.txt_ClauseBreaks);
            this.grp_Options.Controls.Add(this.lbl_ClauseBreaks);
            this.grp_Options.Controls.Add(this.txt_StatementBreaks);
            this.grp_Options.Controls.Add(this.lbl_StatementBreaks);
            this.grp_Options.Controls.Add(this.txt_MaxWidth);
            this.grp_Options.Controls.Add(this.lbl_MaxWidth);
            this.grp_Options.Controls.Add(this.txt_IndentWidth);
            this.grp_Options.Controls.Add(this.lbl_IndentWidth);
            this.grp_Options.Controls.Add(this.chk_ExpandBetweenConditions);
            this.grp_Options.Controls.Add(this.chk_SpaceAfterComma);
            this.grp_Options.Controls.Add(this.chk_Coloring);
            this.grp_Options.Controls.Add(this.chk_UppercaseKeywords);
            this.grp_Options.Controls.Add(this.chk_ExpandCaseStatements);
            this.grp_Options.Controls.Add(this.chk_ExpandBooleanExpressions);
            this.grp_Options.Controls.Add(this.chk_TrailingCommas);
            this.grp_Options.Controls.Add(this.chk_ExpandCommaLists);
            this.grp_Options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Options.Location = new System.Drawing.Point(3, 28);
            this.grp_Options.Name = "grp_Options";
            this.grp_Options.Size = new System.Drawing.Size(470, 382);
            this.grp_Options.TabIndex = 4;
            this.grp_Options.TabStop = false;
            this.grp_Options.Text = "Standard Formatting Options";
            // 
            // chk_BreakJoinOnSections
            // 
            this.chk_BreakJoinOnSections.AutoSize = true;
            this.chk_BreakJoinOnSections.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_BreakJoinOnSections.Location = new System.Drawing.Point(8, 281);
            this.chk_BreakJoinOnSections.Name = "chk_BreakJoinOnSections";
            this.chk_BreakJoinOnSections.Size = new System.Drawing.Size(139, 17);
            this.chk_BreakJoinOnSections.TabIndex = 18;
            this.chk_BreakJoinOnSections.Text = "Break Join ON Sections";
            this.chk_BreakJoinOnSections.UseVisualStyleBackColor = true;
            // 
            // chk_ExpandInLists
            // 
            this.chk_ExpandInLists.AutoSize = true;
            this.chk_ExpandInLists.Checked = true;
            this.chk_ExpandInLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ExpandInLists.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_ExpandInLists.Location = new System.Drawing.Point(8, 258);
            this.chk_ExpandInLists.Name = "chk_ExpandInLists";
            this.chk_ExpandInLists.Size = new System.Drawing.Size(100, 17);
            this.chk_ExpandInLists.TabIndex = 17;
            this.chk_ExpandInLists.Text = "Expand IN Lists";
            this.chk_ExpandInLists.UseVisualStyleBackColor = true;
            // 
            // chk_EnableKeywordStandardization
            // 
            this.chk_EnableKeywordStandardization.AutoSize = true;
            this.chk_EnableKeywordStandardization.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_EnableKeywordStandardization.Location = new System.Drawing.Point(8, 350);
            this.chk_EnableKeywordStandardization.Name = "chk_EnableKeywordStandardization";
            this.chk_EnableKeywordStandardization.Size = new System.Drawing.Size(179, 17);
            this.chk_EnableKeywordStandardization.TabIndex = 17;
            this.chk_EnableKeywordStandardization.Text = "Enable Keyword Standardization";
            this.chk_EnableKeywordStandardization.UseVisualStyleBackColor = true;
            // 
            // txt_ClauseBreaks
            // 
            this.txt_ClauseBreaks.Location = new System.Drawing.Point(116, 95);
            this.txt_ClauseBreaks.Name = "txt_ClauseBreaks";
            this.txt_ClauseBreaks.Size = new System.Drawing.Size(38, 20);
            this.txt_ClauseBreaks.TabIndex = 16;
            this.txt_ClauseBreaks.Text = "1";
            // 
            // lbl_ClauseBreaks
            // 
            this.lbl_ClauseBreaks.AutoSize = true;
            this.lbl_ClauseBreaks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_ClauseBreaks.Location = new System.Drawing.Point(7, 98);
            this.lbl_ClauseBreaks.Name = "lbl_ClauseBreaks";
            this.lbl_ClauseBreaks.Size = new System.Drawing.Size(78, 13);
            this.lbl_ClauseBreaks.TabIndex = 15;
            this.lbl_ClauseBreaks.Text = "Clause Breaks:";
            // 
            // txt_StatementBreaks
            // 
            this.txt_StatementBreaks.Location = new System.Drawing.Point(116, 71);
            this.txt_StatementBreaks.Name = "txt_StatementBreaks";
            this.txt_StatementBreaks.Size = new System.Drawing.Size(38, 20);
            this.txt_StatementBreaks.TabIndex = 16;
            this.txt_StatementBreaks.Text = "2";
            // 
            // lbl_StatementBreaks
            // 
            this.lbl_StatementBreaks.AutoSize = true;
            this.lbl_StatementBreaks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_StatementBreaks.Location = new System.Drawing.Point(7, 73);
            this.lbl_StatementBreaks.Name = "lbl_StatementBreaks";
            this.lbl_StatementBreaks.Size = new System.Drawing.Size(94, 13);
            this.lbl_StatementBreaks.TabIndex = 15;
            this.lbl_StatementBreaks.Text = "Statement Breaks:";
            // 
            // txt_MaxWidth
            // 
            this.txt_MaxWidth.Location = new System.Drawing.Point(77, 46);
            this.txt_MaxWidth.Name = "txt_MaxWidth";
            this.txt_MaxWidth.Size = new System.Drawing.Size(77, 20);
            this.txt_MaxWidth.TabIndex = 16;
            this.txt_MaxWidth.Text = "999";
            // 
            // lbl_MaxWidth
            // 
            this.lbl_MaxWidth.AutoSize = true;
            this.lbl_MaxWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_MaxWidth.Location = new System.Drawing.Point(7, 49);
            this.lbl_MaxWidth.Name = "lbl_MaxWidth";
            this.lbl_MaxWidth.Size = new System.Drawing.Size(61, 13);
            this.lbl_MaxWidth.TabIndex = 15;
            this.lbl_MaxWidth.Text = "Max Width:";
            // 
            // txt_IndentWidth
            // 
            this.txt_IndentWidth.Location = new System.Drawing.Point(86, 20);
            this.txt_IndentWidth.Name = "txt_IndentWidth";
            this.txt_IndentWidth.Size = new System.Drawing.Size(33, 20);
            this.txt_IndentWidth.TabIndex = 14;
            this.txt_IndentWidth.Text = "4";
            // 
            // lbl_IndentWidth
            // 
            this.lbl_IndentWidth.AutoSize = true;
            this.lbl_IndentWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_IndentWidth.Location = new System.Drawing.Point(9, 23);
            this.lbl_IndentWidth.Name = "lbl_IndentWidth";
            this.lbl_IndentWidth.Size = new System.Drawing.Size(71, 13);
            this.lbl_IndentWidth.TabIndex = 13;
            this.lbl_IndentWidth.Text = "Indent Width:";
            // 
            // chk_ExpandBetweenConditions
            // 
            this.chk_ExpandBetweenConditions.AutoSize = true;
            this.chk_ExpandBetweenConditions.Checked = true;
            this.chk_ExpandBetweenConditions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ExpandBetweenConditions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_ExpandBetweenConditions.Location = new System.Drawing.Point(9, 234);
            this.chk_ExpandBetweenConditions.Name = "chk_ExpandBetweenConditions";
            this.chk_ExpandBetweenConditions.Size = new System.Drawing.Size(171, 17);
            this.chk_ExpandBetweenConditions.TabIndex = 10;
            this.chk_ExpandBetweenConditions.Text = "Expand BETWEEN Conditions";
            this.chk_ExpandBetweenConditions.UseVisualStyleBackColor = true;
            // 
            // chk_SpaceAfterComma
            // 
            this.chk_SpaceAfterComma.AutoSize = true;
            this.chk_SpaceAfterComma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_SpaceAfterComma.Location = new System.Drawing.Point(42, 165);
            this.chk_SpaceAfterComma.Name = "chk_SpaceAfterComma";
            this.chk_SpaceAfterComma.Size = new System.Drawing.Size(120, 17);
            this.chk_SpaceAfterComma.TabIndex = 9;
            this.chk_SpaceAfterComma.Text = "Space After Comma";
            this.chk_SpaceAfterComma.UseVisualStyleBackColor = true;
            // 
            // chk_Coloring
            // 
            this.chk_Coloring.AutoSize = true;
            this.chk_Coloring.Checked = true;
            this.chk_Coloring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Coloring.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_Coloring.Location = new System.Drawing.Point(8, 327);
            this.chk_Coloring.Name = "chk_Coloring";
            this.chk_Coloring.Size = new System.Drawing.Size(100, 17);
            this.chk_Coloring.TabIndex = 8;
            this.chk_Coloring.Text = "Enable Coloring";
            this.chk_Coloring.UseVisualStyleBackColor = true;
            // 
            // chk_UppercaseKeywords
            // 
            this.chk_UppercaseKeywords.AutoSize = true;
            this.chk_UppercaseKeywords.Checked = true;
            this.chk_UppercaseKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UppercaseKeywords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_UppercaseKeywords.Location = new System.Drawing.Point(8, 304);
            this.chk_UppercaseKeywords.Name = "chk_UppercaseKeywords";
            this.chk_UppercaseKeywords.Size = new System.Drawing.Size(127, 17);
            this.chk_UppercaseKeywords.TabIndex = 7;
            this.chk_UppercaseKeywords.Text = "Uppercase Keywords";
            this.chk_UppercaseKeywords.UseVisualStyleBackColor = true;
            // 
            // chk_ExpandCaseStatements
            // 
            this.chk_ExpandCaseStatements.AutoSize = true;
            this.chk_ExpandCaseStatements.Checked = true;
            this.chk_ExpandCaseStatements.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ExpandCaseStatements.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_ExpandCaseStatements.Location = new System.Drawing.Point(9, 211);
            this.chk_ExpandCaseStatements.Name = "chk_ExpandCaseStatements";
            this.chk_ExpandCaseStatements.Size = new System.Drawing.Size(149, 17);
            this.chk_ExpandCaseStatements.TabIndex = 6;
            this.chk_ExpandCaseStatements.Text = "Expand CASE Statements";
            this.chk_ExpandCaseStatements.UseVisualStyleBackColor = true;
            // 
            // chk_ExpandBooleanExpressions
            // 
            this.chk_ExpandBooleanExpressions.AutoSize = true;
            this.chk_ExpandBooleanExpressions.Checked = true;
            this.chk_ExpandBooleanExpressions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ExpandBooleanExpressions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_ExpandBooleanExpressions.Location = new System.Drawing.Point(9, 188);
            this.chk_ExpandBooleanExpressions.Name = "chk_ExpandBooleanExpressions";
            this.chk_ExpandBooleanExpressions.Size = new System.Drawing.Size(163, 17);
            this.chk_ExpandBooleanExpressions.TabIndex = 5;
            this.chk_ExpandBooleanExpressions.Text = "Expand Boolean Expressions";
            this.chk_ExpandBooleanExpressions.UseVisualStyleBackColor = true;
            // 
            // chk_TrailingCommas
            // 
            this.chk_TrailingCommas.AutoSize = true;
            this.chk_TrailingCommas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_TrailingCommas.Location = new System.Drawing.Point(42, 142);
            this.chk_TrailingCommas.Name = "chk_TrailingCommas";
            this.chk_TrailingCommas.Size = new System.Drawing.Size(103, 17);
            this.chk_TrailingCommas.TabIndex = 4;
            this.chk_TrailingCommas.Text = "Trailing Commas";
            this.chk_TrailingCommas.UseVisualStyleBackColor = true;
            // 
            // chk_ExpandCommaLists
            // 
            this.chk_ExpandCommaLists.AutoSize = true;
            this.chk_ExpandCommaLists.Checked = true;
            this.chk_ExpandCommaLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ExpandCommaLists.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chk_ExpandCommaLists.Location = new System.Drawing.Point(9, 119);
            this.chk_ExpandCommaLists.Name = "chk_ExpandCommaLists";
            this.chk_ExpandCommaLists.Size = new System.Drawing.Size(124, 17);
            this.chk_ExpandCommaLists.TabIndex = 3;
            this.chk_ExpandCommaLists.Text = "Expand Comma Lists";
            this.chk_ExpandCommaLists.UseVisualStyleBackColor = true;
            // 
            // FormParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 438);
            this.Controls.Add(this.groupBox5);
            this.Name = "FormParametros";
            this.Text = "FormParametros";
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grp_Options.ResumeLayout(false);
            this.grp_Options.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grp_Options;
        private System.Windows.Forms.CheckBox chk_BreakJoinOnSections;
        private System.Windows.Forms.CheckBox chk_ExpandInLists;
        private System.Windows.Forms.CheckBox chk_EnableKeywordStandardization;
        private System.Windows.Forms.TextBox txt_ClauseBreaks;
        private System.Windows.Forms.Label lbl_ClauseBreaks;
        private System.Windows.Forms.TextBox txt_StatementBreaks;
        private System.Windows.Forms.Label lbl_StatementBreaks;
        private System.Windows.Forms.TextBox txt_MaxWidth;
        private System.Windows.Forms.Label lbl_MaxWidth;
        private System.Windows.Forms.TextBox txt_IndentWidth;
        private System.Windows.Forms.Label lbl_IndentWidth;
        private System.Windows.Forms.CheckBox chk_ExpandBetweenConditions;
        private System.Windows.Forms.CheckBox chk_SpaceAfterComma;
        private System.Windows.Forms.CheckBox chk_Coloring;
        private System.Windows.Forms.CheckBox chk_UppercaseKeywords;
        private System.Windows.Forms.CheckBox chk_ExpandCaseStatements;
        private System.Windows.Forms.CheckBox chk_ExpandBooleanExpressions;
        private System.Windows.Forms.CheckBox chk_TrailingCommas;
        private System.Windows.Forms.CheckBox chk_ExpandCommaLists;
    }
}