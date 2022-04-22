using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCartographer
{
    /// <summary>
    /// Layer that aggregates many CompositeLayerItems
    /// </summary>
    public abstract class CompositeLayer : Layer
    {
        /// <summary>
        /// Unnamed constructor, creates layer of size x and y, and an input name.
        /// </summary>
        public CompositeLayer(int x, int y, string _typename, string _typedesc) : base(x, y, _typename, _typedesc)
        {

        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name.
        /// </summary>
        public CompositeLayer(int x, int y, string _name, string _typename, string _typedesc) : base(x, y, _name, _typename, _typedesc)
        {

        }
    }
}
