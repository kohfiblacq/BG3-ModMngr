﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityModManager.Models.App
{
	public class ModSettingsParseResults
	{
		public List<string> ModOrder { get; set; }
		public List<DivinityProfileActiveModData> ActiveMods { get; set; }
	}
}
