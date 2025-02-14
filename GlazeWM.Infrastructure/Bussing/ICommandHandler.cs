﻿namespace GlazeWM.Infrastructure.Bussing
{
  public interface ICommandHandler<TCommand> where TCommand : Command
  {
    CommandResponse Handle(TCommand command);
  }
}
