#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using input;
using System.Data;
using cub_jrpg_engine.src.sprites;
using cub_jrpg_engine.src.engine;
using cub_jrpg_engine.src.objects;
using cub_jrpg_engine.src.scenes;
#endregion

namespace cub_jrpg_engine.src.sprites {
    public class Sprite {
        public Texture2D texture;
        public Vector2 position, origin;
        public float width, height;
        public Color color;
        public Rectangle Rect {
            get {
                return new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height);
            } 
        }

        public Sprite(Texture2D texture, Vector2 position, Color color) {
            this.texture = texture;
            this.position = position;
            width = texture.Width;
            height = texture.Height;
            this.color = color;
            origin = new(texture.Width / 2, texture.Height / 2);
        }
    }
}
