using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Bloco_Pulos.Codigo
{
    class Bloco : EntityBase
    {
        const int gravidade = 3;
        const int forcaPulo = 29;
        public Bloco(Size bounds, Graphics screen) : base(bounds, screen)
        {
            X = 50;
            Y = 0;
            Altura = 50;
            Largura = 50;
        }

        public int Velocidade { get; set; }

        public override void Desenha()
        {
            Screen.FillRectangle(Brushes.DarkRed, Rect);
        }

        public void Gravidade()
        {
            Velocidade += gravidade;
            Y += Velocidade;

            if (Y >= Bounds.Height - 107)
                Y = (Bounds.Height - 100) - Altura;

        }

        public void Pular()
        {
            Velocidade = 0;
            Velocidade = -forcaPulo;
            
            
        }
    }
}
