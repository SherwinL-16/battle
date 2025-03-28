using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battle
{
   
    public partial class Form1 : Form

    {
        public  character player;
        private character enemy;
        private int mapIndex = 0;
        private string[] mapImages = { "map1.jpg", "map2.jpg", "map3.jpg" };

        public Form1()
    {
        InitializeComponent();
            ResetBattle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void EnemyAttack()
        {

        }
       
    private void EnemyTurn()
        {
            int action = new Random().Next(1, 4); // Randomly decide enemy's action
            if (action == 1 || enemy.Mana < 20)
            {
                int enemyDamage = Math.Max(enemy.Attack() - player.Defense, 0);
                player.Hp -= enemyDamage;
            }
            else if (action == 2)
            {
                int enemySpecialDamage = Math.Max(enemy.SpecialAttack() - player.Defense, 0);
                player.Hp -= enemySpecialDamage;
            }
            else
            {
                enemy.Defend();
                MessageBox.Show("Enemy increased its defense!");
            }

            UpdateUI();

            if (player.Hp <= 0)
            {
                MessageBox.Show("You lost!");
                ChangeMap();
                ResetBattle();
            }
        }
        private void ResetBattle()
        {
            player = new character("Raichu", 100, 50, 5, 10, 20, 25, 35);
            enemy = new character("Charmander", 100, 50, 5, 8, 18, 20, 30);
            UpdateUI();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int playerDamage = Math.Max(player.Attack() - enemy.Defense, 0);
            enemy.Hp -= playerDamage;
            UpdateUI();

            if (enemy.Hp <= 0)
            {
                MessageBox.Show("You win!");
                ChangeMap();
                ResetBattle();
                return;
            }

            EnemyTurn();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int playerDamage = player.Attack();
            enemy.Hp -= playerDamage;
            UpdateUI();

            if (enemy.Hp <= 0)
            {
                MessageBox.Show("You win!");
                ResetBattle();
                return;
            }

            EnemyTurn();
        }
        private void UpdateUI()
        {
            label1.Text = $"{player.Name} HP: {Math.Max(player.Hp, 0)}";
            label2.Text = $"{enemy.Name} HP: {Math.Max(enemy.Hp, 0)}";
            label3.Text = $"Mana: {player.Mana}";
            label4.Text = $"Mana: {enemy.Mana}";
            label6.Text = $"Defense: {player.Defense}";
            label5.Text = $"Defense: {enemy.Defense}";

            progressBar1.Value = Math.Max(player.Hp, 0);
            progressBar3.Value = Math.Max(enemy.Hp, 0);
            progressBar2.Value = player.Mana;
            progressBar4.Value = enemy.Mana;
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Defend();
            MessageBox.Show("Defense increased!");
            EnemyTurn();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int playerDamage = Math.Max(player.SpecialAttack() - enemy.Defense, 0);
            if (playerDamage == 0)
            {
                MessageBox.Show("Not enough mana!");
                return;
            }
            enemy.Hp -= playerDamage;
            UpdateUI();

            if (enemy.Hp <= 0)
            {
                MessageBox.Show("You win!");
                ChangeMap();
                ResetBattle();
                return;
            }

            EnemyTurn();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeMap();
        }
        private void ChangeMap()
        {
            mapIndex = (mapIndex + 1) % mapImages.Length;
            this.BackgroundImage = Image.FromFile(mapImages[mapIndex]);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
