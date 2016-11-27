﻿using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Serialization;

public class XmlUtility
{
    public static T DeserializeXml<T>(byte[] bytes)
    {


        T value = default(T);

        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                TextReader textReader = new StreamReader(memoryStream);
                value = (T)deserializer.Deserialize(textReader);
                textReader.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        return value;
    }

    public static T DeserializeXml<T>(string text)
    {
        T value = default(T);

        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(text);
            value = (T)deserializer.Deserialize(reader);
            reader.Close();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        return value;
    }

    public static T DeserializeXmlFromFile<T>(string path)
    {
        if (!File.Exists(path))
            return default(T);

        string text = File.ReadAllText(path);
        //string text = File.ReadAllLines(path).ToString();

        return DeserializeXml<T>(text);
    }

    public static string SerializeXml(object o)
    {

        string contents = null;

        try
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, o);
                contents = writer.ToString();
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        return contents;
    }

    public static void SerializeXmlToFile(string path, object o)
    {
        if (string.IsNullOrEmpty(path))
            return;

        string contents = SerializeXml(o);
        if (contents != null)
            File.WriteAllText(path, contents);
    }
}
public class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding
    {
        get
        {
            return Encoding.UTF8;
        }
    }
}
