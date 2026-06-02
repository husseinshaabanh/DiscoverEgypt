using DiscoverEgypt.API.Extensions;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Authentication.Interfaces;
using DiscoverEgypt.Core.Features.Booking.Interfaces;
using DiscoverEgypt.Core.Features.Community.Interfaces;
using DiscoverEgypt.Core.Features.Conversation.Interfaces;
using DiscoverEgypt.Core.Features.CustomPlans.Interfaces;
using DiscoverEgypt.Core.Features.Email.Interfaces;
using DiscoverEgypt.Core.Features.Favorite.Interfaces;
using DiscoverEgypt.Core.Features.Geoapify.Interfaces;
using DiscoverEgypt.Core.Features.GuideReviews.Interfaces;
using DiscoverEgypt.Core.Features.Message.Interfaces;
using DiscoverEgypt.Core.Features.Nationalities.Interfaces;
using DiscoverEgypt.Core.Features.Notification.Interfaces;
using DiscoverEgypt.Core.Features.Payment.Interfaces;
using DiscoverEgypt.Core.Features.Places.Interfaces;
using DiscoverEgypt.Core.Features.ReadyPlans.Interfaces;
using DiscoverEgypt.Core.Features.RequestGuide.Interfaces;
using DiscoverEgypt.Core.Features.Review.Interfaces;
using DiscoverEgypt.Core.Features.Roles.Interfaces;
using DiscoverEgypt.Core.Features.UploadImage.Interfaces;
using DiscoverEgypt.Core.Features.Users.Interfaces;
using DiscoverEgypt.Core.Helpers;
using DiscoverEgypt.Core.Interfaces;
using DiscoverEgypt.Repository;
using DiscoverEgypt.Repository.Data.DBContext;
using DiscoverEgypt.Service;
using DiscoverEgypt.Service.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region Identity
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
#endregion

#region Configuration Bindings
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
#endregion

#region JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
    };
});
#endregion

#region Dependency Injection

// ─── Repositories ───
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IReadyPlanRepository, ReadyPlanRepository>();

// ─── Auth ───
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISocialAuthService, SocialAuthService>();

// ─── Services ───
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<ICustomPlanService, CustomPlanService>();
builder.Services.AddScoped<ICommunityService, CommunityService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IGuideReviewService, GuideReviewService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<INationalityService, NationalityService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IRequestService, RequestGuideService>();
builder.Services.AddScoped<IPlaceReviewService, PlaceReviewService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUploadService, UploadService>();
builder.Services.AddScoped<IUserService, UserService>();

// ─── HttpClient for Geoapify ───
builder.Services.AddHttpClient<IGeoapifyService, GeoapifyService>();

#endregion

#region AutoMapper
builder.Services.AddAutoMapper(cfg => { },
    typeof(Program).Assembly,
    typeof(DiscoverEgypt.Core.Mapping.BookingProfile).Assembly);
#endregion

#region Controllers & JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
#endregion

#region Swagger
builder.Services.AddSwaggerDocumentation();
#endregion

var app = builder.Build();

#region Middleware Pipeline

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseSwaggerMiddlewares();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.SeedDataAsync();
await app.SeedRolesAsync();

app.Run();

#endregion