using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using IronRuby.Runtime;

namespace WpfApplication1.HostingContext {
    public class HostingContextConfigurer {
        public class Wrapper {
            readonly HostingContextConfigurer configurer;

            public Wrapper(HostingContextConfigurer configurer) {
                this.configurer = configurer;
            }

            public void line(double x1, double y1, double x2, double y2) {
                configurer.DrawLine(x1, y1, x2, y2);
            }

            public void ellipse(double x, double y, double rx, double ry) {
                configurer.DrawEllipse(x, y, rx, ry);
            }

            public void rect(double x1, double y1, double x2, double y2) {
                configurer.DrawRect(x1, y1, x2, y2);
            }

            public void text(double x, double y, string text) {
                configurer.DrawText(x, y, text);
            }
        }

        readonly UIElementCollection elements;
        readonly Wrapper wrapper;

        public HostingContextConfigurer(Canvas canvas) {
            this.elements = canvas.Children;
            //canvas.set
            wrapper = new Wrapper(this);
        }

        public void Configure(IHostingContext context) {
            context.BeforeExecute += (s, e) => Clear();
            context.SetFunction("line", new Action<double, double, double, double>(DrawLine));
            context.SetFunction("ellipse", new Action<double, double, double, double>(DrawEllipse));
            context.SetFunction("rect", new Action<double, double, double, double>(DrawRect));
            context.SetFunction("text", new Action<double, double, string>(DrawText));
            context.SetObject("g", wrapper);
            context.SetObject("m", typeof(Wrapper));
        }

        void Clear() {
            elements.Clear();
        }

        void DrawLine(double x1, double y1, double x2, double y2) {
            elements.Add(new Line { X1 = x1, Y1 = y1, X2 = x2, Y2 = y2, Stroke = Brushes.Yellow, StrokeThickness = 4 });
        }

        void DrawEllipse(double x, double y, double rx, double ry) {
            var ellipse = new Ellipse { Stroke = Brushes.Green, StrokeThickness = 3, Fill = Brushes.Chartreuse };
            Canvas.SetLeft(ellipse, x - rx);
            Canvas.SetTop(ellipse, y - ry);
            ellipse.Width = rx * 2;
            ellipse.Height = ry * 2;
            elements.Add(ellipse);
        }

        void DrawRect(double x1, double y1, double x2, double y2) {
            var rectangle = new Rectangle { Stroke = Brushes.BlueViolet, StrokeThickness = 4 };
            Canvas.SetLeft(rectangle, x1);
            Canvas.SetTop(rectangle, y1);
            rectangle.Width = x2 - x1;
            rectangle.Height = y2 - y1;
            elements.Add(rectangle);
        }

        void DrawText(double x, double y, string text) {
            var textBlock = new TextBlock { Text = text, Foreground = Brushes.White, FontSize = 28 };
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            elements.Add(textBlock);
        }
    }
}
