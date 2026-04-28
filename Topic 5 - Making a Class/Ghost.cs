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
        private float _animationSpeed, _seconds;
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

        public bool Contains(Point player) 
        { 
            return _location.Contains(player);
        }

        public bool Intersects(Rectangle player) 
        { 
            return _location.Intersects(player); 
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[0], _location, Color.White);
            spriteBatch.Draw(_textures[_textureIndex], _location, null, Color.White, 0f, Vector2.Zero, _direction, 1);
        }

        public void Update(MouseState mouseState, GameTime gameTime) 
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
                _speed.Y = 1;
            }
            if (mouseState.LeftButton == ButtonState.Released)
            {
                _speed = Vector2.Zero;
            }
            if (mouseState.LeftButton == ButtonState.Released)
            {
                _speed = Vector2.Zero; // Sets speed to zero if mouse not clicked
                _textureIndex = 0;
                _seconds = 0f;
            }
            else if (_speed != Vector2.Zero) // Ghost is moving
            {
                _seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_seconds > _animationSpeed)
                {
                    _seconds = 0;
                    _textureIndex++;
                    if (_textureIndex >= _textures.Count)
                        _textureIndex = 1;

                }
            }
            _location.Offset(_speed);
            _animationSpeed = 0.2f;
            _seconds = 0;
            _location.Offset(_speed);



        }
        
   
        
    }
}
