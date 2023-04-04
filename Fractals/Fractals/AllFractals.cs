using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals
{
    public abstract class AllFractals
    {
        protected int recursionDepth;
        public AllFractals(int recursionDepth)
        {
            this.recursionDepth = recursionDepth;
        }
        public abstract void Draw();
    }
}
