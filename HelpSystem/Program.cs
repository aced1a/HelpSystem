var host = new WebHostBuilder()
      .UseKestrel()
      .UseContentRoot(Directory.GetCurrentDirectory())
      .UseDefaultServiceProvider(options => options.ValidateScopes = false)
      .UseIISIntegration()
      .UseStartup<HelpSystem.Startup>()
      .Build();

host.Run();
