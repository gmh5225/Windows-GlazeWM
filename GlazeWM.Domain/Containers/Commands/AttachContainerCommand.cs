﻿using GlazeWM.Infrastructure.Bussing;

namespace GlazeWM.Domain.Containers.Commands
{
  public class AttachContainerCommand : Command
  {
    public Container Parent { get; }
    public Container ChildToAdd { get; }
    public int InsertPosition { get; }

    // Insert child as end element if `insertPosition` is not provided.
    public AttachContainerCommand(Container parent, Container childToAdd)
    {
      Parent = parent;
      ChildToAdd = childToAdd;
      InsertPosition = parent.Children.Count;
    }

    public AttachContainerCommand(Container parent, Container childToAdd, int insertPosition)
    {
      Parent = parent;
      ChildToAdd = childToAdd;
      InsertPosition = insertPosition;
    }
  }
}
