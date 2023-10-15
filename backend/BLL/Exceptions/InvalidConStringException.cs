using System.Runtime.Serialization;

namespace BLL.Exceptions;

[Serializable]
public class InvalidConStringException : Exception
{
    public InvalidConStringException()
    {
    }

    public InvalidConStringException(string message) : base(message)
    {
    }

    public InvalidConStringException(string message, Exception inner) : base(message, inner)
    {
    }

    protected InvalidConStringException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}