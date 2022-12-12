using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Animation
{
    class Tribble
    {
        private Texture2D _texture;
        private Rectangle _bounds;
        private Color _colour;
        private Vector2 _speed;        
        public Tribble(Texture2D texture, Rectangle bounds, Vector2 speed, Color colour)
        {
            _texture = texture;
            _bounds = bounds;
            _colour = colour;
            _speed = speed;

        }
        public Tribble(bool b)
        {

        }
        public Texture2D texture
        {
            get
            {
                return _texture;
            }
        }
        public Rectangle bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }
        public Color colour
        {
            get { return _colour; }            
        }
        public Vector2 speed
        {
            get { return _speed;}
        }
        public void Move(GraphicsDeviceManager graph)
        {
            _bounds.Offset(_speed);
            if (_bounds.Right > graph.PreferredBackBufferWidth || _bounds.Left < 0)
                _speed.X *= -1;
            _bounds.X += (int)_speed.X;
            if (_bounds.Bottom > graph.PreferredBackBufferHeight || _bounds.Top < 0)
                _speed.Y *= -1;
            _bounds.Y += (int)_speed.Y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, colour);
        }
    }

}
