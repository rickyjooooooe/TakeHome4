using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TakeHomeW4_RickyJonathan_0706022210005.Form1;
using System.Xml.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace TakeHomeW4_RickyJonathan_0706022210005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxcountry.SelectedIndexChanged += comboBoxcountry_SelectedIndexChanged;
        }

        public class Player
        {
            string playername;
            string playernum;
            string playerpos;
            public string playerName
            {
                get { return playername; }
                set { playername = value; }
            }
            public string playerNum
            {
                get { return playernum; }
                set { playernum = value; }
            }
            public string playerPos
            {
                get { return playerpos; }
                set { playerpos = value; }
            }
        }

        public class Team
        {
            string teamname;
            string teamcountry;
            string teamcity;
            public List<Player> Players = new List<Player>();
            public string TeamName
            {
                get { return teamname; }
                set { teamname = value; }
            }
            public string TeamCountry
            {
                get { return teamcountry; }
                set { teamcountry = value; }
            }
            public string TeamCity
            {
                get { return teamcity; }
                set { teamcity = value; }
            }
            public void addingplayer(string name, string num, string pos)
            {
                Player playerz = new Player();
                playerz.playerName = name;
                playerz.playerNum = num;
                playerz.playerPos = pos;
                Players.Add(playerz);
            }
        }
        List<Team> teamlist = new List<Team>();
        List<string> countrylist = new List<string>();
        public void addingteam(string name, string country, string city)
        {
            if (teamlist.Any(tim => tim.TeamName == name))
            {
                MessageBox.Show("Team Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!countrylist.Contains(country))
            {
                countrylist.Add(country);
                comboBoxcountry.Items.Add(country);
            }
            Team newTeam = new Team { TeamName = name, TeamCountry = country, TeamCity = city };
            teamlist.Add(newTeam);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxpos.Items.Add("GK");
            comboBoxpos.Items.Add("DF");
            comboBoxpos.Items.Add("MF");
            comboBoxpos.Items.Add("FW");
            addingteam("Japan National Team", "Japan", "Tokyo");
            addingteam("Manchester City", "England", "Manchester");
            addingteam("Brazil National Team", "Brazil", "Brazil");

            foreach (Team tim in teamlist)
            {
                if (tim.TeamName == "Japan National Team")
                {
                    tim.addingplayer("Eiji Kawashima", "1", "GK");
                    tim.addingplayer("Yuto Nagatomo", "5", "DF");
                    tim.addingplayer("Maya Yoshida", "22", "DF");
                    tim.addingplayer("Gen Shoji", "3", "DF");
                    tim.addingplayer("Hiroki Sakai", "19", "DF");
                    tim.addingplayer("Gaku Shibasaki", "16", "MF");
                    tim.addingplayer("Makoto Hasebe", "17", "MF");
                    tim.addingplayer("Takashi Inui", "8", "MF");
                    tim.addingplayer("Shinji Kagawa", "10", "MF");
                    tim.addingplayer("Yuya Osako", "18", "FW");
                    tim.addingplayer("Keisuke Honda", "4", "FW");
                }
            }

            foreach (Team tim in teamlist)
            {
                if (tim.TeamName == "Manchester City")
                {
                    tim.addingplayer("Ederson", "31", "GK");
                    tim.addingplayer("Joao Cancelo", "27", "DF");
                    tim.addingplayer("John Stones", "05", "DF");
                    tim.addingplayer("Ruben Dias", "03", "DF");
                    tim.addingplayer("Kyle Walker", "02", "DF");
                    tim.addingplayer("Fernandinho", "25", "MF");
                    tim.addingplayer("Rodri", "16", "MF");
                    tim.addingplayer("Kevin De Bruyne", "17", "MF");
                    tim.addingplayer("Riyad Mahrez", "26", "FW");
                    tim.addingplayer("Phil Foden", "47", "FW");
                    tim.addingplayer("Erling Haaland", "09", "FW");
                }
            }

            foreach (Team tim in teamlist)
            {
                if (tim.TeamName == "Brazil National Team")
                {
                    tim.addingplayer("Alisson Becker", "1", "GK");
                    tim.addingplayer("Danilo", "2", "DF");
                    tim.addingplayer("Thiago Silva", "3", "DF");
                    tim.addingplayer("Marquinhos", "4", "DF");
                    tim.addingplayer("Alex Sandro", "6", "DF");
                    tim.addingplayer("Casemiro", "5", "MF");
                    tim.addingplayer("Fabinho", "8", "MF");
                    tim.addingplayer("Philippe Coutinho", "11", "MF");
                    tim.addingplayer("Neymar Jr", "10", "FW");
                    tim.addingplayer("Roberto Firmino", "20", "FW");
                    tim.addingplayer("Gabriel Jesus", "9", "FW");
                }
            }
        }
        private List<Team> teams = new List<Team>();
        private void buttonaddteam_Click(object sender, EventArgs e)
        {
            string name = textBoxteamname.Text.Trim();
            string country = textBoxteamcountry.Text.Trim();
            string city = textBoxteamcity.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city))
            {
                MessageBox.Show("All Of The Fields Need To Be Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (teamlist.Any(t => t.TeamName == name))
            {
                MessageBox.Show("Team Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var team = new Team()
            {
                TeamName = name,
                TeamCountry = country,
                TeamCity = city
            };

            teamlist.Add(team);

            if (!countrylist.Contains(country))
            {
                countrylist.Add(country);
                comboBoxcountry.Items.Add(country);
            }

            textBoxteamname.Text = "";
            textBoxteamcountry.Text = "";
            textBoxteamcity.Text = "";
        }
        private void buttonaddplayer_Click(object sender, EventArgs e)
        {
            if (textBoxplayername.Text == "" || textBoxplayernumber.Text == "" || comboBoxpos.SelectedIndex < 0)
            {
                MessageBox.Show("All Of The Fields Need To Be Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (Team tim in teamlist)
                {
                    if (tim.TeamName == comboBoxteam.SelectedItem.ToString())
                    {
                        tim.addingplayer(textBoxplayername.Text, textBoxplayernumber.Text, comboBoxpos.SelectedItem.ToString());
                        int cekplayernamedouble = 0;
                        int cekplayernumdouble = 0;
                        foreach (Player pemain in tim.Players)
                        {
                            if (pemain.playerName == textBoxplayername.Text)
                            {
                                cekplayernamedouble++;
                            }
                            if (pemain.playerNum == textBoxplayernumber.Text)
                            {
                                cekplayernumdouble++;
                            }
                        }
                        if (cekplayernamedouble > 1)
                        {
                            tim.Players.RemoveAt(tim.Players.Count - 1);
                            MessageBox.Show("Player With The Same Name Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (cekplayernumdouble > 1)
                        {
                            tim.Players.RemoveAt(tim.Players.Count - 1);
                            MessageBox.Show("Player With The Same Number Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            comboBoxpos.SelectedIndex = -1;
            textBoxplayername.Text = "";
            textBoxplayernumber.Text = "";
            listBox1.Items.Clear();
            foreach (Team tim in teamlist)
            {
                if (tim.TeamName == comboBoxteam.SelectedItem.ToString())
                {
                    foreach (Player pemain in tim.Players)
                    {
                        listBox1.Items.Add($"(" + pemain.playerNum + ")" + " " + pemain.playerName + ", " + pemain.playerPos);
                    }
                }
            }
            listBox1.Sorted = true;
        }
        private void comboBoxcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = comboBoxcountry.SelectedItem.ToString();
            comboBoxteam.Items.Clear();
            foreach (var team in teamlist.Where(t => t.TeamCountry == selectedCountry))
            {
                comboBoxteam.Items.Add(team.TeamName);
            }
        }


        private void comboBoxteam_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Team tim in teamlist)
            {
                if (tim.TeamName == comboBoxteam.SelectedItem.ToString())
                {
                    foreach (Player pemain in tim.Players)
                    {
                        listBox1.Items.Add($"(" + pemain.playerNum + ")" + " " + pemain.playerName + ", " + pemain.playerPos);
                    }
                }
            }
            listBox1.Sorted = true;
        }

        private void buttonremove_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 11)
            {
                MessageBox.Show("Unable To Remove Players If Players Less Than Equal 11", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (listBox1.SelectedItem == null || comboBoxteam.SelectedItem == null)
                {
                    MessageBox.Show("Please select a team and a player to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Team selectedTeam = teamlist.FirstOrDefault(t => t.TeamName == comboBoxteam.SelectedItem.ToString());
                if (selectedTeam == null)
                {
                    MessageBox.Show("Selected team not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Player selectedPlayer = selectedTeam.Players.FirstOrDefault(p => $"({p.playerNum}) {p.playerName}, {p.playerPos}" == listBox1.SelectedItem.ToString());
                if (selectedPlayer == null)
                {
                    MessageBox.Show("Selected player not found in the selected team.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedTeam.Players.Remove(selectedPlayer);
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox1.Sorted = true;
            }
        }
    }
}
