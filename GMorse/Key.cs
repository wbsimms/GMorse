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
using TouchKeyboard;

namespace GadgeteerHelper
{
    public class Key : IDisposable
    {
        private string text = "";
        private int margin;
        private Font font;
        public delegate void KeyPressedEventHander(object sender, KeyPressedEventArgs args);
        public event KeyPressedEventHander keyPressedHandler;
        private Border b;
        private Text t;

        public Key(Font font, string text, int margin = 9)
        {
            this.text = text;
            this.font = font;
            this.margin = margin;
        }

        public Border RenderKey()
        {
            b = new Border();
            t = new Text(font,text);
            t.SetMargin(margin);
            b.SetMargin(3);
            b.Foreground = new SolidColorBrush(Colors.White);
            b.BorderBrush = new SolidColorBrush(Colors.Black);
            t.ForeColor = Colors.White;
            b.Child = t;
            t.VerticalAlignment = VerticalAlignment.Center;
            t.HorizontalAlignment = HorizontalAlignment.Center;
           
            t.TouchUp += b_TouchUp;
            b.TouchUp += b_TouchUp;
            return b;
        }

        void b_TouchUp(object sender, Microsoft.SPOT.Input.TouchEventArgs e)
        {
            Border border = sender as Border;
            if (border == null)
            {
                return;
            }

            Text t = border.Child as Text;

            string content = t.TextContent;
            if (keyPressedHandler != null)
            {
                KeyPressedEventArgs args = new KeyPressedEventArgs(content);
                keyPressedHandler(sender, args);
            }
        }

        public void Dispose()
        {
            b.TouchUp -= b_TouchUp;
            t.TouchUp -= b_TouchUp;
        }
    }
}