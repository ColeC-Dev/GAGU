using GAGU.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAGU.Camera
{
    public class first_person : ICamera
    {
        //for interface
        public Matrix View => view;
        public Matrix Projection => projection;
        Matrix view;
        Matrix projection;
        //calculations
        float hAngle;
        float vAngle;
        Vector3 pos;
        //mouse state
        MouseState m_state;
        public float mouse_sens { get; set; } = 0.0010f;
        //speed
        public float speed { get; set; } = 0.10f;

        Game game;

        public first_person(Game game, Vector3 pos)
        {
            this.game = game;
            this.pos = pos;
            this.hAngle = 0;
            this.vAngle = 0;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.GraphicsDevice.Viewport.AspectRatio, 1, 1000);
            Mouse.SetPosition(game.Window.ClientBounds.X /2, game.Window.ClientBounds.Y / 2);
            m_state = Mouse.GetState();
        }

        public void updateCam_fps(GameTime gameTime)
        {
            var keys = Keyboard.GetState();
            var mouse = Mouse.GetState();
            var facing = Vector3.Transform(Vector3.Forward, Matrix.CreateRotationY(hAngle));
            //handle input
            if (keys.IsKeyDown(Keys.W)) { pos += facing * speed; }
            if (keys.IsKeyDown(Keys.S)) { pos -= facing * speed; }
            if (keys.IsKeyDown(Keys.A)) { pos += Vector3.Cross(Vector3.Up, facing) * speed; }
            if (keys.IsKeyDown(Keys.D)) { pos -= Vector3.Cross(Vector3.Up, facing) * speed; }
            //mouse
            hAngle += mouse_sens * (m_state.X - mouse.X);
            vAngle += mouse_sens * (m_state.Y - mouse.Y);
            //calculate direction
            var direction = Vector3.Transform(Vector3.Forward, Matrix.CreateRotationX(vAngle) * Matrix.CreateRotationY(hAngle));
            view = Matrix.CreateLookAt(pos, pos + direction, Vector3.Up);
            //reset mouse state
            Mouse.SetPosition(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);
            m_state = Mouse.GetState();
        }
    }
}
