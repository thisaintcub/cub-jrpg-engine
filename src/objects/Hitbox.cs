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

namespace cub_jrpg_engine.src.objects {
    public class Hitbox {
        private Texture2D hitbox;
        private Color[] data;
        private int width, height;
        private float offsetX, offsetY;

        public void Load(int w, int h, int x, int y) {
            offsetX = x;
            offsetY = y;
            width = w;
            height = h;
            hitbox = new Texture2D(Globals.graphicsManager.GraphicsDevice, width, height);
            data = new Color[width * height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Red;
            hitbox.SetData(data);
        }

        public void Unload() {
            hitbox.Dispose();
        }

        public void Hide() {
            hitbox = new Texture2D(Globals.graphicsManager.GraphicsDevice, width, height);
            data = new Color[width * height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.White;
            hitbox.SetData(data);
        }

        public void Show() {
            hitbox = new Texture2D(Globals.graphicsManager.GraphicsDevice, width, height);
            data = new Color[width * height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Red;
            hitbox.SetData(data);
        }

        public void Draw(Vector2 pos) {
            Globals.spriteBatch.Draw(hitbox, new Vector2(pos.X + offsetX, pos.Y + offsetY), Color.White);
        }
    }
}