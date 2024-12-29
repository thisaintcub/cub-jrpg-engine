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
using shy_jrpg_engine.src.objects;
using shy_jrpg_engine.src.scenes;
#endregion

namespace shy_jrpg_engine.src.engine.scene {
    public class SceneManager {
        private readonly Stack<IScene> sceneStack;

        public SceneManager() {
            sceneStack = new();
        }

        public void AddScene(IScene scene) {
            scene.Load();

            sceneStack.Push(scene);
        }

        public void RemoveScene(IScene scene) {
            sceneStack.Pop();
        }

        public IScene CurrentScene() {
            return sceneStack.Peek();
        }
    }
}
