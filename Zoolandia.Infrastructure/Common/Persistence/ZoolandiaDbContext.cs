using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoolandia.Domain.Models;
using Zoolandia.Infrastructure.Identity;

namespace Zoolandia.Infrastructure.Common.Persistence;

public class 
    ZoolandiaDbContext(DbContextOptions<ZoolandiaDbContext> options)
        : IdentityDbContext<User>(options)
{
    
    public DbSet<Profile> Profiles { get; set; } = default!;

    public DbSet<Pet> Pets { get; set; } = default!;

    public DbSet<Post> Posts { get; set; } = default!;
    
    public DbSet<Service> Services { get; set; } = default!;
    
    public DbSet<Breed> Breeds { get; set; } = default!;

    // public DbSet<Meeting> Meetings { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        // builder
        //     .Entity<Meeting>()
        //     .HasOne(p => p.Profile)
        //     .WithOne(p => p.Meeting)
        //     .HasForeignKey<Meeting>("SitterId");
        
        builder.ApplyConfigurationsFromAssembly(typeof(ZoolandiaDbContext).Assembly);
        
        SeedBreeds(builder.Entity<Breed>());
        SeedAdminAndRoles(builder);
        
        base.OnModelCreating(builder);
    }

    private static void SeedBreeds(EntityTypeBuilder<Breed> entity)
    {
        entity.HasData(
            new Breed("Аффенпинчер"),
            new Breed("Афганска хрътка"),
            new Breed("Африканско ловно куче"),
            new Breed("Айредейл териер"),
            new Breed("Акбаш куче"),
            new Breed("Акита"),
            new Breed("Алапахски булдог"),
            new Breed("Аляски хъски"),
            new Breed("Аляски маламут"),
            new Breed("Американски булдог"),
            new Breed("Американски були"),
            new Breed("Американско ескимоско куче"),
            new Breed("Американска лисица"),
            new Breed("Американски питбул териер"),
            new Breed("Американски стафордширски териер"),
            new Breed("Американски воден спаниел"),
            new Breed("Анатолийско пастирско куче"),
            new Breed("Апензелер сененхунд"),
            new Breed("Австралийско пастирско куче"),
            new Breed("Австралийски келпи"),
            new Breed("Австралийска овчарка"),
            new Breed("Австралийски териер"),
            new Breed("Азавах"),
            new Breed("Барбе"),
            new Breed("Басенджи"),
            new Breed("Басет Гаскон"),
            new Breed("Басет хрътка"),
            new Breed("Бийгъл"),
            new Breed("Брадато коли"),
            new Breed("Босерон"),
            new Breed("Бедлингтон териер"),
            new Breed("Белгийски малиноа"),
            new Breed("Белгийски тервюрен"),
            new Breed("Бернско планинско куче"),
            new Breed("Бишон фризе"),
            new Breed("Черно-тан кунхаунд"),
            new Breed("Блъдхаунд"),
            new Breed("Блутик кунхаунд"),
            new Breed("Бурбул"),
            new Breed("Бордър коли"),
            new Breed("Бордър териер"),
            new Breed("Бостън териер"),
            new Breed("Бувие де Фландр"),
            new Breed("Боксер"),
            new Breed("Бойкин спаниел"),
            new Breed("Брако Италиано"),
            new Breed("Бриар"),
            new Breed("Бретон"),
            new Breed("Бул териер"),
            new Breed("Бул мастиф"),
            new Breed("Кеърн териер"),
            new Breed("Кане корсо"),
            new Breed("Кардиган уелско корги"),
            new Breed("Катахула леопард куче"),
            new Breed("Кавказка овчарка"),
            new Breed("Кавалер Кинг Чарлз спаниел"),
            new Breed("Чесапийк бей ретривър"),
            new Breed("Китайско хохлато куче"),
            new Breed("Китайски шарпей"),
            new Breed("Чинук"),
            new Breed("Чау Чау"),
            new Breed("Клъмбър спаниел"),
            new Breed("Кокер спаниел"),
            new Breed("Кокер американски"),
            new Breed("Котон де Тулеар"),
            new Breed("Далматинец"),
            new Breed("Доберман"),
            new Breed("Дого Аржентино"),
            new Breed("Холандска овчарка"),
            new Breed("Английски сетер"),
            new Breed("Английска овчарка"),
            new Breed("Английски спрингер спаниел"),
            new Breed("Английски той спаниел"),
            new Breed("Английски териер"),
            new Breed("Евразиец"),
            new Breed("Полски спаниел"),
            new Breed("Финландско лапландско куче"),
            new Breed("Финландски шпиц"),
            new Breed("Френски булдог"),
            new Breed("Немски пинчер"),
            new Breed("Немска овчарка"),
            new Breed("Немски късокосмест пойнтер"),
            new Breed("Гигантски шнауцер"),
            new Breed("Глен имаал териер"),
            new Breed("Голдън ретривър"),
            new Breed("Гордън сетер"),
            new Breed("Немски дог"),
            new Breed("Пиренейска планинска овчарка"),
            new Breed("Грейхаунд"),
            new Breed("Грифон брюкселуа"),
            new Breed("Харие"),
            new Breed("Хаванез"),
            new Breed("Ирландски сетер"),
            new Breed("Ирландски териер"),
            new Breed("Ирландски вълкодав"),
            new Breed("Италианска хрътка"),
            new Breed("Японски чин"),
            new Breed("Японски шпиц"),
            new Breed("Кеесхонд"),
            new Breed("Комондор"),
            new Breed("Койкер хондже"),
            new Breed("Кувас"),
            new Breed("Лабрадор ретривър"),
            new Breed("Лагото романьоло"),
            new Breed("Ланкашър хийлър"),
            new Breed("Леонбергер"),
            new Breed("Лхаса апсо"),
            new Breed("Малтийска болонка"),
            new Breed("Мини американска овчарка"),
            new Breed("Миниатюрен пинчер"),
            new Breed("Миниатюрен шнауцер"),
            new Breed("Нюфаундленд"),
            new Breed("Норфолк териер"),
            new Breed("Норич териер"),
            new Breed("Нова шотландска патица ретривър"),
            new Breed("Старо английско овчарско куче"),
            new Breed("Оригинален английски булдог"),
            new Breed("Папийон"),
            new Breed("Пекинез"),
            new Breed("Уелско корги пембрук"),
            new Breed("Перро депреса канарио"),
            new Breed("Фараонско куче"),
            new Breed("Плот"),
            new Breed("Померан"),
            new Breed("Пудел миниатюрен"),
            new Breed("Пудел той"),
            new Breed("Мопс"),
            new Breed("Пули"),
            new Breed("Пуми"),
            new Breed("Плъхов териер"),
            new Breed("Редбоун кунхаунд"),
            new Breed("Родезийски риджбек"),
            new Breed("Ротвайлер"),
            new Breed("Руска той териер"),
            new Breed("Свети Бернар"),
            new Breed("Салуки"),
            new Breed("Самоед"),
            new Breed("Шиперке"),
            new Breed("Шотландски еленов хрътка"),
            new Breed("Шотландски териер"),
            new Breed("Шетландско овчарско куче"),
            new Breed("Шиба ину"),
            new Breed("Ши Тцу"),
            new Breed("Шило овчар"),
            new Breed("Сибирско хъски"),
            new Breed("Копринено териер"),
            new Breed("Гладък фокс териер"),
            new Breed("Мека пшенична териер"),
            new Breed("Испанско водно куче"),
            new Breed("Спиноне Италиано"),
            new Breed("Стафордширски бул териер"),
            new Breed("Стандартен шнауцер"),
            new Breed("Шведски валхунд"),
            new Breed("Тайландско гребено куче"),
            new Breed("Тибетски мастиф"),
            new Breed("Тибетски спаниел"),
            new Breed("Тибетски териер"),
            new Breed("Играчка фокс териер"),
            new Breed("Дървесен уокър кунхаунд"),
            new Breed("Визла"),
            new Breed("Ваймаранер")
        );
    }

    private static void SeedAdminAndRoles(ModelBuilder builder)
    {
        string[] roleNames = { "Owner", "Sitter", "Administrator" };
        string roleId = default;
        
        foreach (var role in roleNames)
        {
            roleId = Guid.NewGuid().ToString();

            builder
                .Entity<IdentityRole>()
                .HasData(new IdentityRole()
                {
                    Id = roleId,
                    Name = role,
                    NormalizedName = role.ToUpper().Normalize(),
                    ConcurrencyStamp = roleId
                });
        }
        
        var adminId = Guid.NewGuid().ToString();
        var adminEmail = "hristopanev20@gmail.com"; // Has to be changed when official email is created
        var admin = new User
        {
            Id = adminId,
            Email = adminEmail,
            NormalizedEmail = adminEmail.ToUpper().Normalize(),
            EmailConfirmed = true,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
        };
                
        PasswordHasher<User> passwordHasher = new();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin_1234");

        builder
            .Entity<User>()
            .HasData(admin);
        
        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>()
            {
                RoleId = roleId,
                UserId = adminId
            });
        
    }
}
