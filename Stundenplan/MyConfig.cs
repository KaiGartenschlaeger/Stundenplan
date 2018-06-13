using System;
using System.Collections;
using System.Xml;

namespace StundenplanApplication
{
    /// <summary>
    /// Speicherformat
    /// </summary>
    public enum MyConfigFormat
    {
        XML
    }

    /// <summary>
    /// Dient zur einfachen Verwaltung der Programmeinstellungen.
    /// </summary>
    public class MyConfig
    {
        private Hashtable values = new Hashtable();
        private string _lastError = string.Empty;

        /// <summary>
        /// Enthällt den letzten aufgetrettenen Fehler.
        /// </summary>
        public string LastError
        {
            get
            {
                return this._lastError;
            }
        }

        /// <summary>
        /// Liefert einen Wert oder ändert diesen.
        /// </summary>
        public object this[string key]
        {
            get
            {
                return GetValue(key, null);
            }
            set
            {
                AddValue(key, value);
            }
        }

        /// <summary>
        /// Liefert einen Wert falls dieser existiert, andernfalls wird der Standardwert zurückgegeben.
        /// </summary>
        public int this[string key, int defaultvalue]
        {
            get
            {
                return GetValue(key, defaultvalue);
            }
        }

        /// <summary>
        /// Liefert einen Wert falls dieser existiert, andernfalls wird der Standardwert zurückgegeben.
        /// </summary>
        public double this[string key, double defaultvalue]
        {
            get
            {
                return GetValue(key, defaultvalue);
            }
        }

        /// <summary>
        /// Liefert einen Wert falls dieser existiert, andernfalls wird der Standardwert zurückgegeben.
        /// </summary>
        public string this[string key, string defaultvalue]
        {
            get
            {
                return GetValue(key, defaultvalue);
            }
        }

        /// <summary>
        /// Liefert einen Wert falls dieser existiert, andernfalls wird der Standardwert zurückgegeben.
        /// </summary>
        public short this[string key, short defaultvalue]
        {
            get
            {
                return GetValue(key, defaultvalue);
            }
        }

        /// <summary>
        /// Liefert einen Wert falls dieser existiert, andernfalls wird der Standardwert zurückgegeben.
        /// </summary>
        public object this[string key, object defaultvalue]
        {
            get
            {
                return GetValue(key, defaultvalue);
            }
        }

        public bool this[string key, bool defaultvalue]
        {
            get
            {
                return GetValue(key, defaultvalue);
            }
        }

        /// <summary>
        /// Entfernt alle Werte aus der Liste.
        /// </summary>
        public void Clear()
        {
            values.Clear();
        }

        /// <summary>
        /// Fügt der Liste einen neuen Wert hinzu oder ändert diesen.
        /// </summary>
        public void AddValue(string key, object value)
        {
            if (values.ContainsKey(key) == false)
            {
                values.Add(key, value);
            }
            else
            {
                values[key] = value;
            }
        }

        /// <summary>
        /// Liefert einen Wert falls dieser existiert, andernfalls wird der Standardwert zurückgegeben.
        /// </summary>
        public object GetValue(string key, object defaultvalue)
        {
            if (values.ContainsKey(key) == true)
            {
                return values[key];
            }
            else
            {
                return defaultvalue;
            }
        }

        /// <summary>
        /// Liefert einen Bool Wert.
        /// </summary>
        public bool GetValue(string key, bool defaultvalue)
        {
            bool result = defaultvalue;

            if (values.ContainsKey(key) == true)
            {
                try
                {
                    result = Convert.ToBoolean(values[key]);
                }
                catch(Exception fehler)
                {
                    this._lastError = fehler.Message;
                }
            }
            
            return result;
        }

        /// <summary>
        /// Liefert einen Short Wert.
        /// </summary>
        public short GetValue(string key, short defaultvalue)
        {
            short result = defaultvalue;

            if (values.ContainsKey(key) == true)
            {
                try
                {
                    result = Convert.ToInt16(values[key]);
                }
                catch (Exception fehler)
                {
                    this._lastError = fehler.Message;
                }
            }

            return result;
        }

