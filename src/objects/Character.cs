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
    public class Character {
        private AnimatedSprite[] animations;
        public AnimatedSprite curanim;
        public int animnum = 0;
        public Vector2 position;
        public static float speed, speedX = 0f, speedY = 0f;

        public Character(Texture2D playerSheet) {
            animations = new AnimatedSprite[69];
            // idle
            animations[0] = new AnimatedSprite(playerSheet, 0, 1, 48, 48, 2); // up
            animations[1] = new AnimatedSprite(playerSheet, 0, 0, 48, 48, 2); // down
            animations[2] = new AnimatedSprite(playerSheet, 0, 2, 48, 48, 2); // left
            animations[3] = new AnimatedSprite(playerSheet, 0, 3, 48, 48, 2); // right
            // walking
            animations[4] = new AnimatedSprite(playerSheet, 2, 1, 48, 48, 2); // down
            animations[5] = new AnimatedSprite(playerSheet, 2, 0, 48, 48, 2); // up
            animations[6] = new AnimatedSprite(playerSheet, 2, 2, 48, 48, 2); // left
            animations[7] = new AnimatedSprite(playerSheet, 2, 3, 48, 48, 2); // right

            position = new Vector2(0, 0);
            curanim = animations[animnum];
        }
        public Rectangle Rect {
            get {
                return new Rectangle((int)position.X, (int)position.Y, (int)curanim.width, (int)curanim.height);
            }
        }

        public void Update(GameTime gametime) {
            curanim = animations[animnum];

            if (Globals.keyboard.GetPress("LeftShift") || Globals.keyboard.GetPress("RightShift"))
                speed = 3f;
            else
                speed = 1.5f;

            if (Globals.keyboard.GetPress("Left")) {
                animnum = 6;
                speedX = -speed;
            } else if (Globals.keyboard.GetPress("Right")) {
                animnum = 7;
                speedX = speed;
            } else
                speedX = 0f;

            if (Globals.keyboard.GetPress("Up")) {
                animnum = 4;
                speedY = -speed;
            } else if (Globals.keyboard.GetPress("Down")) {
                animnum = 5;
                speedY = speed;
            } else
                speedY = 0f;

            position.X += speedX;
            position.Y += speedY;
            if (speedX == 0 && speedY == 0) {
                if (animnum >= 4)
                    animnum = animnum - 4;
            }
        }

        public void PlayerDraw() {
            curanim.Draw(position, 300);
        }
    }
}
