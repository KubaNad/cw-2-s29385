namespace Kontenenery;

public class OverfillException : Exception
{
    public OverfillException() : base("The load weight is too large") {}

    public OverfillException(string? message) : base(message) {}
}