using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class ArtNetInterface : MonoBehaviour
{
    private Socket sock;
    private IPAddress lightAddr;

    // Start is called before the first frame update
    void Start()
    {
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
        lightAddr = IPAddress.Parse("192.168.1.17");
        SetColour(0);
    }

    public void SetColour(int id)
    {
        switch(id)
        {
            case 1:
                SendArtnetPacket(0, 0, 255, 0);
                break;
            case 2:
                SendArtnetPacket(0, 255, 0, 0);
                break;
            case 3:
                SendArtnetPacket(255, 0, 0, 0);
                break;
            case 4:
                SendArtnetPacket(255, 0, 0, 255);
                break;
            default:
                SendArtnetPacket(0, 0, 0, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendArtnetPacket(int r, int y, int g, int buzz)
    {
        IPEndPoint endPoint = new IPEndPoint(lightAddr, 6454);

        byte[] artnet = new byte[32];

        artnet[0] = (byte)'A';
        artnet[1] = (byte)'r';
        artnet[2] = (byte)'t';
        artnet[3] = (byte)'-';
        artnet[4] = (byte)'N';
        artnet[5] = (byte)'e';
        artnet[6] = (byte)'t';
        artnet[7] = 0;

        artnet[8] = 0x00;
        artnet[9] = 0x50;
        artnet[10] = 0x00;
        artnet[11] = 0x14;
        artnet[12] = 0x00;
        artnet[13] = 0x00;
        artnet[14] = 0x00;
        artnet[15] = 0x00;

        artnet[16] = 0x00;
        artnet[17] = 0x06;

        artnet[18] = (byte)r;
        artnet[19] = (byte)y;
        artnet[20] = (byte)g;
        artnet[21] = (byte)buzz;

        sock.SendTo(artnet, endPoint);
    }
}
