using UI.Interfaces;
using UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILibraries, LibraryServices>();
builder.Services.AddScoped<IMovies, MovieServices>();
builder.Services.AddScoped<IShows, ShowServices>();
builder.Services.AddScoped<IMissing, MissingServices>();
builder.Services.AddScoped<ISeasons, SeasonServices>();
builder.Services.AddScoped<IMusic, MusicServices>();
builder.Services.AddScoped<IEpisodes, EpisodeServices>();
builder.Services.AddScoped<IVideos, VideoServices>();
builder.Services.AddScoped<INaming, NamingServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Libraries}/{action=Index}/{id?}");

app.Run();