using UnityEngine;
using System.IO.Ports;

public class FourPlateController : MonoBehaviour
{
    public string portName = "COM6"; // Change to your COM port
    private SerialPort stream;

    [Header("Drag your 4 Squares here")]
    public GameObject[] squares; 

    [Header("Animation Settings")]
    public float shrinkSpeed = 5f; // How fast they return to normal size
    public float maxGrowth = 3.0f; // Size at maximum force (1.0)

    void Start()
    {
        stream = new SerialPort(portName, 115200);
        try {
            stream.Open();
            stream.ReadTimeout = 10;
        } catch {
            Debug.LogError("Serial Port Error! Is the Arduino Serial Monitor closed?");
        }
    }

    void Update()
    {
        // 1. Smoothly shrink all squares back to their original size (1,1,1)
        for (int i = 0; i < squares.Length; i++)
        {
            if (squares[i].transform.localScale.x > 1.01f)
            {
                squares[i].transform.localScale = Vector3.Lerp(
                    squares[i].transform.localScale, 
                    Vector3.one, 
                    Time.deltaTime * shrinkSpeed
                );
            }
        }

        // 2. Read Data from ESP32-S3
        if (stream != null && stream.IsOpen && stream.BytesToRead > 0)
        {
            try
            {
                string data = stream.ReadLine();
                string[] parts = data.Split(':');
                if (parts.Length == 2)
                {
                    int id = int.Parse(parts[0]);
                    float force = float.Parse(parts[1]);

                    // Check if ID is between 0 and 3
                    if (id >= 0 && id < squares.Length)
                    {
                        ApplyForce(id, force);
                    }
                }
            } catch { }
        }
    }

    void ApplyForce(int id, float forceValue)
    {
        // Scale calculation: 
        // Force 0.0 -> Scale 1.0
        // Force 1.0 -> Scale 3.0 (or whatever maxGrowth is)
        float newSize = 1.0f + (forceValue * (maxGrowth - 1.0f));
        
        squares[id].transform.localScale = Vector3.one * newSize;
    }

    void OnApplicationQuit() 
    { 
        if (stream != null && stream.IsOpen) stream.Close(); 
    }
}