using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Input
{
    /// <summary>
    /// Classe che reappresenta una stringa.
    /// </summary>
    public class ProvaTesto : Microsoft.Xna.Framework.DrawableGameComponent
    {

        private SpriteFont font;//font da utilizzare
        private SpriteBatch spriteBatch;//Batcher per il disegno della stringa
        private Vector2 position;//posizione della stringa
        private string text;//testo della stringa
        private Color color;//colore della stringa
        private float rotation;//rotazione della stringa
        private Vector2 scale;//Scala della stringa

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public SpriteBatch Batch{
            set { spriteBatch = value; }
            get { return spriteBatch; }
        }


        public ProvaTesto(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Carica uno Sprite Font da file.
        /// </summary>
        /// <param name="fileName">Il nome del file dello sprite font</param>
        public void LoadFont(string fileName)
        {
            font = Game.Content.Load<SpriteFont>(fileName);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            //disegno la stringa con i parametri scelti
            spriteBatch.DrawString(font, text, position, color, rotation, Vector2.Zero, scale, SpriteEffects.None, 0);

            base.Draw(gameTime);
        }

    }
}
