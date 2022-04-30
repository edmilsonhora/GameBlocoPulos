using Game_Bloco_Pulos.Codigo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Game_Bloco_Pulos
{
    public partial class Form1 : Form
    {
        int tempoCriarObstaculo = 0;
        Random random;
        Bitmap screenBuffer;
        Graphics screenPainter;
        DispatcherTimer gameTimer;
        DispatcherTimer obstaculosTimer;

        PanoDeFundo panoDeFundo;
        List<Obstaculo> obstaculos;
        Chao chao;
        Bloco bloco;


        public Form1()
        {
            InitializeComponent();
            random = new Random();
            screenBuffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            screenPainter = Graphics.FromImage(screenBuffer);
            panoDeFundo = new PanoDeFundo(ClientSize, screenPainter);
            chao = new Chao(Bounds.Size, screenPainter);
            obstaculos = new List<Obstaculo>();
            bloco = new Bloco(Bounds.Size, screenPainter);

            gameTimer = new DispatcherTimer(DispatcherPriority.Render);
            gameTimer.Interval = TimeSpan.FromMilliseconds(16.666);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            obstaculosTimer = new DispatcherTimer(DispatcherPriority.Render);
            obstaculosTimer.Interval = TimeSpan.FromMilliseconds(100);
            obstaculosTimer.Tick += ObstaculosLoop;
            obstaculosTimer.Start();

        }


        public void GameLoop(object sender, EventArgs e)
        {
            panoDeFundo.Desenha();
            obstaculos.RemoveAll(x => x.Inativo);

            bloco.Gravidade();
            bloco.Desenha();
            chao.Desenha();

            foreach (var item in obstaculos)
            {
                item.Desenha();
                item.Mover();
                if (item.EstaColidindo(bloco))
                {
                    gameTimer.Stop();
                    obstaculosTimer.Stop();
                }
                item.EstaForaDaTela();
            }           

            Invalidate();
        }

        public void ObstaculosLoop(object sender, EventArgs e)
        {
            if (tempoCriarObstaculo <= 0)
            {
                obstaculos.Add(new Obstaculo(Bounds.Size, screenPainter, random));
                tempoCriarObstaculo = random.Next(26, 56);
            }
            tempoCriarObstaculo--;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(screenBuffer, 0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                bloco.Pular();
        }


    }
}
