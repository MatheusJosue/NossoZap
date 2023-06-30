using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model;
using Service.Implementation;
using Service.Interface;
using System.Text;

#region builder

var builder = WebApplication.CreateBuilder(args);
    ConfigurationManager configuration = builder.Configuration;
    #pragma warning disable CS8600
    string mySqlConnection = configuration.GetConnectionString("Database");
    #pragma warning restore CS8600

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<MySQLContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection), b => b.MigrationsAssembly("Application")));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<MySQLContext>()
    .AddDefaultTokenProviders();

// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = configuration["JWT:ValidIssuer"],

        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),

        ValidateLifetime = true
    };
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped(typeof(GenericRepository<,>));
builder.Services.AddScoped<FriendRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<MessageRepository>();
builder.Services.AddScoped<RequestRepository>();
builder.Services.AddScoped<LikeRepository>();
builder.Services.AddScoped<CommentRepository>();

#endregion

#region app

var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var service = scope.ServiceProvider;

        var context = service.GetRequiredService<MySQLContext>();
        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(p => {
        p.AllowAnyMethod();
        p.AllowAnyHeader();
        p.AllowAnyOrigin();
    });

app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

#endregion