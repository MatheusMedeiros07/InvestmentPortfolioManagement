using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Jobs;
using InvestmentPortfolioManagement.Tests;

public class Program
{
    public static async Task Main(string[] args)
    {

        // Chama o teste SMTP
        SmtpTest.RunTest();

        var host = CreateHostBuilder(args).Build();

        var scheduler = await host.Services.GetRequiredService<ISchedulerFactory>().GetScheduler();

        var job = JobBuilder.Create<EmailNotificationJob>()
            .WithIdentity("emailNotificationJob", "group1")
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity("emailNotificationTrigger", "group1")
            .WithCronSchedule("0 */5 * * * ?") // Executa a cada 5 minutos
            .Build();

        await scheduler.ScheduleJob(job, trigger);

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
