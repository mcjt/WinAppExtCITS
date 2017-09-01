using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinAppExtCITS.SHR
{
    class JSON
    {
    }

    #region Recorder
    public class RecordBrowserWithInput : RecordBrowser
    {
        public string input { get; set; }
        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RecordBrowser : ObjectProperty
    {
        public string action = "record";
        public string method { get; set; }
        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RecordObjectWithInput : RecordObjectElement
    {
        public string input { get; set; }
        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RecordObjectElement : ObjectPropertyForElement
    {
        public RecordObjectElement()
        {
            type = "Object";
        }

        public string action = "record";
        public string method { get; set; }
        public string objectname { get; set; }
        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    #endregion

    #region Spy

    public class SpyObject : ObjectPropertyForElement
    {
        public string action = "PREV";
        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class SpySaveObject : SpyObject
    {
        public SpySaveObject()
        {
            action = "SAVE";
        }
        public string objectname { get; set; }
        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    #endregion

    #region Object
    public class ObjectProperty
    {
        public string type = "Browser";
    }

    public class ObjectPropertyForElement : ObjectProperty
    {
        public Page page { get; set; }
        public List<Prop> prop { get; set; }
        public String frame { get; set; }
    }

    public class Page
    {
        public string title { get; set; }
    }

    public class Prop
    {
        public string prop { get; set; }
        public string val { get; set; }
    }
    #endregion

    #region Heal
    public class Property
    {
        public string property { get; set; }
        public string value { get; set; }
    }

    public class HObject
    {
        public List<Property> prop { get; set; }
        public string objectname { get; set; }
        public string pageName { get; set; }
        public string frame { get; set; }
    }

    public class HealObject
    {
        public List<HObject> objects { get; set; }
        public string action { get; set; }
        public static HealObject ToObject(String jsonString)
        {
            return JsonConvert.DeserializeObject<HealObject>(jsonString);
        }
    }

    public class HealResult
    {
        public string action = "heal";
        public string objectname { get; set; }
        public string pageName { get; set; }
        public string exist { get; set; }
        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    #endregion
}
