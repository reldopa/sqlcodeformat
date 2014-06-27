using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

//using gudusoft.gsqlparser;
//using gudusoft.gsqlparser.Units;
using PoorMansTSqlFormatterLib.Interfaces;


namespace SQLCodeFormat
{
    public partial class MainForm : Form
    {
        const string ERROSQL = "ERRO NO PROCESSAMENTO SQL"; //string padrão de erro
        string SQLTratado = "";  //SQL "puro" depois de ser separado do código VB6
        int paramtag = 0; //parametros muito grandes recebem numeração e nomenclatura padrão
        List<ParametrosSQL> paramList = new List<ParametrosSQL>(); //lista global de parâmetros encontrados no SQL

        PoorMansTSqlFormatterLib.Interfaces.ISqlTokenizer _tokenizer;
        PoorMansTSqlFormatterLib.Interfaces.ISqlTokenParser _parser;
        PoorMansTSqlFormatterLib.Interfaces.ISqlTreeFormatter _formatter;

        public MainForm()
        {
            InitializeComponent();

            _tokenizer = new PoorMansTSqlFormatterLib.Tokenizers.TSqlStandardTokenizer();
            _parser = new PoorMansTSqlFormatterLib.Parsers.TSqlStandardParser();
            
            SetFormatter();
        }

        private void SetFormatter()
        {
            PoorMansTSqlFormatterLib.Interfaces.ISqlTreeFormatter innerFormatter;

            innerFormatter = new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatter(new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatterOptions
            {
                IndentString = "  ",
                SpacesPerTab = 4,
                MaxLineWidth = Properties.Settings.Default.MaxWidth,
                ExpandCommaLists = Properties.Settings.Default.ExpandCommaLists,
                TrailingCommas = Properties.Settings.Default.TrailingCommas,
                SpaceAfterExpandedComma = Properties.Settings.Default.SpaceAfterComma,
                ExpandBooleanExpressions = Properties.Settings.Default.ExpandBooleanExpressions,
                ExpandCaseStatements = Properties.Settings.Default.ExpandCaseStatements,
                ExpandBetweenConditions = Properties.Settings.Default.ExpandBetweenConditions,
                ExpandInLists = Properties.Settings.Default.ExpandInLists,
                BreakJoinOnSections = Properties.Settings.Default.BreakJoinOnSections,
                UppercaseKeywords = Properties.Settings.Default.UppercaseKeywords,
                HTMLColoring = Properties.Settings.Default.IdentityColoring,
                KeywordStandardization = Properties.Settings.Default.KeywordSubstitution,
                NewStatementLineBreaks = Properties.Settings.Default.NewStatementLineBreaks,
                NewClauseLineBreaks = Properties.Settings.Default.NewClauseLineBreaks
            });

            innerFormatter.ErrorOutputPrefix = ERROSQL + Environment.NewLine;
            _formatter = new PoorMansTSqlFormatterLib.Formatters.HtmlPageWrapper(innerFormatter);
        }

        private void btnVBtoSQL_Click(object sender, EventArgs e)
        {
            if (!textVB.Text.Trim().Equals(""))
            {
                paramList.Clear();
                gridParametros.DataSource = null;
                textSQL.Text = FormatVBtoSQL();
                tabLinguagem.SelectedTab = tabPage2;

                //Todo o texto para preto
                textSQL.SelectionStart = 0;
                textSQL.SelectionLength = textSQL.Text.Length;
                textSQL.SelectionColor = Color.Black;

                if (paramList.Count > 0)
                {
                    //Formata o grid de parâmetros
                    gridParametros.DataSource = paramList;
                    gridParametros.Refresh();
                    gridParametros.Columns[0].Visible = false;
                    gridParametros.Columns[1].ReadOnly = true;
                    gridParametros.Columns[3].Visible = false;
                    gridParametros.Columns[4].Visible = false;
                    gridParametros.Columns[1].Width = 200;
                    gridParametros.Columns[2].Width = 160;

                    gridParametros.Columns[1].Name = "Parâmetro";
                    gridParametros.Columns[2].Name = "Valor";
                }
                
                //Pinta os tokens e parametros do comando SQL
                HighlightParams();  //Deixa mais legível
            }
        }

