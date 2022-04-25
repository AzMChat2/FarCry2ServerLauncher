using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace FC2.SL.Remote
{
	public abstract class ServerBase : IServer
	{
		private XmlSerializer RequestSerializer = new XmlSerializer(typeof(Request));
		private XmlSerializer ResponseSerializer = new XmlSerializer(typeof(ExtenderStatus));

		public byte[] ProcessRequest(byte[] request)
		{
			string requestStr = Encryptor.Decrypt(request);
			Request requestObj;

			using (StringReader reader = new StringReader(requestStr))
			{
				requestObj = (Request)RequestSerializer.Deserialize(reader);
			}

			ExtenderStatus responseObj = GetStatus(requestObj);
			string responseStr;

			using (StringWriter writer = new StringWriter())
			{
				ResponseSerializer.Serialize(writer, responseObj);
				responseStr = writer.ToString();
			}

			return Encryptor.Encrypt(responseStr);
		}

		protected abstract ExtenderStatus GetStatus(Request request);
	}

}
