using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

/// <summary>
/// With a normal Unity configuration, the namespace `System.IO.Ports` will not be identified.
/// For this script to work, it requires changing the .net API in the Unity ProjectSettings.
/// Go to ProjectSettings > Player > Under the submenu "Configuration" change `Api Compatibility Level`
/// from `.NET Standard 2.0` to `.NET 4.x`
/// It also helps to delete the files with extension `.csproj` and `.sln` so Unity creates again
/// the Visual Studio solution with the new .NET framework
/// 
/// Author: Luis Quintero <luis-eduardo@dsv.su.se>
/// </summary>

public class SerialTest : MonoBehaviour
{
    [Tooltip("When true, it will open the first COM port available from the list. If any. Otherwise it forces opening the port in `serialPortId`")]
    public bool useAutomaticPort = true;
    public string serialPortId = "COM4";
    float readingPeriodSecs = 1f;
    string lastReadValue = "";

    SerialPort sp;
    float next_time;

    //int ii = 0;
    private void OnDisable()
    {
        CloseSerial();
    }

    void Start()
    {
        next_time = Time.time;

        if(useAutomaticPort)
        {
            AssignAutomaticPort();
        }
        

        TryToOpenSerial();
    }

    private void AssignAutomaticPort()
    {
        string[] availablePorts = SerialPort.GetPortNames();
        if (availablePorts.Length == 0)
        {
            Debug.Log("COM ports were not found");
        }
        else
        {
            Debug.Log("Found COM ports:");
            foreach (string mysps in availablePorts)
            {
                print(mysps);
            }
            serialPortId = availablePorts[0];
        }
    }

    private void TryToOpenSerial()
    {
        sp = new SerialPort(serialPortId, 9600);
        if (!sp.IsOpen)
        {
            print("Opening " + serialPortId + " baud 9600");
            sp.Open();
            //sp.ReadTimeout = 100;
            //sp.Handshake = Handshake.None;
            if (sp.IsOpen) { print("Open"); }
        }
    }

    private void CloseSerial()
    {
        if (sp.IsOpen)
            sp.Close();
    }

    private void ReadValuesFromSerial()
    {
        lastReadValue = sp.ReadLine(); //Read the information
        string[] vec3 = lastReadValue.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
        if (vec3[0] != "" && vec3[1] != "" && vec3[2] != "") //Check if all values are recieved
        {
            Debug.Log("Received vect3: " + vec3[0] + ", " + vec3[1] + ", " + vec3[2]);
            sp.BaseStream.Flush();              //Clear the serial information so we assure we get new information.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_time)
        {
            if (sp.IsOpen)
            {
                // Read values
                ReadValuesFromSerial();
            }
            else
            {
                TryToOpenSerial();
            }

            //if (sp.IsOpen)
            //{
            //    // Write values in the port
            //    print("Writing " + ii);
            //    sp.Write((ii.ToString()));
            //}
            next_time = Time.time + readingPeriodSecs;
            //if (++ii > 9) ii = 0;
        }
    }
}
