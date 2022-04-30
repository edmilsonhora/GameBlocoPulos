using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Bloco_Pulos.Codigo
{
   abstract class EntityBase
    {
        public EntityBase(Size bounds, Graphics screen)
        {
            this.Bounds = bounds;
            this.Screen = screen;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public Graphics Screen { get; set; }
        public Size Bounds { get; set; }
        public Rectangle Rect { get { return new Rectangle(X, Y, Largura, Altura); } }

        public abstract void Desenha();
    }
}
