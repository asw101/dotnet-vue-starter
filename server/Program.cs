using dotnet_vue_starter.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
 
 
//this serves our Vue file
//app.UseDefaultFiles().UseStaticFiles();
//here's a comment to unstkick thing
var app = builder.Build();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");


var libPath = Path.Combine(app.Environment.WebRootPath, "Content");
var contentLibrary = new ContentLibrary(libPath).Load();
//lock this down as needed
app.UseCors(builder => builder
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader()
);

//load the routes
dotnet_vue_starter.Api.Content.MapRoutes(app, contentLibrary);

app.Run();

//this is for tests
public partial class Program { }