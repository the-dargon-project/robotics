using Dargon.Commons.Collections;
using System;
using SCG = System.Collections.Generic;

namespace Dargon.Robotics {
   public class SubsystemCommandBasedIterativeRobot : IterativeRobot {
      private SubsystemCommandBasedIterativeRobot(
         IterativeRobotConfiguration configuration, 
         UserCode userCode
      ) : base(configuration, userCode) {
      }

      public static SubsystemCommandBasedIterativeRobot Create(
         IterativeRobotConfiguration configuration,
         SCG.IReadOnlyDictionary<int, ISubsystem> subsystems,
         SCG.IReadOnlyList<ICommand> commands
      ) {
         var userCode = new UserCode(subsystems, commands);
         return new SubsystemCommandBasedIterativeRobot(configuration, userCode);
      }

      public class UserCode : IterativeRobotUserCode {
         private readonly ConcurrentSet<ICommand> executingCommands = new ConcurrentSet<ICommand>();
         private readonly SCG.IReadOnlyDictionary<int, ISubsystem> subsystems;
         private readonly SCG.IReadOnlyList<ICommand> commands;
         private int activeSubsystems = 0;

         public UserCode(SCG.IReadOnlyDictionary<int, ISubsystem> subsystems, SCG.IReadOnlyList<ICommand> commands) {
            this.subsystems = subsystems;
            this.commands = commands;
         }

         public override void OnTick() {
            base.OnTick();

            foreach (var command in commands) {
               bool executing = executingCommands.Contains(command);

               if (!executing && command.IsExecutable) {
                  var subsystemConflict = (command.Subsystem & activeSubsystems) != 0;

                  if (((command.IsPassive || command.IsTriggered) && !subsystemConflict) || command.IsForceTriggered) {
                     foreach (var executingCommand in executingCommands) {
                        if ((executingCommand.Subsystem & command.Subsystem) != 0) {
                           activeSubsystems &= ~executingCommand.Subsystem;

                           executingCommand.Cancel();
                           executingCommands.RemoveOrThrow(executingCommand);
                        }
                     }

                     Console.WriteLine($"Start Command {command}.");
                     command.Start();
                     executing = true;
                     executingCommands.AddOrThrow(command);

                     if (!command.IsPassive) {
                        activeSubsystems |= command.Subsystem;
                     }
                  }
               }

               if (executing) {
                  var status = command.RunIteration();
                  if (status == CommandStatus.Complete || status == CommandStatus.Abort) {
                     Console.WriteLine($"Command {command} finishing: {status}");
                     executingCommands.RemoveOrThrow(command);
                  }
               }
            }
         }
      }
   }

   public interface ICommand {
      /// <summary>
      /// Whether the command can be started.
      /// E.g. "Shoot Ball" isn't executable if no ball is posessed.
      /// </summary>
      bool IsExecutable { get; }

      /// <summary>
      /// Whether the command should execute when no other command is executing.
      /// </summary>
      bool IsPassive { get; }

      /// <summary>
      /// Whether the command should execute if its subsystems are free.
      /// </summary>
      bool IsTriggered { get; }

      /// <summary>
      /// Whether the command should kick off another already-executing command.
      /// </summary>
      bool IsForceTriggered { get; }

      /// <summary>
      /// Integer representation of bitset representing the subsystems used by this command.
      /// </summary>
      int Subsystem { get; }
      
      /// <summary>
      /// Invoked when the command begins executing.
      /// </summary>
      void Start();

      /// <summary>
      /// Invoked in the robot main loop if the command is executing.
      /// If Complete/Abort is returned, the subsystem is responsible for halting.
      /// </summary>
      /// <returns></returns>
      CommandStatus RunIteration();

      /// <summary>
      /// Invoked when the command is cancelled by another command.
      /// </summary>
      void Cancel();
   }

   public enum CommandStatus {
      Continue,
      Abort,
      Complete
   }
}
