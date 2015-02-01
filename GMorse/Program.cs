#region copyright
// Copyright (c) 2015 Wm. Barrett Simms wbsimms.com
//
// Permission is hereby granted, free of charge, to any person 
// obtaining a copy of this software and associated documentation 
// files (the "Software"), to deal in the Software without restriction, including 
// without limitation the rights to use, copy, modify, merge, publish, 
// distribute, sublicense, and/or sell copies of the Software, 
// and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be 
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion
using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace GMorse
{
    public partial class Program
    {
        private GT.SocketInterfaces.DigitalOutput signalOutput;
        private int delayInterval = 100;
        private MorseAphabet morseAphabet;
        private KeyboardHelper keyboardHelper;
        private bool showKeypad = false;

        void ProgramStarted()
        {
            Debug.Print("Program Started");
            signalOutput = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Three, false);
            morseAphabet = new MorseAphabet(signalOutput,delayInterval);
            keyboardHelper = new KeyboardHelper(displayTE35,Resources.GetFont(Resources.FontResources.small));
            keyboardHelper.EnterPressed +=keyboardHelper_EnterPressed;
        }

        void keyboardHelper_EnterPressed(object sender, TouchKeyboard.EnterPressedEventArgs args)
        {
            string text = args.Text;
            morseAphabet.SendMessage(text);
        }
    }
}
