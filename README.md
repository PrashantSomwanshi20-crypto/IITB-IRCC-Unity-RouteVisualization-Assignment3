# IITB-IRCC Unity Route Visualization (Assignment 3)

A Unity simulation where a vehicle travels between **Pune** and **Mumbai**, controlled through typed text commands. Roads can be blocked and opened, and the vehicle reacts to the road status in real time.

## Features

- Vehicle moves from a start city to a destination city along the route
- Text command input box with an on-screen response message
- Set the route in either direction (Pune → Mumbai or Mumbai → Pune)
- Block or open the road; a blocked road stops the vehicle until it is opened again
- Pause and reset the vehicle
- Error handling for invalid commands, unsupported cities, same start/end city, and an already completed journey

## Supported Commands

The assistant is a keyword-based command parser (not an external LLM). It reads the typed text and triggers the matching action.

| Example command | Action |
|-----------------|--------|
| `Set route from Pune to Mumbai` | Sets the route from Pune to Mumbai |
| `Set route from Mumbai to Pune` | Sets the route from Mumbai to Pune |
| `Start vehicle` | Starts moving the vehicle toward the destination |
| `Pause vehicle` | Pauses the vehicle |
| `Reset vehicle` | Returns the vehicle to the starting city |
| `Block road` | Blocks the road between the cities |
| `Open road` | Opens the road again |

Only Pune and Mumbai are supported in the current scene.

## Requirements

- Unity **6000.6.7f1** (Unity 6)
- Git

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/PrashantSomwanshi20-crypto/IITB-IRCC-Unity-RouteVisualization-Assignment3.git
   ```
2. Open **Unity Hub** and click **Add project from disk**.
3. Select the cloned folder and open it with Unity `6000.6.7f1`. The first import may take a few minutes.
4. Open `Assets/RouteScene.unity`.
5. Press **Play**, type a command in the input box, and trigger it with the command button.

## Project Structure

```
Assets/
├── RouteScene.unity                    # Main scene
└── Scripts/
    ├── RouteVisualizationController.cs # Vehicle movement and route tools
    ├── LLMAssistant.cs                 # Text command parsing
    └── RoadManager.cs                  # Road blocked/open state
Packages/                               # Unity package dependencies
ProjectSettings/                        # Unity project settings
```

## How It Works

- **Vehicle controller**: moves the vehicle between the start and end city nodes at a set speed, and stops when the road is blocked.
- **LLM Assistant**: reads the text from the input field, matches keywords, and calls the matching vehicle or road action.
- **Road Manager**: stores whether the road is blocked and can change the road colour (red when blocked, grey when open).

## Author

**Prashant Somwanshi**
GitHub: [@PrashantSomwanshi20-crypto](https://github.com/PrashantSomwanshi20-crypto)
