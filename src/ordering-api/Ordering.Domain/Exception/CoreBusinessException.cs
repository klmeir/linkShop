﻿using System.Runtime.Serialization;

namespace Ordering.Domain.Exception
{
    [Serializable]
    public class CoreBusinessException : System.Exception
    {
        public CoreBusinessException()
        {

        }
        public CoreBusinessException(string message) : base(message)
        {
        }

        public CoreBusinessException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected CoreBusinessException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
