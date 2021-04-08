using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monogame_3___Animations_Part_2_Lists
{
    public class Tribble
    {
        private Texture2D _texture;
        private Rectangle _rect;
        private Vector2 _speed;

        
        public Tribble(Texture2D texture, Rectangle rectangle, Vector2 speed)
        {
            _texture = texture;
            _rect = rectangle;
            _speed = speed;
        }

        public void move()
        {
            _rect.Offset(_speed);
        }

        public void bumpSide()
        {
            _speed.X *= -1;
        }

        public void bumpTopBottom()
        {
            _speed.Y *= -1;
        }

        public Rectangle Bounds
        {
            get { return _rect; }
            set { _rect = value; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }
        //public Vector2 Speed
        //{
        //    get { return _speed; }
        //    set { _speed = value; }
        //}


    }
}
