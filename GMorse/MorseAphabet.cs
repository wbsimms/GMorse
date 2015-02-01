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
using System.Collections;
using System.Threading;

namespace GMorse
{
    public class MorseAphabet
    {
        Hashtable alphabet = new Hashtable();
        private Gadgeteer.SocketInterfaces.DigitalOutput signalOutput;
        private int delayInterval = 500;

        public MorseAphabet(Gadgeteer.SocketInterfaces.DigitalOutput output, int dotLength)
        {
            this.signalOutput = output;
            this.delayInterval = dotLength;

        }

        public void SendMessage(string message)
        {
            foreach (char c in message.ToCharArray())
            {
                if (c == ' ')
                {
                    WordEnd();
                    continue;
                }
                PlayCode(c);
                LetterEnd();
            }
            FullStop();
        }

        public void PlayCode(char character)
        {
            switch (character.ToLower())
            {
                case 'a':
                    Dot();Dash();return;
                case 'b':
                    Dash();Dot();Dot();Dot();return;
                case 'c':
                    Dash();Dot();Dash();Dot();return;
                case 'd':
                    Dash();Dot();Dot();
                    return;
                case 'e':
                    Dot();
                    return;
                case 'f':
                    Dot();Dot();Dash();Dot();
                    return;
                case 'g':
                    Dash();Dash();Dot();
                    return;
                case 'h':
                    Dot();Dot();Dot();Dot();
                    return;
                case 'i':
                    Dot();Dot();
                    return;
                case 'j':
                    Dot();Dash();Dash();
                    Dash();
                    return;
                case 'k':
                    Dash();Dot();Dash();
                    return;
                case 'l':
                    Dot();Dash();Dot();Dot();
                    return;
                case 'm':
                    Dash();Dash();
                    return;
                case 'n':
                    Dash();Dot();
                    return;
                case 'o':
                    Dash();Dash();Dash();
                    return;
                case 'p':
                    Dot();Dash();Dash();Dot();
                    return;
                case 'q':
                    Dash();Dash();Dot();Dash();
                    return;
                case 'r':
                    Dot();
                    Dash();Dot();
                    return;
                case 's':
                    Dot();Dot();Dot();
                    return;
                case 't':
                    Dash();
                    return;
                case 'u':
                    Dot();Dot();Dash();
                    return;
                case 'v':
                    Dot();Dot();Dot();Dash();
                    return;
                case 'w':
                    Dot();Dash();Dash();
                    return;
                case 'x':
                    Dash();Dot();Dot();Dash();
                    return;
                case 'y':
                    Dash();Dot();Dash();Dash();
                    return;
                case 'z':
                    Dash();Dash();Dot();Dot();
                    return;
                case '1':
                    Dot();Dash();Dash();Dash();Dash();
                    return;
                case '2':
                    Dot();Dot();Dash();Dash();Dash();
                    return;
                case '3':
                    Dot();Dot();Dot();Dash();Dash();
                    return;
                case '4':
                    Dot();Dot();Dot();Dot();
                    Dash();
                    return;
                case '5':
                    Dot();Dot();Dot();Dot();Dot();
                    return;
                case '6':
                    Dash();Dot();Dot();Dot();Dot();
                    return;
                case '7':
                    Dash();Dash();Dot();Dot();Dot();
                    return;
                case '8':
                    Dash();Dash();Dash();Dot();Dot();
                    return;
                case '9':
                    Dash();Dash();Dash();Dash();Dot();
                    return;
                case '0':
                    Dash();Dash();Dash();Dash();Dash();
                    return;
                case ',':
                    Dash();Dash();Dot();Dot();Dash();Dash();
                    return;
                case '?':
                    Dot();Dot();Dash();Dash();Dot();Dot();return;
                default:
                    return;
            }
        }

        private void Dot()
        {
            signalOutput.Write(true);
            Thread.Sleep(delayInterval);
            signalOutput.Write(false);
            Thread.Sleep(delayInterval);
        }

        private void Dash()
        {
            signalOutput.Write(true);
            Thread.Sleep(delayInterval * 3);
            signalOutput.Write(false);
            Thread.Sleep(delayInterval);
        }

        private void LetterEnd()
        {
            Thread.Sleep(delayInterval * 3);
        }

        private void WordEnd()
        {
            Thread.Sleep(delayInterval * 7);
        }

        private void FullStop()
        {
            Dot(); Dash();
            Dot(); Dash();
            Dot(); Dash();
        }
    }
}