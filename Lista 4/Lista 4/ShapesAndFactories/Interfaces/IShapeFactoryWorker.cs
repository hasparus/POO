namespace Lista_4.ShapesAndFactories
{
    public interface IShapeFactoryWorker
    {
        string ShapeName { get; }
        IShape Create(params object[] parameters);
    }
}