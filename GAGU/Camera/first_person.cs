using GAGU.Interfaces;
using Microsoft.Xna.Framework;
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

    }
}
