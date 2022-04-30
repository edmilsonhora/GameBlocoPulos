using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Bloco_Pulos.Codigo
{
    class Obstaculo : EntityBase
    {
        Random _random;
        Brush _brush;
        Brush[] _bru = { Brushes.YellowGreen, Brushes.Aquamarine, Brushes.LemonChiffon, Brushes.Black };
        public Obstaculo(Size bounds, Graphics screen, Random random) : base(bounds, screen)
        {
            _random = random;
            _brush = _bru[random.Next(0, 4)];
            Altura = _random.Next(60, 150);
            Largura = _random.Next(30, 70);
            X = bounds.Width;
            Y = (Bounds.Height - 100) - Altura;
        }

        public bool Inativo { get; private set; }

        public void EstaForaDaTela()
        {
            if (X <= -Largura)
                Inativo = true;
        }

        public bool EstaColidindo(Bloco bloco)
        {
            return this.Rect.IntersectsWith(bloco.Rect);
        }

        public override void Desenha()
        {
            Screen.FillRectangle(_brush, Rect);
        }

        public void Mover()
        {
            X -= 3;
        }
    }
}
