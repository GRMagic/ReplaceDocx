using System.IO.Compression;
using System.Xml;

var path = "exemplo.docx";

using var archive = ZipFile.Open(path, ZipArchiveMode.Update);
var document = archive.GetEntry("word/document.xml")!;

using var documentStream = document.Open();
var xml = new XmlDocument();
xml.Load(documentStream);

var changed = xml.OuterXml.Replace("Oi", "Olá");
xml.LoadXml(changed);

documentStream.Seek(0, SeekOrigin.Begin);
xml.Save(documentStream);