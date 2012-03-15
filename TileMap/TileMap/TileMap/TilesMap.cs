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
    /// Componente di gioco che implementa le funzionalità di una TileMap
    /// </summary>
    public class TilesMap : Microsoft.Xna.Framework.DrawableGameComponent{

        private Rectangle _cameraRectangle;//camera per il disegno della scena
        private Rectangle _bounding;//contorno della mappa
        private Texture2D _tilesTexture;//texture contenente i tile della mappa
        private int _blockTextureWidth;//blocchi presenti nella texture in larghezza
        private int _blockTextureHeight;//blocchi presenti nella texture in altezza

        private int _tileSize;//dimensione in pixel di ogni tile presente nella texture
        private string _textureName;
        private int[,] _map;//matrici di interi che rappresenta la mappa
        private int _width;//larghezza della mappa in tiles
        private int _height;//altezza della mappa in tiles
        private SpriteBatch _spriteBatch;//sprite batch utilizzato per il disegno dei tiles

        //Limiti per il disegno della mappa in base alla camera.
        private int _startX;
        private int _startY;
        private int _limitX;
        private int _limitY;

        /// <summary>
        /// Ottiene od imposta un rettangolo che rappresenta l'area di mappa da visualizzare.
        /// </summary>
        public Rectangle Camera{
            get { return _cameraRectangle; }
            set { _cameraRectangle = value; }
        }

        public SpriteBatch Batcher{
            set { _spriteBatch = value; }
        }

        /// <summary>
        /// Crea una nuova mappa composta da tile.
        /// </summary>
        /// <param name="game">Un'istanza della classe Game che rappresenta il gioco in cui viene creata la mappa.</param>
        /// <param name="sBatch">Un'istanza della classe SpriteBatch utilizzata per il disegno dei tiles.</param>
        /// <param name="tilesTexture">La texture contente i tiles della mappa.</param>
        /// <param name="sizePerTile">Dimensione in pixel per ogni tile.</param>
        /// <param name="blocksWidth">Numero di tile di larghezza della mappa.</param>
        /// <param name="blocksHeight">Numero di tile in altezza della mappa.</param>
        public TilesMap(Game game,string textureName,int sizePerTile,int blocksWidth,int blocksHeight)
            : base(game){
                //Imposto i dai di default
                _textureName = textureName;
                _tileSize = sizePerTile;
                _width = blocksWidth;
                _height = blocksHeight;
                //Calcolo il numero di blocchi presenti nella texture
                _bounding = new Rectangle(0, 0, _width * _tileSize, _height * _tileSize);
        }

        /// <summary>
        /// Metodo per inizializzare la mappa con dei valori di debug
        /// </summary>
        private void InitMapData(){
            Random rand=new Random(10);
            int i = 0;
            int total=_blockTextureWidth*_blockTextureHeight;
            for (int y = 0; y < _height; y++)
                for (int x = 0; x < _width; x++)
                    _map[y, x] = i++;// rand.Next(1,total);//genero un blocco casuale
        }

        /// <summary>
        /// Ottiene un valore booleano che indica su è consentito il passaggio nel punto specificato.
        /// </summary>
        /// <param name="point">Un vettore a 2 dimensioni che rappresenta il punto in cui si vuole passare.</param>
        /// <returns>True se il passaggio è convertito, false altrimenti</returns>
        public bool CanPass(Vector2 point){
            return true;//TODO: convertire coordinate in indici mappa e restituire valore
        }

        /// <summary>
        /// Consente al componente del gioco di eseguire l'inizializzazione necessaria prima dell'inizio
        /// dell'esecuzione. Qui è possibile eseguire query per eventuali servizi necessari e caricare contenuto.
        /// </summary>
        public override void Initialize(){
            _map = new int[_height, _width];//creo la matrice per la gestione della mappa
            for (int y = 0; y < _height; y++)
                for (int x = 0; x < _width; x++)
                    _map[y, x] = 0;//imposto ogni elemento ad un valore di default

            base.Initialize();
        }

        /// <summary>
        /// Carica le risorse necessarie per la rappresentazione della mappa.
        /// </summary>
        protected override void LoadContent(){
            _tilesTexture = Game.Content.Load<Texture2D>(_textureName);//carico la texture
            //imposto i valori dei blocchi presenti nella texture
            _blockTextureWidth = _tilesTexture.Width / _tileSize;
            _blockTextureHeight = _tilesTexture.Height / _tileSize;

            InitMapData();//da sostituire con il caricamento delle informazioni da file

            base.LoadContent();
        }

        /// <summary>
        /// Consente al componente del gioco di aggiornare se stesso.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        public override void Update(GameTime gameTime){

            if(_bounding.Intersects(_cameraRectangle)){//se la mappa è in parte visibile dalla camera
                //calcolo i limiti per il disegno dei tiles
                Rectangle limits = Rectangle.Intersect(_bounding, _cameraRectangle);//calcolo il rettangolo di intersezione

                _startX = (int)Math.Floor( (double)limits.X / (double)_width);
                _startY = (int)Math.Floor( (double)limits.Y / (double)_height);

                _limitX = (int)Math.Ceiling( (double)limits.Width / (double)_tileSize);
                _limitY = (int)Math.Ceiling((double)limits.Height / (double)_tileSize);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Rilascia le risorse utilizzate dalla mappa
        /// </summary>
        protected override void UnloadContent(){
            _tilesTexture.Dispose();
            base.UnloadContent();
        }

        /// <summary>
        /// Disegna la mappa.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        public override void Draw(GameTime gameTime){
            //Variabili ausiliari per l'identificazione di un singolo tile
            Vector2 tempPos=Vector2.Zero;
            Rectangle tempSource = new Rectangle(0, 0, _tileSize, _tileSize);

            //Inizio il disegno
            _spriteBatch.Begin();
            //TODO: disegnare blocchi in base a limiti
            for (int x = _startX; x <_limitX; x++){
                tempPos.X = x * _tileSize;
                for (int y = _startY; y < _limitY; y++){
                    //calcolo la posizione del tile
                    tempPos.Y = y * _tileSize;
                    //calcolo il tile da disegnare.
                    int tileIndex = _map[y, x];//ottengo l'elemento da disegnare

                    tempSource.Location = new Point((tileIndex % _blockTextureWidth * _tileSize), (tileIndex / _blockTextureHeight) * _tileSize);

                    _spriteBatch.Draw(_tilesTexture, tempPos, tempSource, Color.White);
                }
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
