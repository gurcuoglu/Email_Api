using EmailApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IEmailSender, EmailSender>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/EmailAdres/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi3();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmailAdres}/{action=Index}/{id?}");

app.Run();
