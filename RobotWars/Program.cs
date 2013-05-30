using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RobotWarsLogic;
using RobotWarsLogic.CommandLineReaders;
using RobotWarsLogic.Commands;
using RobotWarsLogic.Interfaces;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            
            BuildDependencies(container);

            var commanLineReaders = container.ResolveAll<ICommandLineReader>().ToList();

            bool exit = false;
            while (!exit)
            {
                var command = Console.ReadLine();
                if (command == "exit" || command == "quit")
                {
                    exit = true;
                    continue;
                }

                foreach (var commandReader in commanLineReaders)
                {
                    //if (!commandReader.Validate(command))
                    //{
                    //    continue;
                    //}

                    commandReader.Process(command);
                    break;
                }
            }
        }

        private static void BuildDependencies(IWindsorContainer container)
        {
            container.Register(Component.For<IContext>().ImplementedBy<Context>().Named("Context").LifeStyle.Singleton);
            container.Register(Component.For<IArena>().ImplementedBy<Arena>().Named("Arena"));
            container.Register(Component.For<IRobotWars>().ImplementedBy<RobotWarsLogic.RobotWars>().Named("RobotWars"));

            container.Register(Component.For<IValidateCommand>().ImplementedBy<ValidateCommand>().Named("ValidateCommand"));

            container.Register(Component.For<ICommand>().ImplementedBy<SpinCommand>().Named("SpinCommand"));
            container.Register(Component.For<ICommand>().ImplementedBy<MoveCommand>().Named("MoveCommand"));

            container.Register(Component.For<ICommandLineReader>().ImplementedBy<CreateArenaCommandLineReader>().Named("CreateArena"));
            container.Register(Component.For<ICommandLineReader>().ImplementedBy<CreateRobotCommandLineReader>().Named("CreateRobot"));
            container.Register(Component.For<ICommandLineReader>().ImplementedBy<CreateMoveCommandLineReader>().Named("CreateMove"));
        }
    }
}
