using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GAGU.Interfaces;

namespace GAGU.Renderer
{
    public class triangle
    {
        //define cords for triangle
        VertexPositionColor[] vertices;
        
        //shader
        BasicEffect basicEffect;
        
        //game
        Game Game;
        public triangle(Game game)
        {
            //class constructor
            this.Game = game;
            InitTriangle();
            InitEffect();
        }
        public void Update (GameTime gameTime)
        {
            //speen
            float angle = (float)gameTime.TotalGameTime.TotalSeconds;
            basicEffect.World = Matrix.CreateRotationY(angle);
        }
        public void Draw(ICamera camera )
        {
            //cache old state
            RasterizerState oldstate = Game.GraphicsDevice.RasterizerState;

            //disable backface culling 
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            Game.GraphicsDevice.RasterizerState = rasterizerState;

            //draw the triange
            basicEffect.View = camera.View;
            basicEffect.Projection = camera.Projection;
            basicEffect.CurrentTechnique.Passes[0].Apply();
            Game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
            vertices, //vertex data
            0, //first vertex in array to use
            1 //set number of triagnles to draw
            );

            //restore to the prior rastorization state
            Game.GraphicsDevice.RasterizerState = oldstate;
        }
        void InitTriangle()
        {
            //this defines the points in space the triangle is at, as well as blends colors
            vertices = new VertexPositionColor[3];
            //vertex 1 
            vertices[0].Position = new Vector3(0,1,0);
            vertices[0].Color = Color.Red;
            //vertex 2
            vertices[1].Position = new Vector3(0,0,1);
            vertices[1].Color = Color.Green;
            //vertex 3
            vertices[2].Position = new Vector3(0,0,0);
            vertices[2].Color = Color.Blue;
        }

        void InitEffect()
        {
            //this creates a shader, and sets our world/view/projection matricies

            basicEffect = new BasicEffect(Game.GraphicsDevice);
            basicEffect.World = Matrix.Identity;
            basicEffect.View = Matrix.CreateLookAt(
                    new Vector3(0,0,4), //camera position
                    new Vector3(0,0,0),//camera target
                    Vector3.Up //camera's up vector 
                );
            basicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.PiOver4, //fov
                    Game.GraphicsDevice.Viewport.AspectRatio, //aspect ratio (duh)
                    0.1f, //camera near
                    100.0f //camera far
                ) ;
            basicEffect.VertexColorEnabled = true;
        }

    }
}
