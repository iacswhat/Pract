using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    app.Run(async context =>
                    {
                        if (context.Request.Method == "GET" && context.Request.Path == "/api/bmi")
                        {
                            if (double.TryParse(context.Request.Query["height"], out double height) &&
                                double.TryParse(context.Request.Query["weight"], out double weight))
                            {
                                if (height <= 0 || weight <= 0)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    await context.Response.WriteAsync("���� � ��� ������ ���� �������������� �������.");
                                }
                                else
                                {
                                    height = height / 100;
                                    double bmi = weight / (height * height);

                                    string description;
                                    if (bmi < 18.5)
                                    {
                                        description = "������������� ���";
                                    }
                                    else if (bmi < 25)
                                    {
                                        description = "���������� ���";
                                    }
                                    else if (bmi < 30)
                                    {
                                        description = "���������� ���";
                                    }
                                    else
                                    {
                                        description = "��������";
                                    }

                                    var result = new
                                    {
                                        BMI = bmi,
                                        Description = description
                                    };

                                    context.Response.StatusCode = StatusCodes.Status200OK;
                                    await context.Response.WriteAsJsonAsync(result);
                                }
                            }
                            else
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                await context.Response.WriteAsync("������������ ��������� ����� �/��� ����.");
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                        }
                    });
                });
            });
}
