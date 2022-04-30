using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Bloco_Pulos.Codigo
{
    class Chao : EntityBase
    {
        public Chao(Size bounds, Graphics screen) : base(bounds, screen)
        {
            Altura = 100;
            Largura = bounds.Width;
            X = 0;
            Y = bounds.Height - Altura;
        }

        public override void Desenha()
        {
            Screen.FillRectangle(Brushes.Bisque, Rect);
        }
    }
}
