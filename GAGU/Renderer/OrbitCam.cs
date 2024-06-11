using GAGU.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAGU.Renderer
{
    public class OrbitCam : ICamera
    {
        //for interface
        public Matrix View => view;
        public Matrix Projection => projection;
        //camera variables
        Matrix view;
        Matrix projection;
        float speed;
        float angle; //camera angle
        Vector3 position;
        Game game;

        public OrbitCam (Game game, Vector3 position, float speed)
        {
            this.game = game;
            this.speed = speed;
            this.position = position;
            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.GraphicsDevice.Viewport.AspectRatio, 1, 1000);
            this.view = Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
        }

        public void Update(GameTime gameTime)
        {
            // update the angle based on the elapsed time and speed
            angle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate a new view matrix
            this.view =
                Matrix.CreateRotationY(angle) *
                Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
        }
    }
}
