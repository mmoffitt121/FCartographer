using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCartographer
{
    /// <summary>
    /// Represents a unit inside a composite layer.
    /// </summary>
    public abstract class CompositeLayerItem
    {
        private string name;

        /// <summary>
        /// Name mutator
        /// </summary>
        public void SetName(string _name)
        {
            name = _name;
        }

        /// <summary>
        /// Name accessor
        /// </summary>
        public string GetName()
        {
            return name;
        }
    }
}
