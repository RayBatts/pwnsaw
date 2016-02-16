
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Pwnsaw
{
	public static class Util
	{
		public static List< Hero > DeserializeHeroList( string combinedHeroXmlFile )
		{
			var heroSerializer = new DataContractSerializer( typeof( List<Hero> ) );

			using( var dataFileStream = new FileStream( combinedHeroXmlFile, FileMode.Open ) )
			{
				var dictReader = XmlDictionaryReader.CreateTextReader( dataFileStream, new XmlDictionaryReaderQuotas() );

				while( dictReader.Read() )
				{
					switch( dictReader.NodeType )
					{
						case XmlNodeType.Element:
							if( heroSerializer.IsStartObject( dictReader ) )
							{
								return (List<Hero>)heroSerializer.ReadObject( dictReader );
							}
							break;
					}
				}
			}

			return null;
		}
	}
}
