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

namespace input;

public class Input {
    public KeyboardState newKeyboard, oldKeyboard;

    public List<Key> pressedKeys = new List<Key>(), previousPressedKeys = new List<Key>();

    public Input() { }

    public virtual void Update() {
        newKeyboard = Keyboard.GetState();

        GetPressedKeys();
    }

    public void UpdateOld() {
        oldKeyboard = newKeyboard;

        previousPressedKeys = new List<Key>();
        for (int i = 0; i < pressedKeys.Count; i++)
            previousPressedKeys.Add(pressedKeys[i]);
    }

    public bool GetPress(string KEY) {
        for (int i = 0; i < pressedKeys.Count; i++) {
            if (pressedKeys[i].key == KEY)
                return true;
        }
        
        return false;
    }

    public virtual void GetPressedKeys() {
        pressedKeys.Clear();
        for (int i=0; i < newKeyboard.GetPressedKeys().Length; i++) {
                pressedKeys.Add(new Key(newKeyboard.GetPressedKeys()[i].ToString(), 1));
        }
    }
}