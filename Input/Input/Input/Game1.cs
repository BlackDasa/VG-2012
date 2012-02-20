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
    /// Questo è il tipo principale per il gioco
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ProvaTesto _mouseText;

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
            _mouseText = new ProvaTesto(this);
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
            _mouseText.LoadFont("font");
            _mouseText.Position = new Vector2(10,50);
            _mouseText.Scale = new Vector2(1);
            _mouseText.Rotation = 0;
            _mouseText.Color = Color.White;
            _mouseText.Batch = spriteBatch;


            // TODO: utilizzare this.content per caricare qui il contenuto del gioco
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
            //INPUT - MOUSE
            MouseState mState = Mouse.GetState();

            _mouseText.Text = "Mouse Position:{" + mState.X + "," + mState.Y + "}";//mostro la posizione del mouse
            _mouseText.Update(gameTime);

            if (mState.LeftButton == ButtonState.Pressed)//se ho premuto il tasto sinistro
                _mouseText.Color = Color.Black;//cambio il colore del font

            //NOTA: mState ha altre proprietà per verificare lo stato dei tasti del mouse

            //INPUT - TESTIERA
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Escape))//Se ho premuto il tasto ESC
                this.Exit();//termino l'applicazione

            //NOTA: Keys contiene la definizione di tutti i tasti della tastiera.
            //Per verificare che un tasto sia (o non sia) premuto basta inserire Keys.NOMETASTO)

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
            spriteBatch.Begin();


            _mouseText.Draw(gameTime);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
