using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MythicPlusCalc
{
    public partial class Form1 : Form
    {
        public Point mouseLocation;
        public Form1()
        {
            InitializeComponent();
            nameInput.Text = Properties.Settings.Default.Name;
            realmInput.Text = Properties.Settings.Default.Realm;
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            double score = 0;

            try
            {
                int HoATS = int.Parse(HoAT.Text);
                int HoAFS = int.Parse(HoAF.Text);

                int SDTS = int.Parse(SDT.Text);
                int SDFS = int.Parse(SDF.Text);

                int DoSTS = int.Parse(DoST.Text);
                int DoSFS = int.Parse(DoSF.Text);

                int MoTSTS = int.Parse(MoTST.Text);
                int MoTSFS = int.Parse(MoTSF.Text);

                int NWTS = int.Parse(NWT.Text);
                int NWFS = int.Parse(NWF.Text);

                int SoATS = int.Parse(SoAT.Text);
                int SoAFS = int.Parse(SoAF.Text);

                int ToPTS = int.Parse(ToPT.Text);
                int ToPFS = int.Parse(ToPF.Text);

                int PFTS = int.Parse(PFT.Text);
                int PFFS = int.Parse(PFF.Text);

                int GMBTTS = int.Parse(GMBTT.Text);
                int GMBTFS = int.Parse(GMBTF.Text);

                int STRTSTS = int.Parse(STRTST.Text);
                int STRTSFS = int.Parse(STRTSF.Text);

                if (HoATS >= HoAFS)
                {
                    score = score + calc_Score(HoATS);
                    score = score + (calc_Score(HoAFS) / 3);
                }
                else
                {
                    score = score + calc_Score(HoAFS);
                    score = score + (calc_Score(HoATS) / 3);
                }

                if (SDTS >= SDFS)
                {
                    score = score + calc_Score(SDTS);
                    score = score + (calc_Score(SDFS) / 3);
                }
                else
                {
                    score = score + calc_Score(SDFS);
                    score = score + (calc_Score(SDTS) / 3);
                }

                if (DoSTS >= DoSFS)
                {
                    score = score + calc_Score(DoSTS);
                    score = score + (calc_Score(DoSFS) / 3);
                }
                else
                {
                    score = score + calc_Score(DoSFS);
                    score = score + (calc_Score(DoSTS) / 3);
                }

                if (MoTSTS >= MoTSFS)
                {
                    score = score + calc_Score(MoTSTS);
                    score = score + (calc_Score(MoTSFS) / 3);
                }
                else
                {
                    score = score + calc_Score(MoTSFS);
                    score = score + (calc_Score(MoTSTS) / 3);
                }

                if (NWTS >= NWFS)
                {
                    score = score + calc_Score(NWTS);
                    score = score + (calc_Score(NWFS) / 3);
                }
                else
                {
                    score = score + calc_Score(NWFS);
                    score = score + (calc_Score(NWTS) / 3);
                }

                if (SoATS >= SoAFS)
                {
                    score = score + calc_Score(SoATS);
                    score = score + (calc_Score(SoAFS) / 3);
                }
                else
                {
                    score = score + calc_Score(SoAFS);
                    score = score + (calc_Score(SoATS) / 3);
                }

                if (ToPTS >= ToPFS)
                {
                    score = score + calc_Score(ToPTS);
                    score = score + (calc_Score(ToPFS) / 3);
                }
                else
                {
                    score = score + calc_Score(ToPFS);
                    score = score + (calc_Score(ToPTS) / 3);
                }

                if (PFTS >= PFFS)
                {
                    score = score + calc_Score(PFTS);
                    score = score + (calc_Score(PFFS) / 3);
                }
                else
                {
                    score = score + calc_Score(PFFS);
                    score = score + (calc_Score(PFTS) / 3);
                }

                if (GMBTTS >= GMBTFS)
                {
                    score = score + calc_Score(GMBTTS);
                    score = score + (calc_Score(GMBTFS) / 3);
                }
                else
                {
                    score = score + calc_Score(GMBTFS);
                    score = score + (calc_Score(GMBTTS) / 3);
                }

                if (STRTSTS >= STRTSFS)
                {
                    score = score + calc_Score(STRTSTS);
                    score = score + (calc_Score(STRTSFS) / 3);
                }
                else
                {
                    score = score + calc_Score(STRTSFS);
                    score = score + (calc_Score(STRTSTS) / 3);
                }
                scoreLabel.Text = score.ToString("F2");
                scoreLabel.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!");
            }

            if (score >= 150)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2ECC71");
            } 
            if (score >= 300)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#30BF8B");
            }
            if (score >= 450)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#31B2A5");
            }
            if (score >= 600)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#32AAB5");
            }
            if (score >= 750)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#33A1C9");
            }
            if (score >= 900)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3498DB");
            }
            if (score >= 1050)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4190D6");
            }
            if (score >= 1200)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5087D1");
            }
            if (score >= 1350)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5C80CD");
            }
            if (score >= 1500)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6879C9");
            }
            if (score >= 1650)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7770C4");
            }
            if (score >= 1800)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#8865BD");
            }
            if (score >= 1950)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9B59B6");
            }
            if (score >= 2100)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A55EA2");
            }
            if (score >= 2250)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B1648B");
            }
            if (score >= 2400)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#C16C6B");
            }
            if (score >= 2550)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CA7159");
            }
            if (score >= 2700)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D37547");
            }
            if (score >= 2850)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#DD7A35");
            }
            if (score >= 3000)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E67E22");
            }
        }

        public void setLevels(String dungeon, String level, String affix)
        {
            if (affix == "Tyrannical")
            {
                switch (dungeon)
                {
                    case "HOA":
                        HoAT.Text = level;
                        break;
                    case "SD":
                        SDT.Text = level;
                        break;
                    case "DOS":
                        DoST.Text = level;
                        break;
                    case "MISTS":
                        MoTST.Text = level;
                        break;
                    case "NW":
                        NWT.Text = level;
                        break;
                    case "SOA":
                        SoAT.Text = level;
                        break;
                    case "TOP":
                        ToPT.Text = level;
                        break;
                    case "PF":
                        PFT.Text = level;
                        break;
                    case "GMBT":
                        GMBTT.Text = level;
                        break;
                    case "STRT":
                        STRTST.Text = level;
                        break;
                }
            }
            else if (affix == "Fortified")
            {
                switch (dungeon)
                {
                    case "HOA":
                        HoAF.Text = level;
                        break;
                    case "SD":
                        SDF.Text = level;
                        break;
                    case "DOS":
                        DoSF.Text = level;
                        break;
                    case "MISTS":
                        MoTSF.Text = level;
                        break;
                    case "NW":
                        NWF.Text = level;
                        break;
                    case "SOA":
                        SoAF.Text = level;
                        break;
                    case "TOP":
                        ToPF.Text = level;
                        break;
                    case "PF":
                        PFF.Text = level;
                        break;
                    case "GMBT":
                        GMBTF.Text = level;
                        break;
                    case "STRT":
                        STRTSF.Text = level;
                        break;
                }
            }
        }

        public dynamic jsonRequest(String playerName, String realmName, String requestField)
        {
            try
            {
                String json = new WebClient().DownloadString("https://raider.io/api/v1/characters/profile?region=eu&realm=" + realmName + "&name=" + playerName + "&fields=" + requestField);
                dynamic liste = JsonConvert.DeserializeObject(json);
                return liste;
            }
            catch (Exception)
            {
                MessageBox.Show("Spieler nicht gefunden!");
            }
            return null;
        }

        private double calc_Score(int Level)
        {
            double score = Level * 7.5;
            if(Level >= 10)
            {
                score = score + 75;
            }else if (Level >= 7)
            {
                score = score + 60;
            }
            else if (Level >= 4)
            {
                score = score + 52.5;
            }
            return score;
        }

        private void STRTST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Nur Zahlen eingeben!");
                e.Handled = true;
            }
        }

        private void setScore_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Name = nameInput.Text;
            Properties.Settings.Default.Realm = realmInput.Text;
            Properties.Settings.Default.Save();
            var bestRuns = jsonRequest(nameInput.Text, realmInput.Text, "mythic_plus_best_runs");
            if (bestRuns != null)
            {
                foreach (var item in bestRuns["mythic_plus_best_runs"])
                {
                    foreach (var affix in item["affixes"])
                    {
                        String affixName = affix["name"];
                        String dungeon = item["short_name"];
                        String level = item["mythic_level"];
                        setLevels(dungeon, level, affixName);
                    }
                }
            }
            else
            {
                return;
            }
            var alternateRuns = jsonRequest(nameInput.Text, realmInput.Text, "mythic_plus_alternate_runs");
            if(alternateRuns != null)
            {
                foreach (var item in alternateRuns["mythic_plus_alternate_runs"])
                {
                    foreach (var affix in item["affixes"])
                    {
                        String affixName = affix["name"];
                        String dungeon = item["short_name"];
                        String level = item["mythic_level"];
                        setLevels(dungeon, level, affixName);
                    }
                }
            }
        }
    }
}
