using System.Windows.Forms;
namespace SQLCodeFormat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabLinguagem = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textVB = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textSQL = new System.Windows.Forms.RichTextBox();
            this.btnVBtoSQL = new System.Windows.Forms.Button();
            this.btnSQLtoVB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridParametros = new System.Windows.Forms.DataGridView();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnLimparColar = new System.Windows.Forms.Button();
            this.btnCopiarSQL = new System.Windows.Forms.Button();
            this.btnFormatarSQL = new System.Windows.Forms.Button();
            this.txtVariavel = new System.Windows.Forms.TextBox();
            this.labelAlerta = new System.Windows.Forms.Label();
            this.timerAlerta = new System.Windows.Forms.Timer(this.components);
            this.tabLinguagem.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParametros)).BeginInit();
            this.SuspendLayout();
            // 
            // tabLinguagem
            // 
            this.tabLinguagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabLinguagem.Controls.Add(this.tabPage1);
            this.tabLinguagem.Controls.Add(this.tabPage2);
            this.tabLinguagem.Location = new System.Drawing.Point(0, 42);
            this.tabLinguagem.Name = "tabLinguagem";
            this.tabLinguagem.SelectedIndex = 0;
            this.tabLinguagem.Size = new System.Drawing.Size(824, 645);
            this.tabLinguagem.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabLinguagem.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textVB);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 619);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Código VB";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textVB
            // 
            this.textVB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textVB.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVB.Location = new System.Drawing.Point(3, 3);
            this.textVB.Name = "textVB";
            this.textVB.Size = new System.Drawing.Size(810, 613);
            this.textVB.TabIndex = 1;
            this.textVB.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textSQL);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 622);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comando SQL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textSQL
            // 
            this.textSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSQL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSQL.Location = new System.Drawing.Point(3, 3);
            this.textSQL.Name = "textSQL";
            this.textSQL.Size = new System.Drawing.Size(810, 616);
            this.textSQL.TabIndex = 1;
            this.textSQL.Text = "";
            // 
            // btnVBtoSQL
            // 
            this.btnVBtoSQL.Location = new System.Drawing.Point(12, 12);
            this.btnVBtoSQL.Name = "btnVBtoSQL";
            this.btnVBtoSQL.Size = new System.Drawing.Size(91, 23);
            this.btnVBtoSQL.TabIndex = 1;
            this.btnVBtoSQL.Text = "VB  ->  SQL";
            this.btnVBtoSQL.UseVisualStyleBackColor = true;
            this.btnVBtoSQL.Click += new System.EventHandler(this.btnVBtoSQL_Click);
            // 
            // btnSQLtoVB
            // 
            this.btnSQLtoVB.Location = new System.Drawing.Point(109, 12);
            this.btnSQLtoVB.Name = "btnSQLtoVB";
            this.btnSQLtoVB.Size = new System.Drawing.Size(90, 23);
            this.btnSQLtoVB.TabIndex = 2;
            this.btnSQLtoVB.Text = "  VB  <-  SQL";
            this.btnSQLtoVB.UseVisualStyleBackColor = true;
            this.btnSQLtoVB.Click += new System.EventHandler(this.btnSQLtoVB_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gridParametros);
            this.panel1.Location = new System.Drawing.Point(830, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 623);
            this.panel1.TabIndex = 3;
            // 
            // gridParametros
            // 
            this.gridParametros.AllowUserToAddRows = false;
            this.gridParametros.AllowUserToDeleteRows = false;
            this.gridParametros.AllowUserToResizeRows = false;
            this.gridParametros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParametros.Location = new System.Drawing.Point(3, 3);
            this.gridParametros.MultiSelect = false;
            this.gridParametros.Name = "gridParametros";
            this.gridParametros.RowHeadersWidth = 7;
            this.gridParametros.Size = new System.Drawing.Size(369, 617);
            this.gridParametros.TabIndex = 0;
            this.gridParametros.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParametros_CellEndEdit);
            this.gridParametros.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParametros_CellEnter);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(464, 12);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 4;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnLimparColar
            // 
            this.btnLimparColar.Location = new System.Drawing.Point(545, 12);
            this.btnLimparColar.Name = "btnLimparColar";
            this.btnLimparColar.Size = new System.Drawing.Size(113, 23);
            this.btnLimparColar.TabIndex = 5;
            this.btnLimparColar.Text = "Limpar e Colar (VB)";
            this.btnLimparColar.UseVisualStyleBackColor = true;
            this.btnLimparColar.Click += new System.EventHandler(this.btnLimparColar_Click);
            // 
            // btnCopiarSQL
            // 
            this.btnCopiarSQL.Location = new System.Drawing.Point(664, 12);
            this.btnCopiarSQL.Name = "btnCopiarSQL";
            this.btnCopiarSQL.Size = new System.Drawing.Size(75, 23);
            this.btnCopiarSQL.TabIndex = 6;
            this.btnCopiarSQL.Text = "Copiar SQL";
            this.btnCopiarSQL.UseVisualStyleBackColor = true;
            this.btnCopiarSQL.Click += new System.EventHandler(this.btnCopiarSQL_Click);
            // 
            // btnFormatarSQL
            // 
            this.btnFormatarSQL.Location = new System.Drawing.Point(745, 12);
            this.btnFormatarSQL.Name = "btnFormatarSQL";
            this.btnFormatarSQL.Size = new System.Drawing.Size(90, 23);
            this.btnFormatarSQL.TabIndex = 7;
            this.btnFormatarSQL.Text = "Formatar SQL";
            this.btnFormatarSQL.UseVisualStyleBackColor = true;
            this.btnFormatarSQL.Click += new System.EventHandler(this.btnFormatarSQL_Click);
            // 
            // txtVariavel
            // 
            this.txtVariavel.Location = new System.Drawing.Point(205, 14);
            this.txtVariavel.Name = "txtVariavel";
            this.txtVariavel.Size = new System.Drawing.Size(100, 20);
            this.txtVariavel.TabIndex = 8;
            this.txtVariavel.Text = "glbSQL";
            // 
            // labelAlerta
            // 
            this.labelAlerta.AutoSize = true;
            this.labelAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlerta.ForeColor = System.Drawing.Color.Red;
            this.labelAlerta.Location = new System.Drawing.Point(830, 42);
            this.labelAlerta.Name = "labelAlerta";
            this.labelAlerta.Size = new System.Drawing.Size(299, 13);
            this.labelAlerta.TabIndex = 9;
            this.labelAlerta.Text = "Comando SQL copiado para Área de Transferência!";
            this.labelAlerta.Visible = false;
            // 
            // timerAlerta
            // 
            this.timerAlerta.Interval = 5000;
            this.timerAlerta.Tick += new System.EventHandler(this.timerAlerta_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 690);
            this.Controls.Add(this.labelAlerta);
            this.Controls.Add(this.txtVariavel);
            this.Controls.Add(this.btnFormatarSQL);
            this.Controls.Add(this.btnCopiarSQL);
            this.Controls.Add(this.btnLimparColar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSQLtoVB);
            this.Controls.Add(this.btnVBtoSQL);
            this.Controls.Add(this.tabLinguagem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1228, 360);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extrator SQL - Beta release - [thiago.oechsler@govbr.com.br]   [georgio.schulze@g" +
    "ovbr.com.br]   [rafael.semann@govbr.com.br]";
            this.tabLinguagem.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridParametros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabLinguagem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnVBtoSQL;
        private System.Windows.Forms.Button btnSQLtoVB;
        private System.Windows.Forms.Panel panel1;
        private DataGridView gridParametros;
        private RichTextBox textSQL;
        private Button btnLimpar;
        private Button btnLimparColar;
        private Button btnCopiarSQL;
        private Button btnFormatarSQL;
        private RichTextBox textVB;
        private TextBox txtVariavel;
        private Label labelAlerta;
        private Timer timerAlerta;
    }
}

