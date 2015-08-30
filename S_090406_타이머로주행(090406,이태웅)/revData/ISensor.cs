using System;
namespace revData
{
    interface ISensor
    {
        event Sensor.DataReceiveHandler DataReceived;
    }
}
