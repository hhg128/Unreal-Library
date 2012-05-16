﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UELib
{
	public static class UnrealConfig
	{
		internal const string NewLine = "\r\n";

		#region Config
		public static bool SuppressComments;
		public static string PreBeginBracket = NewLine + "{0}";
		public static string PreEndBracket = NewLine + "{0}";

		public struct VariableType
		{
			public string VName;
			public string VType;
		}

		public static List<VariableType> VariableTypes = new List<VariableType>()
		{
			new VariableType{VName = "Skins", VType = "ObjectProperty"},
			new VariableType{VName = "Controls", VType = "ObjectProperty"},
			new VariableType{VName = "Components", VType = "ObjectProperty"},
			new VariableType{VName = "Points", VType = "StructProperty"}
		};
		#endregion

		internal static string PrintBeginBracket()
		{
			return String.Format( PreBeginBracket, UDecompiler.Tabs ) + "{";
		}

		internal static string PrintEndBracket()
		{
			return String.Format( PreEndBracket, UDecompiler.Tabs ) + "}";
		}
	}

	internal static class UDecompiler
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible" )]
		public static string Tabs = String.Empty;

		public static void AddTabs( byte count )
		{
			for( int i = 0; i < count; ++ i )
			{
				Tabs += "\t";
			}
		}

		public static void RemoveTabs( byte count )
		{
			Tabs = count > Tabs.Length ? String.Empty : Tabs.Substring( 0, (Tabs.Length) - count );
		}

		public static void ResetTabs()
		{
			Tabs = String.Empty;
		}
	}
}
