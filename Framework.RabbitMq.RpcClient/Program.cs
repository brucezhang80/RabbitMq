﻿using System;
using Framework.RabbitMq.Model;
using FrameWork.RabbitMq.RabbitMqProxyConfig;

namespace FrameWork.RabbitMq.RpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMqProxy = new RabbitMqService(new MqConfig
            {
                AutomaticRecoveryEnabled = true,
                HeartBeat = 60,
                NetworkRecoveryInterval = new TimeSpan(60),
                Host = "localhost",
                UserName = "admin",
                Password = "admin"
            });

            var input = Input();
            while (input != "exit")
            {
                var rpcMsgModel = new RpcMsgModel
                {
                    CreateDateTime = DateTime.Now,
                    Msg = input
                };

                var result = rabbitMqProxy.RpcClient(rpcMsgModel);

                Console.WriteLine(result);

                input = Input();
            }

            rabbitMqProxy.Dispose();
        }

        private static string Input()
        {
            Console.WriteLine("请输入信息：");
            var input = Console.ReadLine();
            return input;
        }
    }

}
