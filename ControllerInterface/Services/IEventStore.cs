namespace ControllerInterface.Services;

public interface IEventStore {
    
    Dictionary<EventType, ComtrollerEvent> Events {get; set;}
    
    void RegisterEvents(Controller controller);
    
}