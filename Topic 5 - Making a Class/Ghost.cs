using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_5___Making_a_Class
{
    public class Ghost
    {
        private List<Texture2D> _textures;
        private Vector2 _speed;
        private Rectangle _location;
        private int _textureIndex;
        private SpriteEffects _direction;

        private enum Screen
        {
            Title,
            House,
            End
        }

        public Rectangle Rect
        {
            get { return _location; }
        }

        public List<Texture2D> GhostTextures { get { return _textures; } }

        public Ghost(List<Texture2D> textures, Rectangle location)
        {
            _textures = textures;
            _textureIndex = 0;
            _speed = Vector2.Zero;
            _location = location;
        }







        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[0], _location, Color.White);
        }

        public void Update(MouseState mouseState) 
        {
            _direction = SpriteEffects.None;

            if (mouseState.X < _location.X)
            {
                _direction = SpriteEffects.FlipHorizontally;
                _speed.X = -1;
            }
            else if (mouseState.X > _location.X)
            {
                _direction = SpriteEffects.None;
                _speed.X = 1;
            }

            if (mouseState.Y < _location.Y)
            {
                _direction = SpriteEffects.None;
                _speed.Y = -1;
            }
            else if (mouseState.Y > _location.Y)
            {
                _direction = SpriteEffects.None;
                _speed.X = 1;
            }
        }
        
   
        
    }
}
