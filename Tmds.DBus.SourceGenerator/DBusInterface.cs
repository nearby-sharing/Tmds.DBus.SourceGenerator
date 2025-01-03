using System;
using System.ComponentModel;
using System.Xml.Serialization;


namespace Tmds.DBus.SourceGenerator
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "node")]
    public class DBusNode
    {
        [XmlElement("interface")]
        public DBusInterface[]? Interfaces { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class DBusInterface
    {
        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlElement("method")]
        public DBusMethod[]? Methods { get; set; }

        [XmlElement("signal")]
        public DBusSignal[]? Signals { get; set; }

        [XmlElement("property")]
        public DBusProperty[]? Properties { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DBusMethod
    {
        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlElement("arg")]
        public DBusArgument[]? Arguments { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DBusSignal
    {
        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlElement("arg")]
        public DBusArgument[]? Arguments { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DBusProperty : DBusValue
    {
        [XmlAttribute("access")]
        public string? Access { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DBusArgument : DBusValue
    {
        [XmlAttribute("direction")]
        public string? Direction { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DBusValue
    {
        [XmlIgnore]
        private DBusSourceGenerator.DBusDotnetType? _dbusDotnetType;

        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlIgnore]
        public DBusSourceGenerator.DBusDotnetType DBusDotnetType => _dbusDotnetType ??= DBusSourceGenerator.DBusDotnetType.FromDBusValue(this);
    }
}
