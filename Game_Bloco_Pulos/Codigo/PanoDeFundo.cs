using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Bloco_Pulos.Codigo
{
    class PanoDeFundo : EntityBase
    {
        public PanoDeFundo(Size bounds, Graphics screen) : base(bounds, screen)
        {
            X = 0;
            Y = 0;
            Altura = bounds.Height;
            Largura = bounds.Width;

        }

        public override void Desenha()
        {
            Screen.FillRectangle(Brushes.CornflowerBlue, Rect);
        }
    }
}