        private void btnSQLtoVB_Click(object sender, EventArgs e)
        {
            if (!textSQL.Text.Trim().Equals(""))
            {
                textVB.Text = FormatSQLtoVB();
                tabLinguagem.SelectedTab = tabPage1;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (tabLinguagem.SelectedTab == tabLinguagem.TabPages["tabPage1"])
            {
                if (!textVB.Text.Trim().Equals(""))
                {
                    var confirmResult = MessageBox.Show("O código VB será apagado, deseja continuar?",
                                "Confirmação",
                                MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.No)
                    {
                        return;
                    }
                }
                textVB.Clear();
            }
            else
            {
                if (!textSQL.Text.Trim().Equals(""))
                {
                    var confirmResult = MessageBox.Show("O comando SQL será apagado, deseja continuar?",
                                "Confirmação",
                                MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.No)
                    {
                        return;
                    }
                }

                textSQL.Clear();
                paramList.Clear();
                gridParametros.DataSource = null;
            }
        }

        [STAThread]
        private void btnLimparColar_Click(object sender, EventArgs e)
        {
            if (tabLinguagem.SelectedTab == tabLinguagem.TabPages["tabPage2"])
            {
                tabLinguagem.SelectedTab = tabPage1;
            }

            if (!textVB.Text.Trim().Equals(""))
            {
                var confirmResult = MessageBox.Show("O código VB será substituído, deseja continuar?",
                            "Área de transferência",
                            MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }
            }

            textVB.Clear();
            textVB.Text = Clipboard.GetText();
        }

        [STAThread]
        private void btnCopiarSQL_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();

            DataObject data = new DataObject();
            data.SetData(DataFormats.Text, textSQL.Text);
            data.SetData(DataFormats.Rtf, textSQL.Rtf);

            Clipboard.SetDataObject(data);
        }

        private void btnFormatarSQL_Click(object sender, EventArgs e)
        {
            //Dispara o formatador do SQL
            SQLTratado = " " + DoFormatting(textSQL.Text);

            //Substitui caracteres especiais de HTML
            SQLTratado = SQLTratado.Replace("&lt;", "<");
            SQLTratado = SQLTratado.Replace("&gt;", ">");
            SQLTratado = SQLTratado.Replace("&amp;", "&");

            //Adiciona um espaço em branco no final de cada linha
            //(Truque para facilitar pintar o texto)
            SQLTratado = SQLTratado.Replace("\r\n", " \r\n");
            SQLTratado = SQLTratado.Replace(" ! ", "!");

            textSQL.Text = SQLTratado;

            HighlightParams();
        }

        //gudusoft.gsqlparser.dll
        #region Formatador gudusoft.gsqlparser.dll
        //private string GDUFormat(string sql)
        //{
        //    TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVMssql);
        //    sqlparser.SqlText.Text = sql;
        //    int i = sqlparser.PrettyPrint();
        //    if (i == 0)
        //    {
        //        return sqlparser.FormattedSqlText.Text;
        //    }
        //    else
        //    {
        //        return sqlparser.ErrorMessages;
        //    }

        //    webBrowser1.DocumentText = sqlparser.ToHtml(TOutputFmt.ofhtml);
        //}
        #endregion

        //PoorMansTSQLFormatter
        #region Formatador PoorMansTSQLFormatter
        private string DoFormatting(string sql)
        {
            var tokenizedSql = _tokenizer.TokenizeSQL(sql);

            string prettiprint = tokenizedSql.PrettyPrint();

            var parsedSql = _parser.ParseSQL(tokenizedSql);

            string outerxml = parsedSql.OuterXml;

            string html = _formatter.FormatSQLTree(parsedSql);

            int init = html.IndexOf("<pre class=\"SQLCode\">") + 21;
            int count = html.IndexOf("</pre>") - (html.IndexOf("<pre class=\"SQLCode\">") + 21);

            return html.Substring(init, count);
        }
        #endregion

