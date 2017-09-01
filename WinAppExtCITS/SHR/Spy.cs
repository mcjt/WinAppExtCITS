using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WinAppExtCITS.SHR
{
    public static class Spy
    {
        private static IKeyboardMouseEvents m_GlobalHook;

        public static void startSpy()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseMoveExt += OnMouseMove;
            m_GlobalHook.MouseClick += OnMouseClick;
        }

        public static void stopSpy()
        {
            if (m_GlobalHook != null)
            {
                m_GlobalHook.MouseMoveExt -= OnMouseMove;
                m_GlobalHook.MouseClick -= OnMouseClick;
                m_GlobalHook.Dispose();
            }
        }

        private static void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                AutomationElement element = AutomationElement.FromPoint(new System.Windows.Point(e.X, e.Y));
                Spy.sendSpiedObjectToSave(element);
            }
        }

        private static void OnMouseMove(object sender, MouseEventExtArgs e)
        {
            try
            {
                AutomationElement element = AutomationElement.FromPoint(new System.Windows.Point(e.X, e.Y));
                Spy.sendSpiedObject(element);
            }
            catch
            { }
        }

        private static void sendSpiedObject(AutomationElement element)
        {
            try
            {
                SpyObject sObject = new SpyObject();
                Utils.dehighlightElement(element);
                Utils.highlightElement(element);
                Utils.setObjectProperties(element, sObject);
                Console.WriteLine(sObject.ToString());
                CitsConnect.send(sObject.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void sendSpiedObjectToSave(AutomationElement element)
        {
            try
            {
                SpySaveObject sObject = new SpySaveObject();
                Utils.setObjectProperties(element, sObject);
                sObject.objectname = Utils.getObjectName(element, sObject.prop);
                CitsConnect.send(sObject.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
}
