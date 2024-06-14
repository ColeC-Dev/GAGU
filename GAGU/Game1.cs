using GAGU.Camera;
using GAGU.Renderer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GAGU
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        triangle _triangle;
        OrbitCam _orbitCam;
        first_person _firstPerson;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _triangle = new triangle(this);
            _orbitCam = new OrbitCam(this, new Vector3(0, 5, 10), 0.5f);
            _firstPerson = new first_person(this, new Vector3(0, 3, 10));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _triangle.Update(gameTime);
            _orbitCam.Update(gameTime);
            _firstPerson.updateCam_fps(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            //default cam
            _triangle.Draw(_firstPerson);

            base.Draw(gameTime);
        }
    }
}