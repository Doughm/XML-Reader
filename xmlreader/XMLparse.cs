//This class reads and writes to XML files

using System.Xml;
using System.IO;

class XMLparse
{
    XmlDocument reader = new XmlDocument();
    string fileName;

    //takes the file path and if the file exists open it
    public XMLparse(string file)
    {
        if (File.Exists(file) == true)
        {
            reader.Load(file);
            fileName = file;
        }
    }

    //returns a value of an element with a given name in the root element.
    public string findValue(string type, string name, string value)
    {
        foreach (XmlNode xmlNode in reader.DocumentElement.ChildNodes)
        {
            if (xmlNode.LocalName == type && xmlNode.Attributes["name"].Value == name)
            {
                return xmlNode.Attributes[value].Value;
            }
        }
        return "getValue() error";
    }

    //returns a value of an element with a given index.
    public string findValue(int index, string value)
    {
        int counter = 0;
        foreach (XmlNode xmlNode in reader.DocumentElement.ChildNodes)
        {
            if (counter == index)
            {
                return xmlNode.Attributes[value].Value;
            }
            counter++;
        }
        return "getValue() error";
    }

    //returns the type of an element from a given name.
    public string findType(string name)
    {
        foreach (XmlNode xmlNode in reader.DocumentElement.ChildNodes)
        {
            if (xmlNode.Attributes["name"].Value == name)
            {
                return xmlNode.LocalName;
            }
        }
        return "findType(string) error";
    }

    //returns the type of an element from a given index.
    public string findType(int index)
    {
        int counter = 0;
        foreach (XmlNode xmlNode in reader.DocumentElement.ChildNodes)
        {
            if (counter == index)
            {
                return xmlNode.LocalName;
            }
            counter++;
        }
        return "findType(int) error";
    }

    //returns a string containing all values of a given type in the root element.
    public string listContents(string type, string value)
    {
        string tempStr = "";
        foreach (XmlNode xmlNode in reader.DocumentElement.ChildNodes)
        {
            if (xmlNode.LocalName == type)
            {
                tempStr += xmlNode.Attributes[value].Value + '\n';
            }
        }
        if (tempStr == "")
        {
            return "listContents() error";
        }
        tempStr = tempStr.TrimEnd('\n');
        return tempStr;
    }

    //returns a string containing all values of all items in the root element.
    public string listContents(string value)
    {
        string tempStr = "";
        foreach (XmlNode xmlNode in reader.DocumentElement.ChildNodes)
        {
            tempStr += xmlNode.Attributes[value].Value + '\n';
        }
        if (tempStr == "")
        {
            return "listContents() error";
        }
        tempStr = tempStr.TrimEnd('\n');
        return tempStr;
    }

    //returns the number of elements the root element has.
    public int numberOfElements()
    {
        return reader.DocumentElement.ChildNodes.Count;
    }

    //returns the number of elements with given type.
    public int numberOfElements(string type)
    {
        int tempInt = 0;
        foreach (XmlNode xmlNode in reader.DocumentElement.ChildNodes)
        {
            if (xmlNode.LocalName == type)
            {
                tempInt++;
            }
        }
        return tempInt;
    }

    //converts a string to a string array
    public string[] convertToArray(string stringToConvert)
    {
        return stringToConvert.Split('\n');
    }
}