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
        public Rectangle _rect;
        public Vector2 _speed;
        public Tribble(Texture2D texture, Rectangle rectangle, Vector2 speed)
        {
            _texture = texture;
            _rect = rectangle;
            _speed = speed;
        }
        public Texture2D Texture
        {
            get
            {
                return _texture;
            }
        }



    }
}
