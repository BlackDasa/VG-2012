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

namespace Sprite
{
    /// <summary>
    /// Questo è il tipo principale per il gioco
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D _tdxture;
        Rectangle _textureBound;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            _tdxture = Content.Load<Texture2D>("Koala");//il carimante avviene come per i font
           
            //Creo il rettangolo per il disegno della texture a schemro intero


            _textureBound = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// UnloadContent verrà chiamato una volta per gioco e costituisce il punto in cui scaricare
        /// tutto il contenuto.
        /// </summary>
        protected override void UnloadContent()
        {
            _tdxture.Dispose();//a differenza dei font, quando ho terminato l'utilizzo rilascio la risorsa
        }

        /// <summary>
        /// Consente al gioco di eseguire la logica per, ad esempio, aggiornare il mondo,
        /// controllare l'esistenza di conflitti, raccogliere l'input e riprodurre l'audio.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Update(GameTime gameTime)
        {
            //ottengo lo stato della tastiera
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Escape))//se ho premuto il testo "ESC"
                this.Exit();//termino l'applicazione

            base.Update(gameTime);
        }

        /// <summary>
        /// Viene chiamato quando il gioco deve disegnarsi.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Disegno una texture a tutto schermo (la texture viene ridimensionata)
           // spriteBatch.Draw(_tdxture,_textureBound, Color.White);

            //disegna una texture in una determinata posizione (la texture non viene ridimensionata)
            spriteBatch.Draw(_tdxture, new Vector2(0, 0), Color.White);

            spriteBatch.End();
            // TODO: aggiungere qui il codice di disegno

            base.Draw(gameTime);
        }
    }
}
