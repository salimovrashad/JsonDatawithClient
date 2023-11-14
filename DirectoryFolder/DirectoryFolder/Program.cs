using Newtonsoft.Json;

namespace DirectoryFolder
{
	internal class Program
	{
		HttpClient client = new HttpClient();
		static async Task Main(string[] args)
		{
			//string models = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Models"));
			//string data = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Data"));
			//string jsonData = "jsonData.json";

			//if (!Directory.Exists(models))
			//{
			//	Directory.CreateDirectory(models);
			//}
			//if (!Directory.Exists(data))
			//{
			//	Directory.CreateDirectory(data);
			//}
			//File.Create(Path.Combine(data, jsonData));

			Program program = new Program();
			await program.GetDatas();
		}
		public async Task GetDatas()
		{
			string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
			string data = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Data"));

			List<CustomObject> list = new List<CustomObject>();

			using (StreamReader sr = new StreamReader(Path.Combine(data, "jsonData.json")))
			{
				list = JsonConvert.DeserializeObject<List<CustomObject>>(response);
			}
			using (StreamWriter sw = new StreamWriter(Path.Combine(data, "jsonData.json")))
			{
				string dts = JsonConvert.SerializeObject(list);
				sw.WriteLine(dts);
            }
		}
	}
}