﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DivinityModManager
{
	internal class Program
	{
		private static SplashScreen _splash;

		private static bool EnsureSingleInstance(string[] args)
		{
			var procName = Process.GetCurrentProcess().ProcessName;
			if(Process.GetProcessesByName(procName).Length > 1)
			{
				if(args.Length > 0)
				{
					var argsMessage = String.Join(" ", args);
					try
					{
						using var pipe = new NamedPipeClientStream(".", DivinityApp.PIPE_ID,
						PipeDirection.Out, PipeOptions.WriteThrough, System.Security.Principal.TokenImpersonationLevel.Impersonation);
						pipe.Connect(500);
						using var sw = new StreamWriter(pipe, Encoding.UTF8);
						sw.Write(argsMessage);
						sw.Flush();
					}
					catch(Exception ex)
					{
						Console.WriteLine($"Error sending args to server:\n{ex}");
					}
				}
				return true;
			}
			return false;
		}

		[STAThread]
		static void Main(string[] args)
		{
			if (EnsureSingleInstance(args))
			{
#if !DEBUG
				System.Environment.Exit(0);
				return;
#endif
			}
			_splash = new SplashScreen("Resources/BG3MMSplashScreen.png");
			_splash.Show(false, false);

			var app = new App
			{
				Splash = _splash
			};
			app.InitializeComponent();
			app.Run();
		}
	}
}
