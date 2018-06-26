using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;
using System.Threading;

#if !UNITY_EDITOR
using System.Threading.Tasks;
#endif


public class UWPConnect : MonoBehaviour {

#if !UNITY_EDITOR
    private Windows.Networking.Sockets.StreamSocket socket;
#endif

    public Text controllerPositions;
    private string ipAddress = "131.202.243.56";
    private string port = "5555";
    private string errorStatus;
    private string received = null;

#if !UNITY_EDITOR
    private Task<string> response = null;
#else
    private string response = null;
#endif

    private bool connection = false;
    private StreamReader reader;
    private string dataFromServer = null;

    // Use this for initialization
    void Start () {

#if !UNITY_EDITOR
        UWPConnection();
        //UWPListen();
        //controllerPositions.text = "data: " + dataFromServer;
#endif
        //controllerPositions.text = "data: " + dataFromServer;
    }

    // Update is called once per frame
    void Update () {
#if !UNITY_EDITOR
        //if (connection)
        //{
         //   UWPListen();
        //}
        //controllerPositions.text = "data: " + dataFromServer;
#endif
    }

#if !UNITY_EDITOR
    private async void UWPConnection()
    {

        try
        {
            socket = new Windows.Networking.Sockets.StreamSocket();
            Windows.Networking.HostName serverHost = new Windows.Networking.HostName(ipAddress);
            await socket.ConnectAsync(serverHost, port);

            Stream streamIn = socket.InputStream.AsStreamForRead();
            reader = new StreamReader(streamIn, Encoding.UTF8);
            connection = true;
            UWPListen();
            //dataFromServer = reader.ReadLine();
            //controllerPositions.text = "data: " + dataFromServer;
        }

        catch (Exception e)
        {
            controllerPositions.text = "error";
            //do something with the Exception
        }
        /*
        try
        {
            Stream streamIn = socket.InputStream.AsStreamForRead();
            reader = new StreamReader(streamIn, Encoding.UTF8);
            //while have a connection, read byte
            received = "";
    
            while (true)
            {
                //received = await reader.ReadToEndAsync();
                int latest = reader.Read();
                char latestChar = Convert.ToChar(latest);
                
                if (latestChar == ';')
                {
                    //processCoords(received);
                    controllerPositions.text = "data: " + received;
                    break;
                }    
                
                else
                {
                    received += latestChar;
                }

                //controllerPositions.text = "data: " + received;
            }
        }
        
        catch (Exception e)
        {
            errorStatus = e.ToString();
            controllerPositions.text = "error: " + errorStatus;
        } */
    }
#endif

#if !UNITY_EDITOR
    private void UWPListen()
    {
        try
        {
            dataFromServer = reader.ReadLine();
            
            controllerPositions.text = "data: " + dataFromServer;
            /*
            //Windows.Storage.Streams.IInpuStream _stream = socket.InputStream
            Stream streamIn = socket.InputStream.AsStreamForRead();
            //var buffer = new byte[255];
            reader = new StreamReader(streamIn);
            response = reader.ReadLineAsync();
            //received = reader.ReadLine();
            controllerPositions.text = "data: " + response;
            */
        }

        catch (Exception e)
        {
            //errorStatus = e.ToString();
            //controllerPositions.text = "did not read, error: " + errorStatus;
        }


    }
#endif
}
