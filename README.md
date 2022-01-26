# Fight Stick Trainer

Enter a fighting game input string and practice with your fight stick.
- Shows input history
- Shows correct inputs in green
- Shows missed inputs in red.

Works with all devices that use XInput, such as Xbox Controllers (360,One, Series X\S)

## Technology Stack
- **.Net 6** - The backend services are using .Net 6 for both the controller interface and communicating with the front-end.
- **SharpDX** - Uses the XInput API to talk to the connected controller and retrieve it's state.
- **signalR** - Due to the nature of working with game controllers, signalR is used to provide a real time link between the front-end UI and back-end server.
- **Typescript** - The front-end website is written in Typescript
- **ReactJS** - The front-end is a single page application powered by ReactJS 
