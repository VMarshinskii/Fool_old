using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FoolService
{
	public class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(PlayingCards));
			serviceHost.AddServiceEndpoint(typeof(IPlayingCards), new NetTcpBinding(), "net.tcp://localhast:8875/");
			serviceHost.Open();
			Console.WriteLine("Service is running...");
			Console.WriteLine("Press any key to stop");
			Console.ReadKey();
			serviceHost.Close();
			Console.WriteLine("Service was stoped");
		}
	}
}