        public string FormatSQLtoVB()
        {
            List<string> linhas = new List<string>(textSQL.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

            string resultado = "glbSQL = \"\"" + Environment.NewLine;

            return linhas.Aggregate(resultado, (current, t) => current + ("glbSQL = glbSQL & \"" + t + "\" " + Environment.NewLine));
        }

        public string FormatVBtoSQL()
        {
            const String FORMAT = " & Format(";
            const String IIF = " & IIf(";
            const String IN = " IN \" &";
            const String MID = " & Mid(";
            String resultado = "";
            int linecount = 0;
            int iifcount = 0;

            string preText = textVB.Text.Replace("#", "");

            List<string> linhas = new List<string>(preText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            string linhaanterior = "";

            for (int i = 0; i < linhas.Count; i++)
            {
                String linha = " " + linhas[i].Trim();
                String conteudo = "";

                //Trata linhas que continuam (usando caractere "_")
                #region Trata linhas que continuam (caractere "_")
                if ((linha.IndexOf("\" _") > 0) || (linha.IndexOf(" & _") > 0) || (linha.IndexOf(" + _") > 0))
                {
                    linhaanterior += linha.Trim();
                    continue;
                }
                else
                {
                    linha = linhaanterior + (!linhaanterior.Equals("") ? linha.Trim() : linha); 
                    
                    linha = linha.Replace(" & _", "");
                    linha = linha.Replace(" + _", "");
                    linha = linha.Replace("\" _& \"", "");
                    linha = linha.Replace("\" _", "\"");
                    linha = linha.Replace("\" & \"","");

                    //if (!linhaanterior.Equals(""))
                    //{
                    //    linha = linha.Replace("\"&\"", "");
                    //}
                    
                    linhaanterior = "";
                }
                #endregion

                //Replaces
                #region Replace String
                linha = linha.Replace("& \"\"\"\" &", "");
                linha = linha.Replace("& \"\"\"\"", "");

                linha = linha.Replace("& \"\" &", "");
                linha = linha.Replace(" & \"\"", "");
                linha = linha.Replace("\"\"", "");

                linha = linha.Replace("& supDuplicaAspas(IIf(", "& IIf((");
                linha = linha.Replace("& Trim(IIf(", "& IIf((");
                linha = linha.Replace("& supConverteNumeroFormatoAmericano(IIf(", "& IIf((");
                linha = linha.Replace("& funSQLAjustaString(IIf(", "& IIf((");
                #endregion

                //Retira comentários da linha
                #region Retira comentários da linha
                if (linha.IndexOf("'", StringComparison.Ordinal) > 0)
                {
                    int count = linha.Count(c => c == '\'');

                    //Se impar indica que contém comentário
                    if (count%2 != 0)
                    {
                        //Busca o último caracter ' pois indica o começo do cometário
                        int last = linha.LastIndexOf("'", StringComparison.Ordinal);
                        linha = linha.Remove(last);
                    }
                }
                #endregion

                //Tramento de números concatenados na string
                #region Tramento de números concatenados na string
                if ((linha.IndexOf('"') < 0) || ((linha.IndexOf('\'') >= 0) && (linha.IndexOf('\'') < linha.IndexOf('"'))))
                {
                    if (linha.IndexOf("If ", StringComparison.CurrentCultureIgnoreCase) > 0
                        || linha.IndexOf("Else", StringComparison.CurrentCultureIgnoreCase) > 0
                        || linha.IndexOf("End If", StringComparison.CurrentCultureIgnoreCase) > 0
                        || string.IsNullOrEmpty(Regex.Match(linha, @"\d+").Value))
                    {
                        continue;
                    }

                    linecount++;
                    resultado += Regex.Match(linha, @"\d+").Value + Environment.NewLine;
                    continue;
                }
                #endregion

                //Testa se a string da linha tem fechamento
                if (linha.IndexOf('"') == linha.LastIndexOf('"'))
                {
                    throw new Exception("Linha " + i + " não finaliza string do comando SQL.");
                }

                //Testa se a string faz parte de uma instrução IF
                if ((linha.IndexOf('"') > linha.IndexOf(" If ", System.StringComparison.CurrentCultureIgnoreCase)) &&
                    (linha.LastIndexOf('"') < linha.IndexOf("Then", System.StringComparison.CurrentCultureIgnoreCase)))
                {
                    continue;
                }

                //Pega instruções após o Then
                if (linha.IndexOf("Then") >= 0)
                {
                    linha = linha.Substring(linha.IndexOf("Then") + 4).Trim();
                }
                //Tratamento da instrução IIF do VB6
                #region Tratamento da instrução IIF do VB6
                if (linha.IndexOf(IIF) >= 0)
                {
                    while (linha.IndexOf(IIF) >= 0)
                    {
                        int ap = 1; //Abre parenteses
                        int fp = 0; //Fecha parenteses
                        int iif = linha.IndexOf(IIF);
                        String linhaFim = linha.Substring(iif + IIF.Length, linha.Length - (iif + IIF.Length));
                        linha = linha.Substring(0, iif - 1);

                        for (int y = 0; y < linhaFim.Length; y++)
                        {
                            //Encontra o parêntese de fechamento do comando
                            if (linhaFim[y] == '(') { ap++; }
                            if (linhaFim[y] == ')') { fp++; }
                            //Se o qtd parenteses de abertura = qtd parenteses de fechamento
                            if (ap == fp)
                            {
                                ParametrosSQL pp = new ParametrosSQL(IIF.Substring(3, 4) + linhaFim.Substring(0, y - 1), "", ap, linecount, "#ifvar" + iifcount++);

                                AddParametro(pp);
                                if ((linhaFim.Length - 1) != y)
                                {
                                    //Verifica se ainda tem instrucao SQL apos o IIF
                                    if (linhaFim.Substring(y + 1, linhaFim.Length - y - 1).IndexOf("& \"") >= 0)
                                    {
                                        linha += pp.tag + linhaFim.Substring(y + 5, (linhaFim.Length - y) - 5);
                                    }
                                    else
                                    {
                                        linha += pp.tag + "\""; //Senão fecha a string
                                    }

                                }
                                else
                                {
                                    //IIF vai até o final da linha, fecha a string
                                    linha += pp.tag + '"';
                                }
                                break;
                            }
                        }
                    }
                }
                #endregion

                //Tratamento da instrução Format do VB6
                #region Tratamento da instrução Format do VB6
                if (linha.IndexOf(FORMAT) >= 0)
                {
                    while (linha.IndexOf(FORMAT) >= 0)
                    {
                        int ap = 1; //Abre parenteses
                        int fp = 0; //Fecha parenteses
                        int vp = 0; //Posição da vírgula
                        int fmt = linha.IndexOf(FORMAT);
                        String linhaFim = linha.Substring(fmt + FORMAT.Length, linha.Length - (fmt + FORMAT.Length));
                        linha = linha.Substring(0, fmt - 1);

                        for (int y = 0; y < linhaFim.Length; y++)
                        {
                            //Encontra o parêntese de fechamento do comando
                            if (linhaFim[y] == '(') { ap++; }
                            if (linhaFim[y] == ')') { fp++; }
                            if ((linhaFim[y] == ',') && (vp == 0)) { vp = y; }
                            //Se o qtd parenteses de abertura = qtd parenteses de fechamento
                            if (ap == fp)
                            {
                                ParametrosSQL pp = new ParametrosSQL(linhaFim.Substring(0, vp), "", vp, linecount);

                                AddParametro(pp);
                                if ((linhaFim.Length - 1) != y)
                                {
                                    //Verifica se ainda tem instrucao SQL apos o FORMAT
                                    if (linhaFim.Substring(y + 1, linhaFim.Length - y - 1).IndexOf("& \"") >= 0)
                                    {
                                        linha += pp.tag + linhaFim.Substring(y + 5, (linhaFim.Length - y) - 5);
                                    }
                                    else
                                    {
                                        linha += pp.tag + '"'; //Senão fecha a string
                                    }
                                }
                                else
                                {
                                    //FORMAT vai até o final da linha, fecha a string
                                    linha += pp.tag + '"';
                                }
                                break;
                            }
                        }
                    }
                }
                #endregion

                //Tratamento da instrução Mid do VB6
                #region Tratamento da instrução Mid do VB6
                if (linha.IndexOf(MID) >= 0)
                {
                    while (linha.IndexOf(MID) >= 0)
                    {
                        int ap = 1; //Abre parenteses
                        int fp = 0; //Fecha parenteses
                        int v1p = 0; //Posição da primeira vírgula
                        int mid = linha.IndexOf(MID);
                        String linhaFim = linha.Substring(mid + MID.Length, linha.Length - (mid + MID.Length));
                        linha = linha.Substring(0, mid - 1);

                        for (int y = 0; y < linhaFim.Length; y++)
                        {
                            if (linhaFim[y] == '(') { ap++; }
                            if (linhaFim[y] == ')') { fp++; }
                            if ((linhaFim[y] == ',') && (v1p == 0)) { v1p = y; }
                            if (ap == fp)
                            {
                                ParametrosSQL pp = new ParametrosSQL(linhaFim.Substring(0, v1p), "", v1p, linecount);

                                AddParametro(pp);
                                if ((linhaFim.Length - 1) != y)
                                {
                                    //Verifica se ainda tem instrucao SQL apos o MID
                                    if (linhaFim.Substring(y + 1, linhaFim.Length - y - 1).IndexOf("& \"") >= 0)
                                    {
                                        linha += pp.tag + linhaFim.Substring(y + 5, (linhaFim.Length - y) - 5);
                                    }
                                    else
                                    {
                                        linha += pp.tag + '"'; //Senão fecha a string
                                    }
                                }
                                else
                                {
                                    //MID vai até o final da linha, fecha a string
                                    linha += pp.tag + '"';
                                }
                                break;
                            }
                        }
                    }
                }
                #endregion

                //Testa se sobrou strings para tratar...
                if ((linha.Trim() == "") || (linha.IndexOf('"') < 0))
                {
                    continue;
                }

                //------------------------------------
                //INSTRUÇÕES VB6 QUE USAM STRINGS FIXAS E QUE NAO FAZEM PARTE DO COMANDO SQL DEVEM SER TRATADOS ANTES DESTE PONTO
                // Intruções que usam strings:  
                //     If xxx = "S" Then
                //     Format("#.##",100)
                //     Mid("Hello World",1,2)
                //-------------------------------------

                //Tratamento de parâmetros após o final da string SQL (da linha)
                #region Tratamento de parâmetros após o final da string
                {
                    //Busca código VB6 ao final da string
                    string linharesto = linha.Substring(linha.LastIndexOf('"') + 1, linha.Length - linha.LastIndexOf('"') - 1).Trim();

                    //Testa se tem código VB6 após a string SQL (da linha) 
                    //(Possivelmente é um parâmetro do SQL)
                    if (linharesto.Length > 0)
                    {
                        //Testa se é um comentário após o final da string
                        if (linharesto.IndexOf("\'") >= 0)
                        {
                            linharesto = linharesto.Substring(0, linharesto.IndexOf("\'")).Trim(); //Limpa comentários
                        }

                        //Testa se ainda sobrou código VB6
                        if (linharesto.Length > 0)
                        {
                            string pname = "";

                            //Testa se o código restante é uma adição a string SQL
                            if (linharesto.Substring(0, 2).Equals("& "))
                            {
                                pname = linharesto.Substring(2, linharesto.Length - 2);
                                ParametrosSQL pp = new ParametrosSQL(pname, "", linha.IndexOf(pname), linecount);
                                AddParametro(pp);
                            }
                            //Concatena o novo parâmetro
                            linha = linha.Substring(linha.IndexOf('"'), linha.LastIndexOf('"') - linha.IndexOf('"') - 1) + " #" + pname + '"';
                        }
                    }
                    else
                    {
                        //Filtra somente o que é String SQL
                        linha = linha.Substring(linha.IndexOf('"'), linha.LastIndexOf('"') - linha.IndexOf('"') + 1);
                    }
                }
                #endregion

                //Tratamento do IN 
                if (linha.IndexOf(IN, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    int inpos = linha.IndexOf(IN, StringComparison.CurrentCultureIgnoreCase) + 2;
                    string lastpart = "";

                    string lineend = linha.Substring(linha.IndexOf(IN, StringComparison.CurrentCultureIgnoreCase) + 8, (linha.Length - (linha.IndexOf(IN, StringComparison.CurrentCultureIgnoreCase) + 8)));

                    linha = linha.Substring(0, linha.IndexOf(IN, StringComparison.CurrentCultureIgnoreCase) + 4);

                    if (lineend.IndexOf('"') > 0)
                    {
                        lastpart = " " + lineend.Substring(lineend.IndexOf('"') + 1, lineend.Length - lineend.IndexOf('"') - 1);
                        lineend = lineend.Substring(0, lineend.IndexOf('"') - 2).Trim();
                    }
                    ParametrosSQL pp = new ParametrosSQL(lineend, "", inpos, linecount);
                    AddParametro(pp);
                    linha += pp.tag + lastpart;
                }

                int a2 = 0;
                bool param = false;

                //Loop que separa instruções VB6 dentro da string SQL
                while (linha.IndexOf('"') >= 0)
                {
                    int a1 = linha.IndexOf('"'); //Abre comando SQL

                    ParametrosSQL pp = null;
                    if (param)
                    {
                        pp = new ParametrosSQL(linha.Substring(3, a1 - 6), "", a2, linecount);
                        AddParametro(pp);
                    }
                    linha = linha.Substring(a1 + 1);

                    a1 = linha.IndexOf('"');
                    a2 = a1;
                    if (param)
                    {
                        conteudo += pp.tag + linha.Substring(0, a1);  
                    }
                    else
                    {
                        conteudo += linha.Substring(0, a1);
                    }
                    param = true;
                    linha = linha.Substring(a1 + 1);
                }

                //Tem conteúdo para adicionar ao comando SQL
                if (!conteudo.Equals(""))
                {
                    linecount++;
                    resultado += conteudo + Environment.NewLine;
                }
            }

            //Tratamento do IIF interno (comando proprietário da Cetil)
            resultado = RetroIIF(resultado);
            //Tratamento do CST interno (comando proprietário da Cetil)
            resultado = RetroCSTR(resultado);

            //Dispara o formatador do SQL
            SQLTratado = " " + DoFormatting(resultado);

            //Substitui caracteres especiais de HTML
            SQLTratado = SQLTratado.Replace("&lt;", "<");
            SQLTratado = SQLTratado.Replace("&gt;", ">");
            SQLTratado = SQLTratado.Replace("&amp;", "&");

            //Adiciona um espaço em branco no final de cada linha
            //(Truque para facilitar pintar o texto)
            SQLTratado = SQLTratado.Replace("\r\n", " \r\n");
            SQLTratado = SQLTratado.Replace(" ! ", "!");

            return SQLTratado;
        }

        /// <summary>
        /// Padrão de Tag
        /// </summary>
        /// <returns></returns>
        private string novaTag()
        {
            return " #" + paramtag++ + " ";
        }

        /// <summary>
        /// Adiciona um parametro na lista global de parametros
        /// </summary>
        /// <param name="pSQLParam">objeto de parametro</param>
        public void AddParametro(ParametrosSQL pSQLParam)
        {
            if (!paramList.Any(item => item.tag.Equals(pSQLParam.tag)))
                paramList.Add(pSQLParam);
        }

        /// <summary>
        /// Converte código CSTR (próprio Cetil) 
        /// </summary>
        /// <param name="pSQL">Comando SQL sujo</param>
        /// <returns>SQL Tratado</returns>
        #region Converte código CSTR
        public string RetroCSTR(string pSQL)
        {
            const string CSTR = " CSTR(";
            const string CONVERT = " CONVERT(VARCHAR,";
            const string EC = " & ";

            string resultado = "";

            resultado = pSQL.Replace(CSTR,CONVERT);

            resultado = resultado.Replace(EC," + ");

            return resultado;
        }
        #endregion

        /// <summary>
        /// Converte código IIF (próprio Cetil) 
        /// </summary>
        /// <param name="pSQL">Comando SQL sujo</param>
        /// <returns>SQL Tratado</returns>
        #region Converte código IIF (próprio Cetil)
        public string RetroIIF(string pSQL)
        {
            const string THEN = " THEN ";
            const string ELSE = " ELSE ";
            const string ENDx = " END| ";
            const string END = " END ";
            string resultado = pSQL;

            //Busca todos os índices de IIF
            List<int> iifs = getIndexes(pSQL, "IIF(");

            for (int i = iifs.Count-1; i >= 0; i--)
            {
                int v1pos = -1;  //Primeira vírgula
                int v2pos = -1;  //Segunda vírgula
                int ppos = -1;   //Posicao do parêntese final
                int ap = 0;  //Abre Parenteses

                //Trata o iif mais final
                for (int y = iifs[i]; y < resultado.Length; y++)
                {
                    if ((resultado[y] == '(') && (v2pos > 0))
                    {
                        ap++;
                    }
                    if ((resultado[y] == ',') && (v1pos < 0))
                    {
                        v1pos = y;
                    }
                    if ((resultado[y] == ',') && (v2pos < 0) && (v1pos != y))
                    {
                        v2pos = y + THEN.Length;
                    }
                    if ((v2pos > 0) && (resultado[y] == ')') && (y + THEN.Length > v2pos) && (ap == 0)) //&& (y > lastppos) && (ap == 0))
                    {
                        ppos = y + THEN.Length + ELSE.Length;
                        break; //Fim do IIF (encontrado parêntese final)
                    }
                    if (((resultado[y] == ')') || (resultado[y] == '|')) && (ap > 0))
                    {
                        ap--;
                    }
                }

                if (ppos < 0)
                {
                    throw new Exception("Comando IIF incorreto. Caractere ')' era esperado.");
                }

                if (v2pos < 0)
                {
                    throw new Exception("Comando IIF incorreto. Caractere ',' era esperado.");
                }

                //THEN .. ELSE .. END
                resultado = resultado.Substring(0, v1pos) + THEN + resultado.Substring(v1pos + 1, resultado.Length - v1pos - 1);
                resultado = resultado.Substring(0, v2pos-1) + ELSE + resultado.Substring(v2pos , resultado.Length - v2pos);
                resultado = resultado.Substring(0, ppos-2) + ENDx + resultado.Substring(ppos -1, resultado.Length - ppos +1);
            }

            resultado = resultado.Replace("iif(", " CASE WHEN ");
            resultado = resultado.Replace("iiF(", " CASE WHEN ");
            resultado = resultado.Replace("iIF(", " CASE WHEN ");
            resultado = resultado.Replace("IIF(", " CASE WHEN ");
            resultado = resultado.Replace("IIf(", " CASE WHEN ");
            resultado = resultado.Replace("Iif(", " CASE WHEN ");
            resultado = resultado.Replace(ENDx, END);

            return resultado;
        }
        #endregion

        /// <summary>
        /// Monta uma lista das posições encontradas
        /// </summary>
        /// <param name="plinha"></param>
        /// <param name="strvalue"></param>
        /// <returns></returns>
        private List<int> getIndexes(string plinha, string strvalue)
        {
            List<int> indexes = new List<int>();

            int intlastpos = 0;
            while (plinha.IndexOf(strvalue, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                int pos = plinha.IndexOf(strvalue, StringComparison.CurrentCultureIgnoreCase);
                indexes.Add(intlastpos + pos);
                intlastpos += pos + strvalue.Length;
                plinha = plinha.Substring(pos + strvalue.Length, plinha.Length - pos - strvalue.Length);
            }

            indexes.Sort();

            return indexes;
        }

        private void gridParametros_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        
        /// <summary>
        /// Aplica cores ao Texto SQL já tratado
        /// </summary>
        private void HighlightParams()
        {
            //Posições dos "Parâmetros" em VB encontrados
            //List<int> sharps = getIndexes(textSQL.Text, "#");

            //foreach (int pos in sharps)
            //{
            //    int end = textSQL.Text.Length;
            //    string param = "";
            //    for (int i = pos; i < end; i++)
            //    {
            //        param += textSQL.Text[i];
            //        foreach (ParametrosSQL item in paramList)
            //        {
            //            if (item.tag.Equals(param))
            //            {
            //                textSQL.Select(pos, item.tag.Length);
            //                textSQL.SelectionColor = Color.Red;
            //                break;
            //            }
            //        }
            //    }
            //}

            int s_start = textSQL.SelectionStart, startIndex = 0, index;

            foreach (ParametrosSQL item in paramList)
            {
                startIndex = 0;
                while ((index = textSQL.Text.IndexOf(item.tag, startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    textSQL.Select(index, item.tag.Length);
                    textSQL.SelectionColor = Color.Red;

                    startIndex = index + item.tag.Length;
                }
            }

            //Blue
            HighlightText("SELECT", Color.Blue, new List<string> { "(" }, null);
            HighlightText("UPDATE", Color.Blue, null, null);
            HighlightText("DELETE", Color.Blue, null, null);
            HighlightText("ALTER TABLE", Color.Blue, null, null);
            HighlightText("CREATE TABLE", Color.Blue, null, null);
            HighlightText("INSERT INTO", Color.Blue, null, null);
            HighlightText("ORDER BY", Color.Blue, null, null);
            HighlightText("GROUP BY", Color.Blue, null, null);
            HighlightText("HAVING", Color.Blue, null, null);
            HighlightText("FROM", Color.Blue, null, null);
            HighlightText("WHERE", Color.Blue, new List<string> { "(" }, null);
            HighlightText("AND", Color.Blue, new List<string> { ")" }, new List<string> { "(" });
            HighlightText("BETWEEN", Color.Blue, new List<string> { "(" }, null);
            HighlightText("OR", Color.Blue, new List<string> { ")" }, new List<string> { "(" });
            HighlightText("CASE", Color.Blue, new List<string> { "(", "," }, null);
            HighlightText("WHEN", Color.Blue, null, new List<string> { "(" });
            HighlightText("THEN", Color.Blue, new List<string> { ")" }, new List<string> { "(" });
            HighlightText("ELSE", Color.Blue, null, new List<string> { "(" });
            HighlightText("END", Color.Blue, new List<string> { ")" }, new List<string> { ")" });
            HighlightText("AS", Color.Blue, new List<string> { ")" }, null);
            HighlightText("SET", Color.Blue, null, new List<string> { "(" });
            HighlightText("DISTINCT", Color.Blue, null, null);
            HighlightText("VALUES", Color.Blue, new List<string> { ")" }, new List<string> { "(" });
            //DarkGray
            HighlightText(".dbo.", Color.DarkGray, null, null);
            //Purple
            HighlightText("INNER JOIN", Color.Purple, null, null);
            HighlightText("ON", Color.Purple, null, null);
            //Magenta
            HighlightText("CONVERT", Color.Magenta, new List<string> { ",", "(" }, new List<string> { "(" });
            HighlightText("COALESCE", Color.Magenta, new List<string> { ",", "(" }, new List<string> { "(" });
            HighlightText("SUM", Color.Magenta, new List<string> { ",", "(" }, new List<string> { "(" });
            HighlightText("MAX", Color.Magenta, new List<string> { ",", "(" }, new List<string> { "(" });
            HighlightText("LEN", Color.Magenta, new List<string> { ",", "(" }, new List<string> { "(" });
            HighlightText("COUNT", Color.Magenta, new List<string> { ",", "(" }, new List<string> { "(" });

            HighlightError(ERROSQL);

            textSQL.SelectionStart = 0;
            textSQL.SelectionLength = 0;
        }

        private void gridParametros_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((gridParametros[1, e.RowIndex].Value != null) && (gridParametros[2, e.RowIndex].Value.ToString().Equals("")))
            {
                int s_start = textSQL.SelectionStart, startIndex = 0, index;
                string word = paramList[e.RowIndex].tag.ToString();

                startIndex = 0;
                while ((index = textSQL.Text.IndexOf(word, startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    textSQL.Select(index, word.Length);

                    startIndex = index + word.Length;
                }
            }
        }

        /// <summary>
        /// Substitui o valor do parâmetro no texto SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParametros_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                textSQL.Text = SQLTratado;

                List<GridParamsPositions> gridPos = new List<GridParamsPositions>();
                
                string tag = ""; //Nome do parametro no grid
                string valor = ""; //Valor do parametro no grid

                for (int l = 0; l < gridParametros.RowCount; l++)
                {
                    if ((gridParametros[2, l].Value != null) && (!gridParametros[2, l].Value.ToString().Equals("")))
                    {
                        tag = paramList[l].tag;
                        valor = gridParametros[2, l].Value.ToString();

                        List<int> pos = getIndexes(textSQL.Text, paramList[l].tag);
                        int ajuste  = (tag.Length - valor.Length);
                        for (int i = 1; i < pos.Count; i++)
                        {
                            pos[i] = pos[i] - (ajuste * i);

                            
                        }
                        for (int i = 0; i < pos.Count; i++)
                        {
                            foreach (var item in gridPos)
                            {
                                for (int x = 0; x < item.list.Count; x++)
                                {
                                    if (item.list[x] > pos[i])
                                    {
                                        item.list[x] = item.list[x] - (ajuste);
                                    }
                                }
                            }
                        }

                        GridParamsPositions p = new GridParamsPositions(pos, l);
                        gridPos.Add(p);
                        
                        textSQL.Text = textSQL.Text.Replace(paramList[l].tag, gridParametros[2, l].Value.ToString());
                    }
                }

                tag = "";
                valor = "";

                for (int l = 0; l < gridParametros.RowCount; l++)
                {
                    
                    if ((gridParametros[2, l].Value != null) && (!gridParametros[2, l].Value.ToString().Equals("")))
                    {
                        tag = paramList[l].tag;
                        valor = gridParametros[2, l].Value.ToString();

                        List<int> pos = null;
                        int paramnum = 0;

                        foreach (GridParamsPositions item in gridPos)
                        {
                            paramnum++;
                            
                            if (item.gridrow == l)
                            {
                                pos = item.list;

                                for (int i = 0; i < pos.Count; i++)
                                {
                                    textSQL.Select(pos[i], valor.Length);
                                    textSQL.SelectionColor = Color.Green;
                                }
                            }
                        }
                    }
                }

                HighlightParams();
            }
        }

        /// <summary>
        /// Gera cores aleatórias
        /// </summary>
        /// <returns>cor</returns>
        private Color randomColor()
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            return Color.FromKnownColor(randomColorName);
        }

        #region Aplica cores no texto
        /// <summary>
        /// Seleciona e aplica cores a string de erro
        /// </summary>
        /// <param name="word"></param>
        private void HighlightError(string word)
        {
            int s_start = textSQL.SelectionStart, startIndex = 0, index;

            startIndex = 0;
            while ((index = textSQL.Text.IndexOf(word, startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
            {
                textSQL.Select(index, word.Length);
                textSQL.SelectionColor = Color.Red;
                textSQL.SelectionBackColor = Color.Yellow;

                startIndex = index + word.Length;
            }
        }

        /// <summary>
        /// Aplica cores as palavras inteiras
        /// </summary>
        /// <param name="word">Palavra (token)</param>
        /// <param name="color">Cora da palavra</param>
        /// <param name="prefixchars">caracteres permitidos antes da palavra</param>
        /// <param name="sufixchars">caracteres permitidos depois das palavra</param>
        private void HighlightText(string word, Color color, List<string> prefixchars, List<string> sufixchars)
        {
            List<string> prefix = new List<string> { " ", "\n", "\t" };
            List<string> sufix = new List<string> { " ", "\n", "\t" };

            if (prefixchars != null)
            {
                prefix.AddRange(prefixchars);
            }

            if (sufixchars != null)
            {
                sufix.AddRange(sufixchars);
            }

            int s_start = textSQL.SelectionStart, startIndex = 0, index;

            for (int i = 0; i < prefix.Count; i++)
            {
                for (int y = 0; y < sufix.Count; y++)
                {
                    string newword = prefix[i] + word + sufix[y];

                    startIndex = 0;
                    while ((index = textSQL.Text.IndexOf(newword, startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
                    {
                        textSQL.Select(index + prefix[i].Length, word.Length);
                        textSQL.SelectionColor = color;

                        startIndex = index + newword.Length;
                    }
                }
            }
        }
        #endregion

    }

    /// <summary>
    /// Posições do parâmetro no texto
    /// </summary>
    public class GridParamsPositions
    {
        public List<int> list { get; set; }
        public int gridrow { get; set; }

        public GridParamsPositions(List<int> pPositions, int row)
        {
            this.list = pPositions;
            this.gridrow = row;
        }
    }

    /// <summary>
    /// Parâmetro do SQL
    /// </summary>
    public class ParametrosSQL
    {
        public string tag { get; set; }
        public string Nome { get; set; } 
        public string Valor { get; set; }
        public int pos { get; set; }
        public int line { get; set; } 

        public ParametrosSQL(String pName, String pValor, int pLineposition, int pLinenumber, string ptag = "")
        {
            this.Nome = pName;
            this.Valor = pValor;
            this.pos = pLineposition;
            this.line = pLinenumber;
            if (ptag.Equals(""))
            {
                this.tag = "#" + pName;
            }
            else
            {
                this.tag = ptag;
            }            
        }
    }
}
