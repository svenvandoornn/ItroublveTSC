using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StealerExt
{
    internal static class GetFilesExtension
	{
		public static IEnumerable<FileInfo> GetFilesNew(this DirectoryInfo dir, params string[] ext)
		{
			return dir.EnumerateFiles().Where(file => ext.Contains(file.Extension));
		}
	}
}
