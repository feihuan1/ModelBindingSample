// model binding is a feature of asp.net core that reads value from http requests and pass them as argumant to the action method
// http request -> routing -> Model Binding(form field, req body, Route data, query string parameters): these are recieved in orders by default if not specified -> action


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();
