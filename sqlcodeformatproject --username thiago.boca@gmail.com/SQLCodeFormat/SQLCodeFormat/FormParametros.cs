using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCodeFormat
{
    public partial class FormParametros : Form
    {
        public FormParametros()
        {
            InitializeComponent();
            //Define o metodo a ser executado no fechamento do form
            this.FormClosing += new FormClosingEventHandler(FormParametros_FormClosing);
            //se já foi criada uma configuração ele usa ela, senao usa a  padrao do form
            if (Parametros.configParametros._ExisteConfiguracao)
            {
                recuperarParametros();
            }
            else
            {
                definirParametros();
            }

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Define os parametros do usuario
        /// </summary>
        private void definirParametros()
        {
            Parametros.configParametros._IndentWidth = Convert.ToInt32(txt_IndentWidth.Text);
            Parametros.configParametros._MaxWidth = Convert.ToInt32(txt_MaxWidth.Text);
            Parametros.configParametros._StatementBreaks = Convert.ToInt32(txt_StatementBreaks.Text);
            Parametros.configParametros._ClauseBreaks = Convert.ToInt32(txt_ClauseBreaks.Text);
            Parametros.configParametros._ExpandCommaLists = chk_ExpandCommaLists.Checked;
            Parametros.configParametros._TrailingCommas = chk_TrailingCommas.Checked;
            Parametros.configParametros._SpaceAfterComma = chk_SpaceAfterComma.Checked;
            Parametros.configParametros._ExpandBooleanExpressions = chk_ExpandBooleanExpressions.Checked;
            Parametros.configParametros._ExpandCaseStatements = chk_ExpandCaseStatements.Checked;
            Parametros.configParametros._ExpandBetweenConditions = chk_ExpandBetweenConditions.Checked;
            Parametros.configParametros._ExpandInLists = chk_ExpandInLists.Checked;
            Parametros.configParametros._BreakJoinOnSections = chk_BreakJoinOnSections.Checked;
            Parametros.configParametros._UppercaseKeywords = chk_UppercaseKeywords.Checked;
            Parametros.configParametros._Coloring = chk_Coloring.Checked;
            Parametros.configParametros._EnableKeywordStandardization = chk_EnableKeywordStandardization.Checked;
            Parametros.configParametros._ExisteConfiguracao = true;
        }

        /// <summary>
        /// Recupera para os parametros do usuario
        /// </summary>
        private void recuperarParametros()
        {
            txt_IndentWidth.Text = Parametros.configParametros._IndentWidth.ToString();
            txt_MaxWidth.Text = Parametros.configParametros._MaxWidth.ToString();
            txt_StatementBreaks.Text = Parametros.configParametros._StatementBreaks.ToString();
            txt_ClauseBreaks.Text = Parametros.configParametros._ClauseBreaks.ToString();
            chk_ExpandCommaLists.Checked = Parametros.configParametros._ExpandCommaLists;
            chk_TrailingCommas.Checked = Parametros.configParametros._TrailingCommas;
            chk_SpaceAfterComma.Checked = Parametros.configParametros._SpaceAfterComma;
            chk_ExpandBooleanExpressions.Checked = Parametros.configParametros._ExpandBooleanExpressions;
            chk_ExpandCaseStatements.Checked = Parametros.configParametros._ExpandCaseStatements;
            chk_ExpandBetweenConditions.Checked = Parametros.configParametros._ExpandBetweenConditions;
            chk_ExpandInLists.Checked = Parametros.configParametros._ExpandInLists;
            chk_BreakJoinOnSections.Checked = Parametros.configParametros._BreakJoinOnSections;
            chk_UppercaseKeywords.Checked = Parametros.configParametros._UppercaseKeywords;
            chk_Coloring.Checked = Parametros.configParametros._Coloring;
            chk_EnableKeywordStandardization.Checked = Parametros.configParametros._EnableKeywordStandardization;
        }

        private void FormParametros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.definirParametros();
                MainForm.mainForm.SetFormatter();
                MainForm.mainForm.Enabled = true;
            }
        }
    }
}
