using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;

namespace WinAppExtCITS.SHR
{
    class Utils
    {

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        public static ObjectPropertyForElement setObjectProperties(AutomationElement element, ObjectPropertyForElement data)
        {
            data.page = new Page();
            data.page.title = "";
            data.prop = getProperties(element);
            data.frame = null;
            return data;
        }

        public static string getObjectName(AutomationElement elem, List<Prop> props)
        {
            AutomationElement label = elem.Current.LabeledBy;
            if (label != null)
                return label.Current.Name;
            if (getProp(Attributes.name, props) != null)
                return getProp(Attributes.name, props);
            if (getProp(Attributes.classname, props) != null)
                return getProp(Attributes.classname, props);
            if (getProp(Attributes.access, props) != null)
                return getProp(Attributes.access, props);
            if (getProp(Attributes.type, props) != null)
                return getProp(Attributes.type, props);
            return "ObjectName";
        }

        static String getProp(String prop, List<Prop> props)
        {
            foreach (Prop pp in props)
            {
                if (pp.prop.Equals(prop) && pp.val != null && pp.val.Length > 0)
                {
                    return pp.val;
                }
            }
            return null;
        }

        private static List<Prop> getProperties(AutomationElement elem)
        {
            List<Prop> properties = new List<Prop>();
            foreach (String attr in Attributes.attrs)
            {
                Prop property = new Prop();
                property.prop = attr;
                switch (attr)
                {
                    case Attributes.id:
                        property.val = String.Join(".", elem.GetRuntimeId());
                        break;
                    case Attributes.name:
                        property.val = elem.Current.Name;
                        break;
                    case Attributes.access:
                        property.val = elem.Current.AutomationId;
                        break;
                    case Attributes.classname:
                        property.val = elem.Current.ClassName;
                        break;
                    case Attributes.type:
                        property.val = elem.Current.LocalizedControlType;
                        break;
                }
                properties.Add(property);

            }

            return properties;
        }


        public static void highlightElement(AutomationElement element)
        {
            drawRectangle(element.Current.BoundingRectangle);
        }


        public static void dehighlightElement(AutomationElement element)
        {
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);
            g.Flush();
            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);
        }


        private static void drawRectangle(Rect rect)
        {
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);

            g.DrawRectangle(Pens.Red, new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height));

            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);
        }


        public static class Attributes
        {
            public const String name = "name";
            public const String access = "accessibility";
            public const String id = "id";
            public const String classname = "class";
            public const String type = "type";

            public static List<String> attrs = new List<String>(new String[] { name, access, id, classname, type });
        }
    }
}
