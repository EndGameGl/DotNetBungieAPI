namespace DotNetBungieAPI.Generated;

public interface IUpdateable<T> where T : INotifyPropertyChanged
{
    void Update(T newData);
}