﻿using NexusModsNET.DataModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityModManager.Models.NexusMods
{
	public struct NexusModsModDownloadLink
	{
		public DivinityModData Mod { get; set; }
		public NexusModFileDownloadLink DownloadLink { get; set; }

		public NexusModsModDownloadLink(DivinityModData mod, NexusModFileDownloadLink link)
		{
			Mod = mod;
			DownloadLink = link;
		}
	}
}
