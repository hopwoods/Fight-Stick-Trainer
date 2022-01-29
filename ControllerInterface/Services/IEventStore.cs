namespace ControllerInterface.Services;

public interface IEventStore
{
    void FireEvent(EventType eventType, IXboxController controller);
}