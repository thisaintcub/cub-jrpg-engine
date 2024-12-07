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
using shy_jrpg_engine.src.sprites;
using shy_jrpg_engine.src.engine;
using shy_jrpg_engine.src.objects;
using shy_jrpg_engine.src.scenes;
#endregion

namespace shy_jrpg_engine.src.sprites {
    public class AnimatedSprite { // tr1ngle got mad so classes start with uppercase letter now
        public Texture2D spriteSheet;
        public int columnX, columnY;
        public int width, height;
        public int frames;
        public int curFrame = 0;
        public int timeSinceLastFrame = 0;

        public AnimatedSprite(Texture2D spriteSheet, int columnX, int columnY, int width, int height, int frames) {
            this.spriteSheet = spriteSheet;
            this.columnX = columnX;
            this.columnY = columnY;
            this.width = width;
            this.height = height;

            if (frames == 0)
                this.frames = this.spriteSheet.Height / width;
            else
                this.frames = frames;
        }

        public void Draw(Vector2 pos, int msperframe = 500) {
            if (curFrame < frames) {
                Globals.spriteBatch.Draw(spriteSheet, pos, new Rectangle(width * (curFrame + columnX), height * columnY, 48, 48), Color.White);
                timeSinceLastFrame += Globals.gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > msperframe) {
                    timeSinceLastFrame -= msperframe;
                    curFrame++;
                    if (curFrame == frames)
                        curFrame = 0;
                }
            }
        }
    }
}