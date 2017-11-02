﻿namespace _1.Logger.Models.AppenderModels
{
    using _1.Logger.Enums;
    using _1.Logger.Interfaces;
    using System.IO;

    public class FileAppender : IAppender
    {
        private readonly ILayout layout;

        private LogFile logFile;

        private int countOfMessages;

        public FileAppender(ILayout layout)
        {
            this.layout = layout;
            this.logFile = new LogFile();
            this.countOfMessages = 0;
        }

        public ReportLevel LevelOfThreshold { get; set; }

        public void Append(ReportLevel reportLevel, string date, string msg)
        {
            if (this.LevelOfThreshold <= reportLevel)
            {
                this.countOfMessages++;
                var formattedMsg = this.layout.Formatting(reportLevel, date, msg);
                this.logFile.Write(formattedMsg);
                using (var stream = new StreamWriter("Reports.txt", append: true))
                {
                    stream.WriteLine(formattedMsg);
                }
            }
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.LevelOfThreshold}, Messages appended: {this.countOfMessages}, File size: {this.logFile.Size}";
        }
    }
}