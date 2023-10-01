using System.Runtime.Serialization;

namespace BLL.Exceptions;

[Serializable]
public class IdentityException : Exception
{
    public IdentityException()
    {
    }

    public IdentityException(string message) : base(message)
    {
    }

    public IdentityException(string message, Exception inner) : base(message, inner)
    {
    }

    protected IdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}