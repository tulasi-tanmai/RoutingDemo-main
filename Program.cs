var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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



//Conventional Routing Configuration
    app.MapControllerRoute(
        name: "about",
        pattern: "about-us",
        defaults: new { controller = "Home", action = "About" }
    );
     app.MapControllerRoute(
        name: "contact",
        pattern: "contact/{department?}",
        defaults: new { controller = "Home", action = "Contact" }
    );
     app.MapControllerRoute(
        name: "products",
        pattern: "products",
        defaults: new { controller = "Products", action = "Index" }
    );
      app.MapControllerRoute(
        name: "product-details",
        pattern: "products/details/{id}",
        defaults: new { controller = "Products", action = "Details" }
    );

//Adding contraint routes
 // Adding constraint routes 
    app.MapControllerRoute(
        name: "blog-archive",
        pattern: "blog/{year:int:min(2020)}/{month:int:range(1,12)}/{day:int:range(1,31)?}",
        defaults: new { controller = "Blog", action = "Archive" }
    );
    app.MapControllerRoute(
        name: "user-profile",
        pattern: "user/{username:minlength(3)}/{tab}",
        defaults: new { controller = "User", action = "Profile" }
    );
    app.MapControllerRoute(
        name: "api-versioned",
        pattern: "api/v{version:regex(^[0-9]+\\.[0-9]+$)}/{action}",
        defaults: new { controller = "Api", action = "Version" }
    );


    //Default route should be last
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
