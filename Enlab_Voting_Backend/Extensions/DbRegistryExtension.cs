﻿using Enlab_Voting_Backend.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Text;
using Enlab_Voting_Backend.DbContext;
using CloudinaryDotNet;
using Enlab_Voting_Backend.Implemantations;
using Enlab_Voting_Backend.Services;

namespace Enlab_Voting_Backend.Extensions
{
	public static class DbRegistryExtension
	{
		public static void AddDbContextAndConfigurations(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContextPool<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));


			});

			services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
				});

			var cloudinarySettings = configuration.GetSection("Cloudinary");

			var account = new Account(
				cloudinarySettings["CloudName"],
				cloudinarySettings["ApiKey"],
				cloudinarySettings["ApiSecret"]);

			var cloudinary = new Cloudinary(account);

			services.AddSingleton(cloudinary);



			// Configure JWT authentication options-------------------------------------------
			var jwtSettings = configuration.GetSection("JwtSettings");
			var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});

			//Password configuration
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
			});

			// Repo Registration
			services.AddScoped<IAppUserRepository, AppUserRepository>();
			services.AddScoped<IAuthRepository, AuthRepository>();
			services.AddScoped<IContestantInterfaceRepo, ContestantInterfaceRepo>();
			services.AddScoped<IContestInterfaceRepo, ContestInterfaceRepo>();
			services.AddScoped<IFileUploadRepository, FileUploadRepository>();
			services.AddScoped<IUserInterfaceRepository, UserInterfaceRepository>();


			//services.AddScoped<IEmailServices, EmailServices>();

			services.AddScoped<IEmailServices>(provider =>
			{
				var smtpHost = "smtp.gmail.com";
				var smtpPort = 587;
				var smtpUsername = "Palmfitsquad15@gmail.com";
				var smtpPassword = "kwatusdniiwfygmr";

				return new EmailServices(smtpHost, smtpPort, smtpUsername, smtpPassword);
			});

			//Identity role registration with Stores and default token provider
			services.AddIdentity<AppUser, AppUserRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();



			////configuring Cross-Origin Resource Sharing (CORS) settings 
			//services.AddCors(options =>
			//{
			//	options.AddDefaultPolicy(builder =>
			//	{
			//		builder.WithOrigins("*") // Replace with your React app's URL
			//			   .AllowAnyHeader()
			//			   .AllowAnyMethod()
			//			   .WithExposedHeaders("Authorization"); // This adds the custom authorization header to response
			//	});
			//});

		}
	}
}
