using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace BaseLib.Helper
{
	public class LogHelper
	{
		/// <summary>
		/// 디버그 로그 path
		/// </summary>
		public static readonly string PDEBUG_PATH = $@"{AppDomain.CurrentDomain.BaseDirectory}log";

		// 로거 ILog 필드
		public  static ILog log = LogManager.GetLogger("Program");

		static	log4net.Repository.Hierarchy.Hierarchy hierarchy = null;
		/// <summary>
		/// 사용불가 플래그
		/// </summary>
		public const bool IsDisabled = false;

		public static void log4net_DebugWrite(object message)
        {
			log4net_Init();
			log.Debug(message);

		}

		private static void log4net_Init()
        {
			// log4net의 기본 구조를 꺼낸다.
			// log4net의 기본 구조를 꺼낸다.
			//log4net.Repository.Hierarchy.Hierarchy hierarchy = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();

			if (null == hierarchy)
			{


				hierarchy = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();


				// log4net의 설정 기능을 활성화 시킨다.
				hierarchy.Configured = true;

				// log4net을 이용하여 로깅을 할 때, 어떤 방식으로 로그를 남길지를 설정한다.
				// 파일, DB, 이벤트로그, 등등 다양한 위치에 로그를 쌓을 수 있는데,
				// 아래의 예제는 RollingFile 기반 ( 일정 사이즈가 되거나, 날짜가 변경되면 자동으로 새로운 파일을 생성해서 로그를 
				// 남기는 방식 )으로 구현했다.
				// 만약 다른 방식으로 변경하려면, rollingAppender의 클래스와 설정을 변경하면 된다.
				log4net.Appender.RollingFileAppender rollingAppender = new log4net.Appender.RollingFileAppender();
				//	rollingAppender.File = @"C:\DEV\Log\cupps.log";
				rollingAppender.File = $@"{AppDomain.CurrentDomain.BaseDirectory}\\Log\\Log.log";

				rollingAppender.AppendToFile = true;
				// RollingFile 방식을 설정한다.
				rollingAppender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Composite;
				// 로그 파일 최대 크기를 설정한다.
				rollingAppender.MaxFileSize = 1024 * 1024 * 2;
				// 로그 파일 작성시, 동시 Write 방지 Locking Model 방식을 설정한다.
				rollingAppender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
				// 날짜 변경시 기존 로그 파일이름을 어떤식으로 변경할지에 대해서 설정한다.
				rollingAppender.DatePattern = "_yyyyMMdd\".log\"";
				// 로그 파일 내에 로그(한 줄)를 어떤식으로 기록할지에 대한 Format을 설정한다.
				log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout("%date %-5level %logger - %message%newline");
				rollingAppender.Layout = layout;
				// 위에서 설정한 Appender 섲렁을 활성화시킨다.
				rollingAppender.ActivateOptions();
				// Logger에다가 위에서 설정한 Appender를 추가한다.
				hierarchy.Root.AddAppender(rollingAppender);
				// 여기까지가 Appender 추가 방법.

				// 로그를 남기는 레벨 설정 ( INFO, DEBUG, WARN, ERROR, ALL 등이 있다 )
				hierarchy.Root.Level = log4net.Core.Level.All;
			}
		}
		/// <summary>
		/// write log line
		/// </summary>
		/// <param name="path"></param>
		/// <param name="msg"></param>
		public static void WriteLine(string path, string msg)
		{
			if (IsDisabled) return;

			try
			{
				using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
				{
					var now = DateTime.Now;
					sw.WriteLine($"[{string.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}:{4:D2}:{5:D2}.{6:D3}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond)}] {msg}");
					sw.Flush();
					sw.Close();
					sw.Dispose();
				}
			}
			catch
			{

			}
		}

		/// <summary>
		/// write stream to hex log line
		/// </summary>
		/// <param name="path"></param>
		/// <param name="stream"></param>
		public static void WriteLine(string path, byte[] stream)
		{
			if (IsDisabled) return;

			StringBuilder sb = new StringBuilder();
			foreach (var b in stream)
			{
				sb.Append($"{string.Format("{0:X2}", b)} ");
			}
			WriteLine(path, sb.ToString());
		}

		/// <summary>
		/// write debug log
		/// </summary>
		/// <param name="msg"></param>
		public static void Debug(string ch, string msg)
		{
			var dt = string.Format("{0:D4}{1:D2}{2:D2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			WriteLine($@"{PDEBUG_PATH}\Cycler\dbg_{ch}_{dt}.log", msg);
		}

        public static void GradeLog(string ch, string msg)
        {
            var dt = string.Format("{0:D4}{1:D2}{2:D2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            WriteLine($@"{PDEBUG_PATH}\result_{ch}_{dt}.log", msg);
        }

        public static void BuildVersion(string msg)
        {
			   string basePath = $@"{AppDomain.CurrentDomain.BaseDirectory}";
			   string fileName = $@"{AppDomain.CurrentDomain.BaseDirectory}BuildDate.txt";

			   foreach (string file in Directory.EnumerateFiles(basePath, "BuildDate.txt", SearchOption.TopDirectoryOnly))
            {
				    System.IO.File.Delete(file);
			   }

				try
				{
					 using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, true))
					 {
						 var now = DateTime.Now;
						 sw.WriteLine($"{msg}");
		 				 sw.Flush();
						 sw.Close();
						 sw.Dispose();
					 }
				}
				catch
				{
				}
		}
    }
}
