using CaseStudy.BusinessLayer.Abstract;
using CaseStudy.BusinessLayer.Concrete;
using CaseStudy.DAL.Abstract;
using CaseStudy.DAL.Concrete;
using CaseStudy.DAL.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("StudyCaseApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>();

//lifeTime
builder.Services.AddScoped<IMeetingDal, EFMeetingDal>();
builder.Services.AddScoped<IMeetingService, MeetingManager>();


var app = builder.Build();


//dbcontext

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("StudyCaseApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
