using ESWA07CalculadoraDeMedias;
using OOPFoundation;

namespace CalculadoraDeMedias07
{
    /// <summary>
    /// Formulário principal do Aplicativo Calculadora de Médias.
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly GradeCalculator _calculator;
        private readonly Text _textSanitizer;

        private double _semestralAverage = 0.0;

        public FormMain()
        {
            InitializeComponent();
            _calculator = new GradeCalculator();
            _textSanitizer = new Text();
            ResetAll();
        }

        // ─── Botão Semestral ──────────────────────────────────────────────────
        private void btnSemestral_Click(object sender, EventArgs e)
        {
            if (!TryParseNote(txtNP1.Text, "NP1", out double np1)) return;
            if (!TryParseNote(txtNP2.Text, "NP2", out double np2)) return;
            if (!TryParseNote(txtPIM.Text, "PIM", out double pim)) return;

            _semestralAverage = _calculator.CalculateSemestralAverage(np1, np2, pim);
            lblSemestral.Text = _semestralAverage.ToString("F1");

            var status = _calculator.GetSemestralStatus(_semestralAverage);
            ApplySemestralStatus(status);
        }

        // ─── Botão Final ──────────────────────────────────────────────────────
        private void btnFinal_Click(object sender, EventArgs e)
        {
            if (!TryParseNote(txtExame.Text, "Exame", out double exam)) return;

            double finalAverage = _calculator.CalculateFinalAverage(_semestralAverage, exam);
            lblFinal.Text = finalAverage.ToString("F1");

            var status = _calculator.GetFinalStatus(finalAverage);
            ApplyFinalStatus(status);
        }

        // ─── Botão Limpar (Semestral) ─────────────────────────────────────────
        private void btnLimparSemestral_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        // ─── Botão Limpar (Final) ─────────────────────────────────────────────
        private void btnLimparFinal_Click(object sender, EventArgs e)
        {
            txtExame.Text = string.Empty;
            lblFinal.Text = "0,0";
            lblStatus.ForeColor = Color.Black;
        }
