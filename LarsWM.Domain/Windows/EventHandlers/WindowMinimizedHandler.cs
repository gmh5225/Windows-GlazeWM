﻿using System.Linq;
using LarsWM.Domain.Containers;
using LarsWM.Domain.Containers.Commands;
using LarsWM.Infrastructure.Bussing;
using LarsWM.Infrastructure.WindowsApi.Events;

namespace LarsWM.Domain.Windows.EventHandlers
{
  class WindowMinimizedHandler : IEventHandler<WindowMinimizedEvent>
  {
    private Bus _bus;
    private WindowService _windowService;
    private ContainerService _containerService;

    public WindowMinimizedHandler(Bus bus, WindowService windowService, ContainerService containerService)
    {
      _bus = bus;
      _windowService = windowService;
      _containerService = containerService;
    }

    public void Handle(WindowMinimizedEvent @event)
    {
      var window = _windowService.GetWindows()
        .FirstOrDefault(window => window.Hwnd == @event.WindowHandle);

      if (window == null)
        return;

      window.Mode = WindowMode.MINIMIZED;
      window.SizePercentage = 0;

      _containerService.SplitContainersToRedraw.Add(window.Parent as SplitContainer);
      _bus.Invoke(new RedrawContainersCommand());
    }
  }
}
