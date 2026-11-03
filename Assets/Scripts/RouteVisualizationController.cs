using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Transform puneNode;   // Inspector mein Start Point / Pune
    public Transform mumbaiNode; // Inspector mein End Point / Mumbai
    public Transform startPoint; 
    public Transform endPoint;   
    public RoadManager roadManager; 
    public float speed = 5f;
    private bool isMoving = false;

    void Start()
    {
        if (puneNode == null) puneNode = startPoint;
        if (mumbaiNode == null) mumbaiNode = endPoint;

        if (startPoint != null)
        {
            transform.position = startPoint.position;
        }
    }

    void Update()
    {
        if (roadManager != null && roadManager.isBlocked)
        {
            return;
        }

        if (isMoving && endPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
            {
                isMoving = false;
                Debug.Log("Vehicle reached destination!");
            }
        }
    }

    public void StartJourney()
    {
        isMoving = true;
    }

    public string StartVehicleTool()
    {
        if (startPoint == null || endPoint == null)
            return "Error: Route is not set. Please specify a valid route first.";
        if (roadManager != null && roadManager.isBlocked)
            return "Cannot start: The road between Pune and Mumbai is currently blocked!";
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
            return "Vehicle has already reached the destination. Reset the vehicle first.";

        isMoving = true;
        return $"Vehicle started moving from {startPoint.name} to {endPoint.name}.";
    }

    public string PauseVehicleTool()
    {
        if (!isMoving)
            return "Vehicle is already paused or stopped.";
        isMoving = false;
        return "Vehicle movement paused.";
    }

    public string ResetVehicleTool()
    {
        isMoving = false;
        if (startPoint != null)
            transform.position = startPoint.position;
        return $"Vehicle reset to starting city ({startPoint.name}).";
    }

    public string SetRouteTool(string fromCity, string toCity)
    {
        fromCity = fromCity.ToLower().Trim();
        toCity = toCity.ToLower().Trim();

        if (fromCity == toCity)
            return "Invalid Command: Start city and destination city cannot be the same.";

        if (fromCity == "pune" && toCity == "mumbai")
        {
            startPoint = puneNode;
            endPoint = mumbaiNode;
        }
        else if (fromCity == "mumbai" && toCity == "pune")
        {
            startPoint = mumbaiNode;
            endPoint = puneNode;
        }
        else
        {
            return $"Invalid Route: Only 'Pune' and 'Mumbai' exist in the current scene (Requested: {fromCity} to {toCity}).";
        }

        isMoving = false;
        transform.position = startPoint.position;
        return $"Route successfully set from {startPoint.name} to {endPoint.name}.";
    }
}