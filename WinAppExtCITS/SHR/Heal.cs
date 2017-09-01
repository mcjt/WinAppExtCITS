using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using static WinAppExtCITS.SHR.Utils;

namespace WinAppExtCITS.SHR
{
    public static class Heal
    {
        static HashSet<AutomationElement> elementList = new HashSet<AutomationElement>();


        internal static void Search(HealObject message)
        {
            findAndHighlightElement(message);
        }

        private static void sendHealResult(string pageName, string objectname, string exist)
        {
            HealResult hResult = new HealResult();
            hResult.pageName = pageName;
            hResult.objectname = objectname;
            hResult.exist = exist;
            CitsConnect.send(hResult.ToString());
        }

        private static void dehighlightOldElements()
        {
            foreach (AutomationElement element in elementList)
            {
                Utils.dehighlightElement(element);
            }
            elementList.Clear();
        }

        private static void highlightElements(AutomationElement element)
        {
            elementList.Add(element);
            Utils.highlightElement(element);
        }

        private static void findAndHighlightElement(HealObject message)
        {
            dehighlightOldElements();
            searchElements(message.objects);
        }

        private static void searchElements(List<HObject> objects)
        {
            foreach (HObject x in objects)
            {
                searchElement(x);
            }
        }

        private static void searchElement(HObject x)
        {
            String exist = "false";
            Element result = findElement(x.prop);
            if (result != null && result.element != null)
            {
                exist = result.count > 1 ? "partial" : "true";
                highlightElements(result.element);
            }
            sendHealResult(x.pageName, x.objectname, exist);
        }

        private static Element findElement(List<Property> x)
        {
            foreach (Property prop in x)
            {
                String property = prop.property;
                String value = prop.value;
                if (!String.IsNullOrEmpty(value))
                {
                    Element result = getElement(property, value);
                    if (result != null && result.element != null)
                        return result;
                }
            }
            return null;
        }

        private static Element getElement(String property, String value)
        {
            switch (property)
            {
                case Attributes.id:
                    return getElementByAProp(AutomationElement.RuntimeIdProperty, Array.ConvertAll(value.Split(new[] { '.' }), int.Parse));
                case Attributes.name:
                    return getElementByAProp(AutomationElement.NameProperty, value);
                case Attributes.classname:
                    return getElementByAProp(AutomationElement.ClassNameProperty, value);
                case Attributes.access:
                    return getElementByAProp(AutomationElement.AutomationIdProperty, value);
                case Attributes.type:
                    return getElementByAProp(AutomationElement.LocalizedControlTypeProperty, value);
                default:
                    return null;
            }
        }
        private static Element getElementByAProp(AutomationProperty aProp, Object value)
        {
            Element el = new Element();
            Condition con = new PropertyCondition(aProp, value);
            AutomationElementCollection elementCollection = AutomationElement.RootElement.FindAll(TreeScope.Subtree, con);
            if (elementCollection.Count > 0)
            {
                el.element = elementCollection[0];
                el.count = elementCollection.Count;
            }
            return el;
        }

        class Element
        {
            public AutomationElement element { get; set; }
            public int count { get; set; }
        }
    }
}
