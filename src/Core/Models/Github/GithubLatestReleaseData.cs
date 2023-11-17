﻿using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityModManager.Models.Github
{
	public class GithubLatestReleaseData : ReactiveObject
	{
		[Reactive] public string Version { get; set; }
		[Reactive] public string Description { get; set; }
		[Reactive] public long Date { get; set; }
		[Reactive] public string BrowserDownloadLink { get; set; }
	}
}
