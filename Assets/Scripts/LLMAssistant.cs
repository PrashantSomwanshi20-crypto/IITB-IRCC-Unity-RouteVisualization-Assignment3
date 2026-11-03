using UnityEngine;
using TMPro;

public class LLMAssistant : MonoBehaviour
{
    public VehicleController vehicleController;
    public RoadManager roadManager;

    public TMP_InputField commandInput;
    public TextMeshProUGUI responseText;

    public void ProcessNaturalLanguageCommand()
    {
        if (commandInput == null || vehicleController == null || responseText == null)
        {
            Debug.LogError("LLMAssistant references are not assigned!");
            return;
        }

        string rawCommand = commandInput.text.ToLower().Trim();
        if (string.IsNullOrEmpty(rawCommand))
        {
            responseText.text = "Please enter a valid command.";
            return;
        }

        string result = "";

        // 1. Route Specification Commands
        if (rawCommand.Contains("route") || (rawCommand.Contains("from") && rawCommand.Contains("to")))
        {
            if (rawCommand.Contains("pune") && rawCommand.Contains("mumbai"))
            {
                if (rawCommand.IndexOf("mumbai") < rawCommand.IndexOf("pune"))
                    result = vehicleController.SetRouteTool("mumbai", "pune");
                else
                    result = vehicleController.SetRouteTool("pune", "mumbai");
            }
            else
            {
                result = "Invalid Route: Only Pune and Mumbai routes are supported in this simulation.";
            }
        }
        // 2. Block Road Commands
        else if (rawCommand.Contains("block") || rawCommand.Contains("close"))
        {
            if (roadManager != null)
            {
                roadManager.isBlocked = true;
                result = "Road between Pune and Mumbai has been blocked successfully.";
            }
            else
            {
                result = "Error: RoadManager reference missing.";
            }
        }
        // 3. Unblock / Open Road Commands
        else if (rawCommand.Contains("unblock") || rawCommand.Contains("open"))
        {
            if (roadManager != null)
            {
                roadManager.isBlocked = false;
                result = "Road has been unblocked. Traffic can now pass.";
            }
            else
            {
                result = "Error: RoadManager reference missing.";
            }
        }
        // 4. Start Vehicle Commands
        else if (rawCommand.Contains("start") || rawCommand.Contains("run") || rawCommand.Contains("go"))
        {
            result = vehicleController.StartVehicleTool();
        }
        // 5. Pause Vehicle Commands
        else if (rawCommand.Contains("pause") || rawCommand.Contains("stop"))
        {
            result = vehicleController.PauseVehicleTool();
        }
        // 6. Reset Vehicle Commands
        else if (rawCommand.Contains("reset") || rawCommand.Contains("restart"))
        {
            result = vehicleController.ResetVehicleTool();
        }
        // 7. Invalid Commands Handling
        else
        {
            result = $"Invalid Command: '{commandInput.text}' could not be interpreted. Try 'Start vehicle', 'Block road', or 'Set route from Pune to Mumbai'.";
        }

        responseText.text = result;
        commandInput.text = ""; 
    }
}