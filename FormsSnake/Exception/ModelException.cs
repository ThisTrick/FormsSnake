using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsSnake.Exception
{
    [Serializable]
    public class ModelException : System.Exception
    {
        public ModelException(string modelName) : base($"{modelName} Exception.") { }
        public ModelException(string modelName, string message) : base($"{modelName} Exception: {message}.") { }
        public ModelException(string modelName, string message, System.Exception inner) : base($"{modelName} Exception: {message}.", inner) { }
        protected ModelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
