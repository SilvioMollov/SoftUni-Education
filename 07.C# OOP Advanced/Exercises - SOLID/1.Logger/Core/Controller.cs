﻿namespace _1.Logger.Core
{
    using _1.Logger.Factories;
    using _1.Logger.Interfaces;
    using System;

    public class Controller
    {
        private FactoryAppender factoryAppender;

        public Controller()
        {
            this.factoryAppender = new FactoryAppender();
        }

        public void Run()
        {
            var numberOfAppenders = int.Parse(Console.ReadLine());
            var appenders = new IAppender[numberOfAppenders];
            for (int i = 0; i < numberOfAppenders; i++)
            {
                IAppender appender = this.factoryAppender.Create(Console.ReadLine());
                appenders[i] = appender;
            }

            var logger = new Models.LoggerModels.Logger(appenders);

            var messageInfoLine = Console.ReadLine();
            while (messageInfoLine != "END")
            {
                var messageTokens = messageInfoLine.Split('|');
                var reportLevel = messageTokens[0];
                var date = messageTokens[1];
                var msg = messageTokens[2];

                switch (reportLevel)
                {
                    case "INFO":
                        logger.Info(date, msg);
                        break;

                    case "WARNING":
                        logger.Warn(date, msg);
                        break;

                    case "ERROR":
                        logger.Error(date, msg);
                        break;

                    case "CRITICAL":
                        logger.Critical(date, msg);
                        break;

                    case "FATAL":
                        logger.Fatal(date, msg);
                        break;
                }

                messageInfoLine = Console.ReadLine();
            }

            Console.WriteLine("Logger info");

            foreach (var appender in logger.GetAppenders())
            {
                Console.WriteLine(appender);
            }
        }
    }
}