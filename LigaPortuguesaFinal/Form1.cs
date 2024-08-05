using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LigaPortuguesaFinal
{
    public partial class frmLigaPortuguesa : Form
    {
        int i = 1;
        LigaPortuguesaDB db;

        public frmLigaPortuguesa()
        {
            InitializeComponent();
        }

        private void frmLigaPortuguesa_Load(object sender, EventArgs e)
        {
            db = new LigaPortuguesaDB();
            Jornadas jornada = db.Jornadas.Find(i);
            PopularJogos();
            PopularClassificacao();
            
        }

        private void PopularClassificacao()
        {
            List<Stats> statsJornada = new List<Stats>();

            // Initialize stats for each team
            foreach (Equipas equipa in db.Equipas.ToList())
            {
                Stats statsEquipa = new Stats(equipa);
                statsEquipa.Vitorias = 0;
                statsEquipa.Empates = 0;
                statsEquipa.Derrotas = 0;
                statsEquipa.GM = 0;
                statsEquipa.GS = 0;
                statsEquipa.DG = 0;
                statsEquipa.Pontos = 0;
                statsJornada.Add(statsEquipa);
            }

            // Process each jornada
            for (int k = 1; k <= i; k++)
            {
                Jornadas jornada = db.Jornadas.Find(k);
                foreach (Jogos jogo in jornada.Jogos.ToList())
                {
                    if (jogo.IsFinished)
                    {
                        Equipas equipaCasa = jogo.Equipas;
                        int golosCasa = jogo.GolosCasa;
                        int DGCasa = golosCasa - jogo.GolosFora;

                        Equipas equipaFora = jogo.Equipas1;
                        int golosFora = jogo.GolosFora;
                        int DGFora = golosFora - golosCasa;

                        // Find stats for home team
                        Stats statsCasa = statsJornada.FirstOrDefault(s => s.Equipa == equipaCasa);
                        // Find stats for away team
                        Stats statsFora = statsJornada.FirstOrDefault(s => s.Equipa == equipaFora);

                        if (statsCasa != null && statsFora != null)
                        {
                            statsCasa.GM += golosCasa;
                            statsCasa.GS += golosFora;
                            statsCasa.DG += DGCasa;

                            statsFora.GM += golosFora;
                            statsFora.GS += golosCasa;
                            statsFora.DG += DGFora;

                            if (golosCasa > golosFora) // Home win
                            {
                                statsCasa.Vitorias++;
                                statsFora.Derrotas++;
                                statsCasa.Pontos += 3;
                            }
                            else if (golosCasa < golosFora) // Away win
                            {
                                statsFora.Vitorias++;
                                statsCasa.Derrotas++;
                                statsFora.Pontos += 3;
                            }
                            else // Draw
                            {
                                statsCasa.Empates++;
                                statsFora.Empates++;
                                statsCasa.Pontos++;
                                statsFora.Pontos++;
                            }
                        }

                    }
                }
            }

            // Sort stats by Points and Goal Difference
            var sortedStatsList = statsJornada
                .OrderByDescending(s => s.Pontos)
                .ThenByDescending(s => s.DG)
                .ToList();

            // Populate ListView
            lvClassificacao.Items.Clear();

            int position = 1;
            foreach (Stats stat in sortedStatsList)
            {
                ListViewItem item = new ListViewItem(position.ToString()); // Position
                item.SubItems.Add(stat.Equipa.Nome); // Team
                item.SubItems.Add(stat.Vitorias.ToString()); // Wins
                item.SubItems.Add(stat.Empates.ToString()); // Draws
                item.SubItems.Add(stat.Derrotas.ToString()); // Losses
                item.SubItems.Add(stat.GM.ToString()); // Goals For
                item.SubItems.Add(stat.GS.ToString()); // Goals Against
                item.SubItems.Add(stat.DG.ToString()); // Goal Difference
                item.SubItems.Add(stat.Pontos.ToString()); // Points

                // Apply colors based on row index (1-based index)
                if (position == 1)
                {
                    item.BackColor = Color.DodgerBlue; // Row 1 as cyan blue
                }
                else if (position == 2)
                {
                    item.BackColor = Color.LightSkyBlue; // Row 2 as weaker cyan blue
                }
                else if (position == 3)
                {
                    item.BackColor = Color.DarkOrange; // Row 3 as orange
                }
                else if (position == 4)
                {
                    item.BackColor = Color.Orange; // Row 4 as a weaker orange
                }
                else if (position == 5)
                {
                    item.BackColor = Color.LightGreen; // Row 5 as light green
                }
                else if (position == 16)
                {
                    item.BackColor = Color.OrangeRed; // Row 16 as orange-red
                }
                else if (position == 17)
                {
                    item.BackColor = Color.Red; // Row 17 as red
                }
                else if (position == 18)
                {
                    item.BackColor = Color.Red; // Row 18 as red
                }

                lvClassificacao.Items.Add(item);
                position++;
            }




        }

        private void PopularClassificacaoFinal()
        {
            // Initialize stats for each team
            List<Stats> stats = new List<Stats>();
            foreach (Equipas equipa in db.Equipas.ToList())
            {
                Stats statsEquipa = new Stats(equipa);
                statsEquipa.Vitorias = 0;
                statsEquipa.Empates = 0;
                statsEquipa.Derrotas = 0;
                statsEquipa.GM = 0;
                statsEquipa.GS = 0;
                statsEquipa.DG = 0;
                statsEquipa.Pontos = 0;
                stats.Add(statsEquipa);
            }

            // Process each finished game
            foreach (Jogos jogo in db.Jogos.ToList<Jogos>())
            {
                if (jogo.IsFinished)
                {
                    Equipas equipaCasa = jogo.Equipas;
                    int golosCasa = jogo.GolosCasa;
                    int DGCasa = golosCasa - jogo.GolosFora;

                    Equipas equipaFora = jogo.Equipas1;
                    int golosFora = jogo.GolosFora;
                    int DGFora = golosFora - golosCasa;

                    // Find stats for home team
                    Stats statsCasa = stats.FirstOrDefault(s => s.Equipa == equipaCasa);
                    // Find stats for away team
                    Stats statsFora = stats.FirstOrDefault(s => s.Equipa == equipaFora);

                    if (statsCasa != null && statsFora != null)
                    {
                        statsCasa.GM += golosCasa;
                        statsCasa.GS += golosFora;
                        statsCasa.DG += DGCasa;

                        statsFora.GM += golosFora;
                        statsFora.GS += golosCasa;
                        statsFora.DG += DGFora;

                        if (golosCasa > golosFora) // Home win
                        {
                            statsCasa.Vitorias++;
                            statsFora.Derrotas++;
                            statsCasa.Pontos += 3;
                        }
                        else if (golosCasa < golosFora) // Away win
                        {
                            statsFora.Vitorias++;
                            statsCasa.Derrotas++;
                            statsFora.Pontos += 3;
                        }
                        else // Draw
                        {
                            statsCasa.Empates++;
                            statsFora.Empates++;
                            statsCasa.Pontos++;
                            statsFora.Pontos++;
                        }
                    }
                }
            }

            // Sort stats by Points and Goal Difference
            var sortedStatsList = stats
                .OrderByDescending(s => s.Pontos)
                .ThenByDescending(s => s.DG)
                .ToList();

            // Populate ListView
            lvClassificacao.Items.Clear();

            int position = 1;
            foreach (Stats stat in sortedStatsList)
            {
                ListViewItem item = new ListViewItem(position.ToString()); // Position
                item.SubItems.Add(stat.Equipa.Nome); // Team
                item.SubItems.Add(stat.Vitorias.ToString()); // Wins
                item.SubItems.Add(stat.Empates.ToString()); // Draws
                item.SubItems.Add(stat.Derrotas.ToString()); // Losses
                item.SubItems.Add(stat.GM.ToString()); // Goals For
                item.SubItems.Add(stat.GS.ToString()); // Goals Against
                item.SubItems.Add(stat.DG.ToString()); // Goal Difference
                item.SubItems.Add(stat.Pontos.ToString()); // Points

                // Apply colors based on row index (1-based index)
                if (position == 1)
                {
                    item.BackColor = Color.DodgerBlue; // Row 1 as cyan blue
                }
                else if (position == 2)
                {
                    item.BackColor = Color.LightSkyBlue; // Row 2 as weaker cyan blue
                }
                else if (position == 3)
                {
                    item.BackColor = Color.DarkOrange; // Row 3 as orange
                }
                else if (position == 4)
                {
                    item.BackColor = Color.Orange; // Row 4 as a weaker orange
                }
                else if (position == 5)
                {
                    item.BackColor = Color.LightGreen; // Row 5 as light green
                }
                else if (position == 16)
                {
                    item.BackColor = Color.OrangeRed; // Row 16 as orange-red
                }
                else if (position == 17)
                {
                    item.BackColor = Color.Red; // Row 17 as red
                }
                else if (position == 18)
                {
                    item.BackColor = Color.Red; // Row 18 as red
                }

                lvClassificacao.Items.Add(item);
                position++;
            }
        }




        private void PopularJogos()
        {

            int j = 1;
            Jornadas jornada = db.Jornadas.Find(i);

            foreach (Jogos jogo in jornada.Jogos.ToList<Jogos>())
            {
                Equipas equipaCasa = jogo.Equipas;
                Equipas equipaFora = jogo.Equipas1;
                String estadio = equipaCasa.Estadio;

                bool finished = jogo.IsFinished;
                int golosCasa = jogo.GolosCasa;
                int golosFora = jogo.GolosFora;


                switch (j)
                {
                    case 1:
                        lblCasa1.Text = equipaCasa.Nome;
                        txtCasa1.Text = jogo.GolosCasa.ToString();
                        lblFora1.Text = equipaFora.Nome;
                        txtFora1.Text = jogo.GolosFora.ToString();
                        lblEstadio1.Text = estadio;
                        chkJogo1.Checked = finished;
                        break;

                    case 2:
                        lblCasa2.Text = equipaCasa.Nome;
                        txtCasa2.Text = jogo.GolosCasa.ToString();
                        lblFora2.Text = equipaFora.Nome;
                        txtFora2.Text = jogo.GolosFora.ToString();
                        lblEstadio2.Text = estadio;
                        chkJogo2.Checked = finished;
                        break;

                    case 3:
                        lblCasa3.Text = equipaCasa.Nome;
                        txtCasa3.Text = jogo.GolosCasa.ToString();
                        lblFora3.Text = equipaFora.Nome;
                        txtFora3.Text = jogo.GolosFora.ToString();
                        lblEstadio3.Text = estadio;
                        chkJogo3.Checked = finished;
                        break;

                    case 4:
                        lblCasa4.Text = equipaCasa.Nome;
                        txtCasa4.Text = jogo.GolosCasa.ToString();
                        lblFora4.Text = equipaFora.Nome;
                        txtFora4.Text = jogo.GolosFora.ToString();
                        lblEstadio4.Text = estadio;
                        chkJogo4.Checked = finished;
                        break;

                    case 5:
                        lblCasa5.Text = equipaCasa.Nome;
                        txtCasa5.Text = jogo.GolosCasa.ToString();
                        lblFora5.Text = equipaFora.Nome;
                        txtFora5.Text = jogo.GolosFora.ToString();
                        lblEstadio5.Text = estadio;
                        chkJogo5.Checked = finished;
                        break;

                    case 6:
                        lblCasa6.Text = equipaCasa.Nome;
                        txtCasa6.Text = jogo.GolosCasa.ToString();
                        lblFora6.Text = equipaFora.Nome;
                        txtFora6.Text = jogo.GolosFora.ToString();
                        lblEstadio6.Text = estadio;
                        chkJogo6.Checked = finished;
                        break;

                    case 7:
                        lblCasa7.Text = equipaCasa.Nome;
                        txtCasa7.Text = jogo.GolosCasa.ToString();
                        lblFora7.Text = equipaFora.Nome;
                        txtFora7.Text = jogo.GolosFora.ToString();
                        lblEstadio7.Text = estadio;
                        chkJogo7.Checked = finished;
                        break;

                    case 8:
                        lblCasa8.Text = equipaCasa.Nome;
                        txtCasa8.Text = jogo.GolosCasa.ToString();
                        lblFora8.Text = equipaFora.Nome;
                        txtFora8.Text = jogo.GolosFora.ToString();
                        lblEstadio8.Text = estadio;
                        chkJogo8.Checked = finished;
                        break;

                    case 9:
                        lblCasa9.Text = equipaCasa.Nome;
                        txtCasa9.Text = jogo.GolosCasa.ToString();
                        lblFora9.Text = equipaFora.Nome;
                        txtFora9.Text = jogo.GolosFora.ToString();
                        lblEstadio9.Text = estadio;
                        chkJogo9.Checked = finished;
                        break;

                    default:
                        // Optional: Handle unexpected values of 'j'
                        MessageBox.Show("Valor inesperado para j!");
                        break;
                }
                j++;
            }
        }

        private void btnAntes_Click(object sender, EventArgs e)
        {
            if (i > 1)
            {
                i -= 1;
                Jornadas jornada = db.Jornadas.Find(i);
                PopularJogos();
                if (chkClassificacaoFinal.Checked)
                {
                    PopularClassificacaoFinal();
                }
                else
                {
                    PopularClassificacao();
                }
                lblJornada.Text = "Jornada " + i + " /34";
            }
        }

        private void btnDepois_Click(object sender, EventArgs e)
        {
            if (i < 34)
            {
                i += 1;
                PopularJogos();
                if (chkClassificacaoFinal.Checked)
                {
                    PopularClassificacaoFinal();
                }
                else
                {
                    PopularClassificacao();
                }
                
                lblJornada.Text = "Jornada " + i + " /34";
            }
        }

        private void lvClassificacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboJogo1_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[0];

            if (chkJogo1.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa1.Text);
                jogo.GolosFora = int.Parse(txtFora1.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo2_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[1];

            if (chkJogo2.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa2.Text);
                jogo.GolosFora = int.Parse(txtFora2.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo3_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[2];

            if (chkJogo3.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa3.Text);
                jogo.GolosFora = int.Parse(txtFora3.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo4_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[3];

            if (chkJogo4.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa4.Text);
                jogo.GolosFora = int.Parse(txtFora4.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo5_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[4];

            if (chkJogo5.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa5.Text);
                jogo.GolosFora = int.Parse(txtFora5.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo6_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[5];

            if (chkJogo6.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa6.Text);
                jogo.GolosFora = int.Parse(txtFora6.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo7_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[6];

            if (chkJogo7.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa7.Text);
                jogo.GolosFora = int.Parse(txtFora7.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo8_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[7];

            if (chkJogo8.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa8.Text);
                jogo.GolosFora = int.Parse(txtFora8.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void cboJogo9_CheckedChanged(object sender, EventArgs e)
        {
            Jornadas jornada = db.Jornadas.Find(i);
            Jogos jogo = jornada.Jogos.ToList<Jogos>()[8];

            if (chkJogo9.Checked)
            {
                jogo.GolosCasa = int.Parse(txtCasa9.Text);
                jogo.GolosFora = int.Parse(txtFora9.Text);
                jogo.IsFinished = true;
            }
            else
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }

            db.SaveChanges();
            PopularClassificacao();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach(Jogos jogo in db.Jogos.ToList<Jogos>())
            {
                jogo.GolosCasa = 0;
                jogo.GolosFora = 0;
                jogo.IsFinished = false;
            }
            db.SaveChanges();
            i = 1;
            PopularJogos();
            PopularClassificacao();
        }

        private void cboClassificacaoFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClassificacaoFinal.Checked)
            {
                PopularClassificacaoFinal();
            }
            else
            {
                PopularClassificacao();
            }
            
        }
    }
}