        /// <summary>
        /// Liefert einen Int32 Wert.
        /// </summary>
        public int GetValue(string key, int defaultvalue)
        {
            int result = defaultvalue;

            if (values.ContainsKey(key) == true)
            {
                try
                {
                    result = Convert.ToInt32(values[key]);
                }
                catch (Exception fehler)
                {
                    this._lastError = fehler.Message;
                }
            }

            return result;
        }

        /// <summary>
        /// Liefert einen Long Wert.
        /// </summary>
        public long GetValue(string key, long defaultvalue)
        {
            long result = defaultvalue;

            if (values.ContainsKey(key) == true)
            {
                try
                {
                    result = Convert.ToInt64(values[key]);
                }
                catch (Exception fehler)
                {
                    this._lastError = fehler.Message;
                }
            }

            return result;
        }

        /// <summary>
        /// Liefert einen Double Wert.
        /// </summary>
        public double GetValue(string key, double defaultvalue)
        {
            double result = defaultvalue;

            if (values.ContainsKey(key) == true)
            {
                try
                {
                    result = Convert.ToDouble(values[key]);
                }
                catch (Exception fehler)
                {
                    this._lastError = fehler.Message;
                }
            }

            return result;
        }

        /// <summary>
        /// Liefert einen DateTime Wert.
        /// </summary>
        public DateTime GetValue(string key, DateTime defaultvalue)
        {
            DateTime result = defaultvalue;

            if (values.ContainsKey(key) == true)
            {
                try
                {
                    result = Convert.ToDateTime(values[key]);
                }
                catch (Exception fehler)
                {
                    this._lastError = fehler.Message;
                }
            }

            return result;
        }

        /// <summary>
        /// Liefert einen String Wert.
        /// </summary>
        public string GetValue(string key, string defaultvalue)
        {
            string result = defaultvalue;

            if (values.ContainsKey(key) == true)
            {
                try
                {
                    result = Convert.ToString(values[key]);
                }
                catch (Exception fehler)
                {
                    this._lastError = fehler.Message;
                }
            }

            return result;
        }

        /// <summary>
        /// Entfernt einen Wert aus der Liste.
        /// </summary>
        public void RemoveValue(string key)
        {
            if (values.ContainsKey(key) == true)
            {
                values.Remove(key);
            }
        }

        //Speichert als XML-Datei.
        private bool SaveXML(string file)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(file, null))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("MyConfig");

                    foreach (object key in values.Keys)
                    {
                        writer.WriteStartElement(key.ToString());
                        writer.WriteString(values[key].ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndDocument();
                    writer.Close();
                }

                return true;
            }
            catch (Exception fehler)
            {
                this._lastError = fehler.Message;
                return false;
            }
        }

        //Liest eine XML-Datei ein.
        private bool OpenXML(string file)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(file);

                object key = null;
                object value = null;

                while (reader.Read())
                {
                    //XML-Werte einlesen
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        key = reader.Name;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        value = reader.ReadContentAsObject();
                    }

                    //Zur Hashtable hinzufügen
                    if (key != null && value != null)
                    {
                        values[key] = value;

                        key = null;
                        value = null;
                    }
                }

                reader.Close();

                return true;
            }
            catch (Exception fehler)
            {
                this._lastError = fehler.Message;
                return false;
            }
        }

        /// <summary>
        /// Speichert die Einstellungen.
        /// </summary>
        public bool Save(string file, MyConfigFormat format)
        {
            bool result = false;

            switch (format)
            {
                case MyConfigFormat.XML:
                    result = SaveXML(file);
                    break;
            }

            return result;
        }
        
        /// <summary>
        /// Öffnet die Einstellungen.
        /// </summary>
        public bool Open(string file, MyConfigFormat format)
        {
            bool result = false;

            switch (format)
            {
                case MyConfigFormat.XML:
                    result = OpenXML(file);
                    break;
            }

            return result;
        }
    }
}
