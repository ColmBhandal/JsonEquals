namespace JsonEquals.Compare
{
    internal interface IJsonComparer
    {
        IJsonComparison JsonEquals(object obj, object another);
    }
}