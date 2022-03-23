using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MythicPlusCalc
{
    public partial class Form1 : Form
    {
        public Point mouseLocation;
        public double score = 0;
        public Form1()
        {
            InitializeComponent();
            //Anwendungseinstellungen Laden
            nameInput.Text = Properties.Settings.Default.Name;
            realmInput.Text = Properties.Settings.Default.Realm;
        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            //Sobald man klickt die Maus Position nehmen
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            //Falls die Linke Maustaste gedrückt wird das Fenster zur Position der Maus bewegen
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //Anwendung Schließen
            Application.Exit();
        }

        //Überprüfen welche Zahl größer ist um den Score richtig zu berechnen
        private void CompareDungeon(int T, int F)
        {
            if (T >= F)
            {
                score += Calc_Score(T);
                score += (Calc_Score(F) / 3);
            }
            else
            {
                score += Calc_Score(F);
                score += (Calc_Score(T) / 3);
            }
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            //Versuchen alle Textboxen in int's umzuwandeln und damit den Score zu berechnen
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

                CompareDungeon(HoATS, HoAFS);
                CompareDungeon(SDTS, SDFS);
                CompareDungeon(DoSTS, DoSFS);
                CompareDungeon(MoTSTS, MoTSFS);
                CompareDungeon(NWTS, NWFS);
                CompareDungeon(SoATS, SoAFS);
                CompareDungeon(ToPTS, ToPFS);
                CompareDungeon(PFTS, PFFS);
                CompareDungeon(GMBTTS, GMBTFS);
                CompareDungeon(STRTSTS, STRTSFS);
                scoreLabel.Text = score.ToString("F2");
                scoreLabel.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!");
            }

            //Textfarbe je nach höhe des Scores festlegen
            if (score >= 3000)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E67E22");
            }
            else if (score >= 2850)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#DD7A35");
            }
            else if (score >= 2700)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D37547");
            }
            else if (score >= 2550)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CA7159");
            }
            else if(score >= 2400)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#C16C6B");
            }
            else if (score >= 2250)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B1648B");
            }
            else if (score >= 2100)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A55EA2");
            }
            else if (score >= 1950)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9B59B6");
            }
            else if (score >= 1800)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#8865BD");
            }
            else if (score >= 1650)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7770C4");
            }
            else if (score >= 1500)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6879C9");
            }
            else if (score >= 1350)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5C80CD");
            }
            else if (score >= 1200)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5087D1");
            }
            else if (score >= 1050)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4190D6");
            }
            else if (score >= 900)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3498DB");
            }
            else if (score >= 750)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#33A1C9");
            }
            else if (score >= 600)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#32AAB5");
            }
            else if (score >= 450)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#31B2A5");
            }
            else if (score >= 300)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#30BF8B");
            }
            else if (score >= 150)
            {
                scoreLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2ECC71");
            } 
        }

        //Textboxen mit Werten füllen
        public void SetLevels(String dungeon, String level, String affix)
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

        //Json Datei aus der API abrufen
        public dynamic JsonRequest(String playerName, String realmName, String requestField)
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

        //Werte je nach Level berechnen
        private double Calc_Score(int Level)
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

        //Überprüfung dass nur Zahlen in der Textbox benutzt werden
        private void STRTST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Nur Zahlen eingeben!");
                e.Handled = true;
            }
        }

        //Textboxen mit API Werten füllen
        private void SetScore_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Name = nameInput.Text;
            Properties.Settings.Default.Realm = realmInput.Text;
            Properties.Settings.Default.Save();
            var bestRuns = JsonRequest(nameInput.Text, realmInput.Text, "mythic_plus_best_runs");
            if (bestRuns != null)
            {
                foreach (var item in bestRuns["mythic_plus_best_runs"])
                {
                    foreach (var affix in item["affixes"])
                    {
                        String affixName = affix["name"];
                        String dungeon = item["short_name"];
                        String level = item["mythic_level"];
                        SetLevels(dungeon, level, affixName);
                    }
                }
            }
            else
            {
                return;
            }
            var alternateRuns = JsonRequest(nameInput.Text, realmInput.Text, "mythic_plus_alternate_runs");
            if(alternateRuns != null)
            {
                foreach (var item in alternateRuns["mythic_plus_alternate_runs"])
                {
                    foreach (var affix in item["affixes"])
                    {
                        String affixName = affix["name"];
                        String dungeon = item["short_name"];
                        String level = item["mythic_level"];
                        SetLevels(dungeon, level, affixName);
                    }
                }
            }
        }
    }
}
