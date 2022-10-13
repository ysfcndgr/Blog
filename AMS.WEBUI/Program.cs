using AMS.BLL.Abstract;
using AMS.BLL.Concrete;
using AMS.DAL.Abstract.EfCore;
using AMS.DAL.Concrete.EfCore.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddControllers();

#region Set Dependency Injection
builder.Services.AddScoped<ICategoryDal, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IBlogDal, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogManager>();

builder.Services.AddScoped<ICommentDal, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddScoped<IWriterDal, WriterRepository>();
builder.Services.AddScoped<IWriterService, WriterManager>();

builder.Services.AddScoped<INewsLetterDal, NewsLetterRepository>();
builder.Services.AddScoped<INewsLetterService, NewsLetterManager>();

builder.Services.AddScoped<IContactDal, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<INotificationDal, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationManager>();

builder.Services.AddScoped<IMessageDal, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<INewMessageDal, NewMessageRepository>();
builder.Services.AddScoped<INewMessageService, NewMessageManager>();
#endregion Set Dependency Injection

builder.Services.AddMvc();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x => { x.LoginPath = "/Login/Index"; });
//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//    config.Filters.Add(new AuthorizeFilter(policy));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}"
);
    //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

   endpoints.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );
});

app.UseMvcWithDefaultRoute();

app.Run();