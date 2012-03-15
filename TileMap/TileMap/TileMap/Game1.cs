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

namespace TileMap
{
    /// <summary>
    /// Questo è il tipo principale per il gioco
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TilesMap _map;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _map = new TilesMap(this, "tiles", 17, 12, 10);
            this.Components.Add(_map);
        }

        /// <summary>
        /// Consente al gioco di eseguire tutte le operazioni di inizializzazione necessarie prima di iniziare l'esecuzione.
        /// È possibile richiedere qualunque servizio necessario e caricare eventuali
        /// contenuti non grafici correlati. Quando si chiama base.Initialize, tutti i componenti vengono enumerati
        /// e inizializzati.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: aggiungere qui la logica di inizializzazione

            base.Initialize();
        }

        /// <summary>
        /// LoadContent verrà chiamato una volta per gioco e costituisce il punto in cui caricare
        /// tutto il contenuto.
        /// </summary>
        protected override void LoadContent()
        {
            // Creare un nuovo SpriteBatch, che potrà essere utilizzato per disegnare trame.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _map.Camera = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            _map.Batcher = spriteBatch;

            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent verrà chiamato una volta per gioco e costituisce il punto in cui scaricare
        /// tutto il contenuto.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: scaricare qui tutto il contenuto non gestito da ContentManager
        }

        /// <summary>
        /// Consente al gioco di eseguire la logica per, ad esempio, aggiornare il mondo,
        /// controllare l'esistenza di conflitti, raccogliere l'input e riprodurre l'audio.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Update(GameTime gameTime)
        {
            // Consente di uscire dal gioco
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: aggiungere qui la logica di aggiornamento

            base.Update(gameTime);
        }

        /// <summary>
        /// Viene chiamato quando il gioco deve disegnarsi.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: aggiungere qui il codice di disegno

            base.Draw(gameTime);
        }
    }
}
