// http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer

using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

[XmlRoot("CardCollection")]
public class CardContainer 
{
	[XmlArray("Cards")]
	[XmlArrayItem("Card")]
	public List<Card> Cards = new List<Card>();
	
	public void Save(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(CardContainer));
		using(FileStream stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static CardContainer Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(CardContainer));
		using(FileStream stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as CardContainer;
		}
	}
	
	public static CardContainer LoadFromText(string text)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(CardContainer));
		return serializer.Deserialize(new StringReader(text)) as CardContainer;
	}
}
