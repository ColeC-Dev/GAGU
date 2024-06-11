using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GAGU.Interfaces
{
    public interface ICamera
    {
        Matrix View { get; }
        Matrix Projection { get; }
    }
}
