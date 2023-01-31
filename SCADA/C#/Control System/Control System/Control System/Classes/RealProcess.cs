using System;
using NationalInstruments.DAQmx;

namespace Control_System.Classes
{
    class RealProcess
    {
        public double T_out = 26;
        public double ReadProcess()
        {
            Task analogInTask = new Task();
            analogInTask.AIChannels.CreateVoltageChannel(
            "dev3/ai0",
            "myAIChannel",
            AITerminalConfiguration.Rse,
            1,
            5,
            AIVoltageUnits.Volts
            );
            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);
            double analogDataIn = reader.ReadSingleSample();
            T_out = Math.Abs(7.5*analogDataIn + 12.5);
            return T_out;
        }
        public void ControlProcess(double u)
        {
            Task analogOutTask = new Task();
            analogOutTask.AOChannels.CreateVoltageChannel(
            "dev3/ao0",
            "myAOChannel",
            0,
            5,
            AOVoltageUnits.Volts
            );
            AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(analogOutTask.Stream);
            writer.WriteSingleSample(true, Math.Abs(u));
        }
    }
}
